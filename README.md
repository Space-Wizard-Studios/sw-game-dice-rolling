# DICE ROLL GAME

Este é o projeto para um jogo de turnos feito em C# na game engine Godot 4+. O jogo envolve evoluir personagens, gerenciar recursos, explorar masmorras, engajar-se em batalhas e progredir.

## Sumário

- [DICE ROLL GAME](#dice-roll-game)
  - [Sumário](#sumário)
  - [Estrutura de Pastas](#estrutura-de-pastas)
  - [Tecnologias e Frameworks](#tecnologias-e-frameworks)
  - [Instalação](#instalação)
    - [Pré-requisitos](#pré-requisitos)
    - [Passos para Instalação](#passos-para-instalação)
  - [Documentação](#documentação)
    - [Gerar a Documentação da API](#gerar-a-documentação-da-api)
    - [Executar Scripts do /docs](#executar-scripts-do-docs)

## Estrutura de Pastas

```txt
sw-game-dice-roll/          # repositório
├── addons/                 # bibliotecas third party
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

## Tecnologias e Frameworks

- **Godot Engine 4+**: Motor de jogo utilizado para desenvolver o projeto.
- **C#**: Linguagem de programação utilizada para a lógica do jogo.

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

## Documentação

### Gerar a Documentação da API

Para gerar a documentação da API utilizando o DocFX, siga os passos abaixo:

1. Certifique-se de ter o DocFX instalado. Você pode instalar o DocFX globalmente usando o comando:

   ```sh
   dotnet tool install -g docfx
   ```

2. No diretório raiz do projeto, execute o comando abaixo para gerar a documentação da API:

   ```sh
   docfx docfx.json
   ```

   A documentação será gerada na pasta `api`.

### Executar Scripts do /docs

Para executar os scripts definidos no arquivo `package.json` dentro do diretório `/docs`, siga os passos abaixo:

1. Navegue até o diretório `/docs`:

   ```sh
   cd docs
   ```

2. Execute o script desejado. Aqui estão alguns exemplos de scripts disponíveis:

   - Para iniciar o servidor de desenvolvimento do Docusaurus:

     ```sh
     npm run start
     ```

   - Para construir o site estático:

     ```sh
     npm run build
     ```

   - Para processar os arquivos da API:

     ```sh
     npm run process-api
     ```

   - Para servir o site estático localmente:

     ```sh
     npm run serve
     ```

Agora você está pronto para gerar a documentação da API e executar os scripts necessários para o desenvolvimento e manutenção da documentação do projeto.
