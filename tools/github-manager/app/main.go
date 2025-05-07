package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strings"

	"github.com/google/go-github/github"
	"github.com/joho/godotenv"
	"golang.org/x/oauth2"
	"gopkg.in/yaml.v2"

	flag "github.com/spf13/pflag"
)

const (
	ownerEnvKey = "GITHUB_OWNER"
	repoEnvKey  = "GITHUB_REPO"
)

var (
	owner string
	repo  string
)

func init() {
	// Attempt to load .env file. If it fails, variables might still be set in the environment.
	if err := godotenv.Load(".env"); err != nil {
		log.Printf("Warning: Could not load .env file: %v. Relying on environment variables if set.", err)
	}

	owner = os.Getenv(ownerEnvKey)
	repo = os.Getenv(repoEnvKey)

	if owner == "" || repo == "" {
		log.Fatalf("Environment variables %s and %s must be set (either in .env file or system environment)", ownerEnvKey, repoEnvKey)
	}
}

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
		fmt.Println("Usage: go run main.go [list-remote|list-local|compare|close-all-local] --state [open | closed | all] --perPage [perPage] --save")
	}
}

func loadConfig() Config {
	token := os.Getenv("GITHUB_TOKEN")
	if token == "" {
		log.Fatalf("GITHUB_TOKEN environment variable not set (either in .env file or system environment)")
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

	logIssues("Issues in the repository:", config.State, allIssues)

	if config.Save {
		saveIssuesToFile("results/remote_issues.json", allIssues)
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

		if config.State == "all" || issue.State == config.State {
			localIssues = append(localIssues, issue)
		}
	}

	logIssues("Local issues:", config.State, localIssues)

	if config.Save {
		saveIssuesToFile("results/local_issues.json", localIssues)
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
	localIssuesRoots := listLocalIssues(config)

	var allLocalIssuesFlat []Issue
	for _, rootIssue := range localIssuesRoots {
		allLocalIssuesFlat = append(allLocalIssuesFlat, flattenIssues(rootIssue)...)
	}

	var notFoundIssues []string
	for _, localIssue := range allLocalIssuesFlat {
		if config.State == "all" || localIssue.State == config.State {
			if !issueExists(remoteIssues, localIssue.Title) {
				notFoundIssues = append(notFoundIssues, localIssue.Title)
			}
		}
	}

	if len(notFoundIssues) > 0 {
		logIssues("Issues not found:", config.State, notFoundIssues)
	} else {
		fmt.Println("All issues found.")
	}

	if config.Save {
		saveIssuesToFile("results/not_found_issues.json", notFoundIssues)
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

func logIssues(message string, state string, issues interface{}) {
	fmt.Printf("%s (State: %s)\n", message, state)
	switch v := issues.(type) {
	case []*github.Issue:
		for _, issue := range v {
			fmt.Printf("- %s\n", *issue.Title)
		}
	case []Issue:
		for _, issue := range v {
			printIssue(issue, 0)
		}
	case []string:
		for _, issue := range v {
			fmt.Println(issue)
		}
	}
}

func printIssue(issue Issue, level int) {
	indent := strings.Repeat("    ", level)
	fmt.Printf("%s- %s\n", indent, issue.Title)
	for _, subIssue := range issue.SubIssues {
		printIssue(subIssue, level+1)
	}
}
