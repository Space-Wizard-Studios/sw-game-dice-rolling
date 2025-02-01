package main

import (
	"context"
	"fmt"
	"io/ioutil"
	"log"
	"os"
	"path/filepath"

	"github.com/google/go-github/github"
	"github.com/joho/godotenv"
	"golang.org/x/oauth2"
	"gopkg.in/yaml.v2"
)

type Issue struct {
	Title     string  `yaml:"title"`
	Type      string  `yaml:"type"`
	SubIssues []Issue `yaml:"sub-issues"`
}

func main() {
	// Carregar variáveis de ambiente do arquivo .env
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

	// Listar todas as issues do repositório uma vez (abertas e fechadas)
	owner := "Space-Wizard-Studios"
	repo := "sw-game-dice-roll"

	opt := &github.IssueListByRepoOptions{
		State: "open",
		ListOptions: github.ListOptions{
			PerPage: 100,
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

	files, err := filepath.Glob("../epics/*.yaml")
	if err != nil {
		log.Fatal(err)
	}

	var notFoundIssues []string

	for _, file := range files {
		data, err := ioutil.ReadFile(file)
		if err != nil {
			log.Fatal(err)
		}

		var issue Issue
		err = yaml.Unmarshal(data, &issue)
		if err != nil {
			log.Fatal(err)
		}

		notFoundIssues = append(notFoundIssues, checkIssue(issue, allIssues)...)
	}

	if len(notFoundIssues) > 0 {
		fmt.Println("Issues not found:")
		for _, issue := range notFoundIssues {
			fmt.Println(issue)
		}
	} else {
		fmt.Println("All issues found.")
	}
}

func checkIssue(issue Issue, issues []*github.Issue) []string {
	fmt.Printf("Checking issue: %s\n", issue.Title)

	issueExists := false
	var notFoundIssues []string
	for _, ghIssue := range issues {
		if *ghIssue.Title == issue.Title {
			issueExists = true
			break
		}
	}

	if !issueExists {
		notFoundIssues = append(notFoundIssues, issue.Title)
	}

	for _, subIssue := range issue.SubIssues {
		notFoundIssues = append(notFoundIssues, checkIssue(subIssue, issues)...)
	}

	return notFoundIssues
}
