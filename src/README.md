# DICE ROLLING GAME

## Sumário

- [DICE ROLLING GAME](#dice-rolling-game)
  - [Sumário](#sumário)
    - [Tecnologias do Jogo](#tecnologias-do-jogo)
    - [Estrutura da framework](#estrutura-da-framework)
  - [Ambiente de Desenvolvimento](#ambiente-de-desenvolvimento)
    - [Pré-requisitos](#pré-requisitos)
    - [Instalação do projeto](#instalação-do-projeto)

### Tecnologias do Jogo

- **Godot Engine 4+**: Motor de jogo utilizado para desenvolver o projeto.
- **C#**: Linguagem de programação utilizada para a lógica do jogo.

### Estrutura da framework

```powershell
src/
├── addons/                 # bibliotecas third party e editor plugins
├── assets/                 # assets como sprites, sons, texturas e respectivos arquivos de configuração
├── components/             # nodes a serem exibidos nas cenas e respectivos arquivos de
├── core/                   # core game logic and systems
│ ├── managers/             # game managers
│ ├── stores/               # singletons
│ └── ui/                   # UI-related scripts
├── models/                 # modelos de objetos
│ └── [DOMAIN]              #
│   └── [RESOURCES]         #
└── scenes/                 # cenas do jogo
```

## Ambiente de Desenvolvimento

Para começar a desenvolver na framework, siga as instruções abaixo:

### Pré-requisitos

1. **Godot Engine 4+**: Você pode baixar a versão mais recente do Godot [aqui](https://godotengine.org/download).

2. **.NET SDK**: O projeto utiliza C#, então você precisará do .NET SDK instalado. Você pode baixar o .NET SDK [aqui](https://dotnet.microsoft.com/download).

### Instalação do projeto

1. Abra o projeto no Godot Engine:

   - Inicie o Godot Engine.
   - Clique em "Import" e navegue até o diretório onde você clonou o repositório.
   - Selecione o arquivo `project.godot` e clique em "Open".

2. Certifique-se de que o Godot está configurado para usar o .NET SDK:

   - Vá para `Editor` > `Editor Settings`.
   - No painel esquerdo, expanda `Mono` e selecione `Editor`.
   - Verifique se o caminho do `Mono Build` está apontando para o local correto do .NET SDK.

3. Execute o projeto:
   - Com o projeto aberto no Godot, clique no botão de "Play" (ícone de triângulo) na barra superior para executar o jogo.

Agora você deve estar pronto para começar a desenvolver e testar o jogo localmente.
