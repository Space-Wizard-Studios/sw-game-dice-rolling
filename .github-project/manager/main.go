package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"os"
	"path/filepath"

	"github.com/google/go-github/github"
	"github.com/joho/godotenv"
	"golang.org/x/oauth2"
	"gopkg.in/yaml.v2"

	flag "github.com/spf13/pflag"
)

const (
	owner = "Space-Wizard-Studios"
	repo  = "sw-game-dice-roll"
)

type Issue struct {
	Title string `yaml:"title"`
	// Description        string   `yaml:"description"`
	// Assignees          []string `yaml:"assignees"`
	// Labels             []string `yaml:"labels"`
	State  string `yaml:"state"`
	Status string `yaml:"status"`
	// Type               string   `yaml:"type"`
	// Priority           string   `yaml:"priority"`
	// Size               string   `yaml:"size"`
	// Reviewers          []string `yaml:"reviewers"`
	// StartDate          string   `yaml:"start-date"`
	// EndDate            string   `yaml:"end-date"`
	// LinkedPullRequests []string `yaml:"linked-pull-requests"`
	// Iteration          string   `yaml:"iteration"`
	SubIssues []Issue `yaml:"sub-issues"`
}

type Config struct {
	State   string
	PerPage int
	Save    bool
}

func main() {
	config := loadConfig()

	ctx := context.Background()
	client := createGitHubClient(ctx)

	switch flag.Arg(0) {
	case "list-remote":
		listRemoteIssues(ctx, client, config)
	case "list-local":
		listLocalIssues(config)
	case "compare":
		compareIssues(ctx, client, config)
	default:
		fmt.Println("Usage: go run main.go [list-remote|list-local|compare|close-all-local] --state [state] --perPage [perPage] --save")
	}
}

func loadConfig() Config {
	err := godotenv.Load(".env")
	if err != nil {
		log.Fatal("Error loading .env file")
	}

	token := os.Getenv("GITHUB_TOKEN")
	if token == "" {
		log.Fatal("GITHUB_TOKEN environment variable not set")
	}

	state := flag.String("state", "open", "State of the issues")
	perPage := flag.Int("perPage", 100, "Number of issues per page")
	save := flag.Bool("save", false, "Save issues to a file")
	flag.Parse()

	return Config{
		State:   *state,
		PerPage: *perPage,
		Save:    *save,
	}
}

func createGitHubClient(ctx context.Context) *github.Client {
	token := os.Getenv("GITHUB_TOKEN")
	ts := oauth2.StaticTokenSource(&oauth2.Token{AccessToken: token})
	tc := oauth2.NewClient(ctx, ts)
	return github.NewClient(tc)
}

func listRemoteIssues(ctx context.Context, client *github.Client, config Config) []*github.Issue {
	opt := &github.IssueListByRepoOptions{
		State: config.State,
		ListOptions: github.ListOptions{
			PerPage: config.PerPage,
		},
	}

	var allIssues []*github.Issue
	for {
		issues, resp, err := client.Issues.ListByRepo(ctx, owner, repo, opt)
		if err != nil {
			log.Fatalf("Error fetching issues for repo %s/%s: %v", owner, repo, err)
		}
		allIssues = append(allIssues, issues...)
		if resp.NextPage == 0 {
			break
		}
		opt.Page = resp.NextPage
	}

	logIssues("Issues in the repository:", allIssues)

	if config.Save {
		saveIssuesToFile("remote_issues.json", allIssues)
	}

	return allIssues
}

func listLocalIssues(config Config) []Issue {
	files, err := filepath.Glob("../epics/*.yaml")
	if err != nil {
		log.Fatal(err)
	}

	var localIssues []Issue
	for _, file := range files {
		data, err := os.ReadFile(file)
		if err != nil {
			log.Fatal(err)
		}

		var issue Issue
		err = yaml.Unmarshal(data, &issue)
		if err != nil {
			log.Fatal(err)
		}

		localIssues = append(localIssues, flattenIssues(issue)...)
	}

	logIssues("Local issues:", localIssues)

	if config.Save {
		saveIssuesToFile("local_issues.json", localIssues)
	}

	return localIssues
}

func flattenIssues(issue Issue) []Issue {
	var issues []Issue
	issues = append(issues, issue)
	for _, subIssue := range issue.SubIssues {
		issues = append(issues, flattenIssues(subIssue)...)
	}
	return issues
}

func compareIssues(ctx context.Context, client *github.Client, config Config) {
	remoteIssues := listRemoteIssues(ctx, client, config)
	localIssues := listLocalIssues(config)

	var notFoundIssues []string
	for _, localIssue := range localIssues {
		if !issueExists(remoteIssues, localIssue.Title) {
			notFoundIssues = append(notFoundIssues, localIssue.Title)
		}
	}

	if len(notFoundIssues) > 0 {
		logIssues("Issues not found:", notFoundIssues)
	} else {
		fmt.Println("All issues found.")
	}

	if config.Save {
		saveIssuesToFile("not_found_issues.json", notFoundIssues)
	}
}

func issueExists(issues []*github.Issue, title string) bool {
	for _, issue := range issues {
		if *issue.Title == title {
			return true
		}
	}
	return false
}

func saveIssuesToFile(filename string, issues interface{}) {
	data, err := json.MarshalIndent(issues, "", "  ")
	if err != nil {
		log.Fatalf("Error marshalling issues: %v", err)
	}

	err = os.MkdirAll(filepath.Dir(filename), 0755)
	if err != nil {
		log.Fatalf("Error creating directories: %v", err)
	}

	err = os.WriteFile(filename, data, 0644)
	if err != nil {
		log.Fatalf("Error writing file: %v", err)
	}

	fmt.Printf("Issues saved to %s\n", filename)
}

func logIssues(message string, issues interface{}) {
	fmt.Println(message)
	switch v := issues.(type) {
	case []*github.Issue:
		for _, issue := range v {
			fmt.Printf("- %s\n", *issue.Title)
		}
	case []Issue:
		for _, issue := range v {
			fmt.Printf("- %s\n", issue.Title)
		}
	case []string:
		for _, issue := range v {
			fmt.Println(issue)
		}
	}
}
