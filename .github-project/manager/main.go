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

func main() {
	// Load environment variables from .env file
	err := godotenv.Load(".env")
	if err != nil {
		log.Fatal("Error loading .env file")
	}

	token := os.Getenv("GITHUB_TOKEN")
	if token == "" {
		log.Fatal("GITHUB_TOKEN environment variable not set")
	}

	ctx := context.Background()
	ts := oauth2.StaticTokenSource(
		&oauth2.Token{AccessToken: token},
	)
	tc := oauth2.NewClient(ctx, ts)

	client := github.NewClient(tc)

	// Define command-line flags
	state := flag.String("state", "open", "State of the issues")
	perPage := flag.Int("perPage", 100, "Number of issues per page")
	save := flag.Bool("save", false, "Save issues to a file")

	// Parse command-line flags
	flag.Parse()

	// Debugging statements to check the values of state and perPage
	fmt.Printf("State: %s\n", *state)
	fmt.Printf("PerPage: %d\n", *perPage)
	fmt.Printf("Save: %t\n", *save)

	if len(flag.Args()) > 0 {
		switch flag.Args()[0] {
		case "list-remote":
			listRemoteIssues(ctx, client, *state, *perPage, *save)
		case "list-local":
			listLocalIssues(*save)
		case "compare":
			compareIssues(ctx, client, *state, *perPage, *save)
		default:
			fmt.Println("Usage: go run main.go [list-remote|list-local|compare|close-all-local] --state [state] --perPage [perPage] --save")
		}
	} else {
		fmt.Println("Usage: go run main.go [list-remote|list-local|compare|close-all-local] --state [state] --perPage [perPage] --save")
	}
}

func listRemoteIssues(ctx context.Context, client *github.Client, state string, perPage int, save bool) []*github.Issue {
	owner := "Space-Wizard-Studios"
	repo := "sw-game-dice-roll"

	opt := &github.IssueListByRepoOptions{
		State: state,
		ListOptions: github.ListOptions{
			PerPage: perPage,
		},
	}

	var allIssues []*github.Issue
	for {
		issues, resp, err := client.Issues.ListByRepo(ctx, owner, repo, opt)
		if err != nil {
			log.Printf("Error fetching issues for repo %s/%s: %v", owner, repo, err)
			log.Fatal(err)
		}
		allIssues = append(allIssues, issues...)
		if resp.NextPage == 0 {
			break
		}
		opt.Page = resp.NextPage
	}

	// Log all issues in the repository
	fmt.Println("Issues in the repository:")
	for _, ghIssue := range allIssues {
		fmt.Printf("- %s\n", *ghIssue.Title)
	}

	if save {
		saveIssuesToFile("issues/remote_issues.json", allIssues)
	}

	return allIssues
}

func listLocalIssues(save bool) []Issue {
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

	// Log all local issues
	fmt.Println("Local issues:")
	for _, issue := range localIssues {
		fmt.Printf("- %s\n", issue.Title)
	}

	if save {
		saveIssuesToFile("issues/local_issues.json", localIssues)
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

func compareIssues(ctx context.Context, client *github.Client, state string, perPage int, save bool) {
	remoteIssues := listRemoteIssues(ctx, client, state, perPage, false)
	localIssues := listLocalIssues(false)

	var notFoundIssues []string

	for _, localIssue := range localIssues {
		issueExists := false
		for _, remoteIssue := range remoteIssues {
			if *remoteIssue.Title == localIssue.Title {
				issueExists = true
				break
			}
		}
		if !issueExists {
			notFoundIssues = append(notFoundIssues, localIssue.Title)
		}
	}

	if len(notFoundIssues) > 0 {
		fmt.Println("Issues not found:")
		for _, issue := range notFoundIssues {
			fmt.Println(issue)
		}
	} else {
		fmt.Println("All issues found.")
	}

	if save {
		saveIssuesToFile("issues/not_found_issues.json", notFoundIssues)
	}
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
