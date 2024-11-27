# DICE ROLL GAME

Este é o projeto para um jogo de turnos feito em C# na game engine Godot 4+. O jogo envolve evoluir personagens, gerenciar recursos, explorar masmorras, engajar-se em batalhas e progredir.

## Sumário

- [DICE ROLL GAME](#dice-roll-game)
  - [Sumário](#sumário)
  - [Estrutura de Arquivos](#estrutura-de-arquivos)
  - [Conceito Geral](#conceito-geral)
    - [Transição entre cenas](#transição-entre-cenas)
    - [Gameplay](#gameplay)
  - [Instalação](#instalação)
    - [Pré-requisitos](#pré-requisitos)
    - [Passos para Instalação](#passos-para-instalação)
  - [Tecnologias e Frameworks](#tecnologias-e-frameworks)

## Estrutura de Arquivos

```txt
sw-game-dice-roll/          # root
├── addons/                 # third party libs
├── assets/                 # assets como sprites, sons, texturas e respectivos arquivos de configuração 
├── components/             # nodes a serem exibidos e manipulados nas cenas
├── models/                 # modelos de objetos (tipagem) 
├── playground/             # testes que não serão utilizados na build do projeto
├── resources               # dicionários de dados que implementam os modelos
├── scenes/                 # cenas do jogo
└── scripts                 # scripts do gameplay loop
    ├── managers
    ├── scenes
    └── ui
```

## Conceito Geral

### Transição entre cenas

O jogo possui dois managers responsáveis pelo controle dos estados do jogo.

- **[MenuTransitionManager](scripts/managers/MenuTransitionManager.cs)**: Gerencia as transições entre os menus do jogo.
- **[GameplayTransitionManager](scripts/managers/GameplayTransitionManager.cs)**: Gerencia as transições durante a gameplay.

### Gameplay

A gameplay é dividida da seguinte maneira:

- **Lobby**: Área onde os jogadores podem preparar seus personagens e equipamentos antes de entrar na dungeon.
- **Gameplay**: Ação principal do jogo onde os jogadores exploram e enfrentam desafios.
- **Dungeon**: A área de exploração e combate.
  - **Battle**: Encontros de combate dentro da dungeon.
    - **Battle Setup**: Preparação para a batalha, incluindo a geração de inimigos.
    - **Turns**: Turnos de combate onde os jogadores e inimigos realizam ações.
    - **Battle End**: Conclusão da batalha, determinando vitória ou derrota.

## Instalação

Para configurar o projeto localmente, siga os passos abaixo:

### Pré-requisitos

1. **Godot Engine 4+**: Certifique-se de ter o Godot Engine 4 ou superior instalado. Você pode baixar a versão mais recente do Godot [aqui](https://godotengine.org/download).

2. **.NET SDK**: O projeto utiliza C#, então você precisará do .NET SDK instalado. Você pode baixar o .NET SDK [aqui](https://dotnet.microsoft.com/download).

### Passos para Instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/Space-Wizard-Studios/sw-game-dice-roll.git
    ```

2. Abra o projeto no Godot Engine:
    - Inicie o Godot Engine.
    - Clique em "Import" e navegue até o diretório onde você clonou o repositório.
    - Selecione o arquivo `project.godot` e clique em "Open".

3. Certifique-se de que o Godot está configurado para usar o .NET SDK:
    - Vá para `Editor` > `Editor Settings`.
    - No painel esquerdo, expanda `Mono` e selecione `Editor`.
    - Verifique se o caminho do `Mono Build` está apontando para o local correto do .NET SDK.

4. Execute o projeto:
    - Com o projeto aberto no Godot, clique no botão de "Play" (ícone de triângulo) na barra superior para executar o jogo.

Agora você deve estar pronto para começar a desenvolver e testar o jogo localmente.

## Tecnologias e Frameworks

- **Godot Engine 4+**: Motor de jogo utilizado para desenvolver o projeto.
- **C#**: Linguagem de programação utilizada para a lógica do jogo.
