# DICE ROLL GAME

Este é o projeto para um jogo de turnos feito em C# na game engine Godot 4+. O jogo envolve evoluir personagens, gerenciar recursos, explorar masmorras, engajar-se em batalhas e progredir.

## Sumário

- [DICE ROLL GAME](#dice-roll-game)
  - [Sumário](#sumário)
  - [Estrutura de arquivos](#estrutura-de-arquivos)
    - [Arquivos do Projeto](#arquivos-do-projeto)
    - [Arquivos da Documentação](#arquivos-da-documentação)
  - [Tecnologias e Frameworks](#tecnologias-e-frameworks)
    - [Tecnologias do Jogo](#tecnologias-do-jogo)
    - [Tecnologias da Documentação](#tecnologias-da-documentação)
  - [Desenvolvimento do jogo](#desenvolvimento-do-jogo)
    - [Pré-requisitos](#pré-requisitos)
    - [Instalação do projeto](#instalação-do-projeto)
  - [Documentação](#documentação)
    - [Gerar a Documentação da API](#gerar-a-documentação-da-api)
    - [Executar Scripts do /docs](#executar-scripts-do-docs)

## Estrutura de arquivos

```powershell
.
├── docs                    # Documentação
└── src                     # Projeto
```

### Arquivos do Projeto

```powershell
./src/
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

### Arquivos da Documentação

```powershell
./docs/
├── api/                    #
└── src/                    #
 ├── components/            #
 ├── css/                   #
 └── pages/                 #

```

## Tecnologias e Frameworks

### Tecnologias do Jogo

- **Godot Engine 4+**: Motor de jogo utilizado para desenvolver o projeto.
- **C#**: Linguagem de programação utilizada para a lógica do jogo.

### Tecnologias da Documentação

- **DocFX**: Utilizado para gerar as referências de API do projeto .NET em Markdown (md).
- **Docusaurus**: Utilizado para construir o site estático a partir de arquivos Markdown, incluindo a API.
- **StatiCrypt**: Utilizado para encriptar os arquivos construídos, protegendo-os com uma senha.
- **Firebase**: Utilizado para servir a documentação no endereço [https://sw-game-dice-roll-docs.web.app](https://sw-game-dice-roll-docs.web.app).

---

## Desenvolvimento do jogo

Para configurar o projeto localmente, siga os passos abaixo:

### Pré-requisitos

1. **Godot Engine 4+**: Certifique-se de ter o Godot Engine 4 ou superior instalado. Você pode baixar a versão mais recente do Godot [aqui](https://godotengine.org/download).

2. **.NET SDK**: O projeto utiliza C#, então você precisará do .NET SDK instalado. Você pode baixar o .NET SDK [aqui](https://dotnet.microsoft.com/download).

### Instalação do projeto

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

---

## Documentação

### Gerar a Documentação da API

Para gerar a documentação da API utilizando o DocFX, siga os passos abaixo:

1. Certifique-se de ter o DocFX instalado. Você pode instalar o DocFX globalmente usando o comando:

   ```sh
   dotnet tool install -g docfx
   ```

2. No diretório **raiz** do projeto, execute o comando abaixo para gerar a documentação da API:

   ```sh
   docfx
   ```

   A documentação será gerada na pasta `docs/api`.

### Executar Scripts do /docs

Para executar os scripts definidos no arquivo `package.json` dentro do diretório `/docs`, siga os passos abaixo:

1. Navegue até o diretório `/docs`:

   ```sh
   cd docs
   ```

2. Execute o script desejado:

   - Para processar os arquivos da API:

     ```sh
     npm run process-api
     ```

     O comando irá executar o código `node processApiFiles.js`, que trata os arquivos gerados pelo DocFX de acordo com [processApiFiles.js](docs/processApiFiles.js)

   - Para iniciar o servidor de desenvolvimento ou construir o site estático do Docusaurus:

     ```sh
     npm run start
     ```

    ou

     ```sh
     npm run build
     ```

   - Para servir o site estático localmente (preview):

     ```sh
     npm run serve
     ```

Agora você está pronto para gerar a documentação da API e executar os scripts necessários para o desenvolvimento e manutenção da documentação do projeto.
