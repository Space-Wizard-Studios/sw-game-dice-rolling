# GitHub Project Manager

Essa é uma ferramenta que eu criei em Go para facilitar a manutenção do projeto no GitHub.

Atualmente a única utilidade é poder escrever as issues em arquivos yaml (melhor visualização) para depois comparar com o projeto remoto usando a lib [go-github](https://github.com/google/go-github).

## Installation

```cmd
cd tools/github-manager/app
go mod download
```

### Usage

```cmd
# List remote issues from GitHub
go run main.go list-remote --state open

# List local issues from YAML files
go run main.go list-local --state all

# Compare local and remote issues
go run main.go compare --state open --save
```

## Propriedades das issues no GitHub

```yaml
title:
description:
assignees:
  - assignee:
type: "🐛 Bug | ⭐ Epic | 📖 Feature / Story | 📝 Task | 🔨 Sub-task"
labels:
state: "open | closed"
status: "Backlog | Ready | In progress | In review | Done"
priority: "💥 P0 - Critical | 🔥 P1 - High | ❗P2 - Medium | 🧊 P3 - Low"
size: "🐋 X-Large | 🦑 Large | 🐂 Medium | 🐇 Small | 🦔 Tiny"
reviewers:
  - reviewer:
start-date:
end-date:
linked-pull-requests:
iteration:
sub-issues:
```

## Exemplo de uma issue

```yaml
title: "Epic 1"
type: "⭐ Epic"
state: "open"
sub-issues:
  - title: "Story 1.1"
    type: "📖 Feature / Story"
    state: "open"
    sub-issues:
      - title: "Task 1.1.a"
        type: "📝 Task"
        state: "open"
        sub-issues:
          - title: "Subtask 1.1.a.1"
            type: "🔨 Sub-task"
            state: "open"
```
