# DICE ROLLING GAME

👋 Olá!

Nós somos a [**Space Wizard Studios**](https://spacewiz.dev/) e este é o repositório do nosso projeto chamado **Dice Rolling Game** (nome temporário).

> [!WARNING]  
> **Aviso:** Este projeto está em desenvolvimento (e em uma fase bem inicial!) e, por isso, não recomendamos para uso em produção.
> Por isso, use esse projeto apenas como um estudo de caso, dar suas sugestões ou simplesmente um lugar para discutirmos suas ideias.

---

## Sobre

Este é um projeto de código aberto para o desenvolvimento de um [Roguelike](https://en.wikipedia.org/wiki/Roguelike), multiplayer e com batalha por turnos feito em C# na [Godot Engine](https://godotengine.org/).

O objetivo é criar uma **Framework** modular e aberta que permita a qualquer desenvolvedor, artista, estudante ou curiosos a [clonar, modificar ou fazer um fork do código base](CONTRIBUTING.md).

A premissa deste projeto é que tanto o design da **Framework** quanto do **Jogo** serão guiados pela comunidade, porém, a produção dos assets (áudios, imagens e outros recursos) será realizada de forma independente e o jogo final será publicado em plataformas de distribuição como Steam, itch.io, etc. (ainda a ser definido).

```mermaid
flowchart LR
    A(🤝<br>**Comunidade**) --> B@{ shape: diamond, label: "📦<br>**Framework**" } --> C(👨‍🚀<br>**SpaceWiz**) --> D(🎨<br>Assets)

    B -->E(🎮<br>Jogo de Protótipo )
    D -->F(👨‍🚀🎮<br>Jogo da SpaceWiz )

    style A fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style B fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style C fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
```

<details>

<summary>Nossa política de código aberto</summary>

### Por que código aberto?

Acreditamos que a colaboração e a transparência são essenciais para o desenvolvimento de softwares de qualidade. Esses sempre foram nossos valores em projetos desenvolvidos para clientes e queremos manter isso em nosso próprio projeto.

Por isso, decidimos desde o começo em manter o código do nosso projeto aberto para que qualquer pessoa possa contribuir, aprender, ensinar e se divertir com a gente.

### E por que os assets não são abertos?

Queremos manter a qualidade, coerência artística e, também, desenvolver a nossa própria visão do jogo. Por isso a produção dos assets será feita de forma independente (mas sempre recebendo feedbacks!).

Isso significa que os áudios, imagens e outros recursos que não sejam parte do protótipo **não estarão disponíveis neste repositório**.

</details>

---

## Sumário

- [DICE ROLLING GAME](#dice-rolling-game)
  - [Sobre](#sobre)
    - [Por que código aberto?](#por-que-código-aberto)
    - [E por que os assets não são abertos?](#e-por-que-os-assets-não-são-abertos)
  - [Sumário](#sumário)
  - [Estrutura de arquivos](#estrutura-de-arquivos)
    - [Estrutura do jogo](#estrutura-do-jogo)
    - [Estrutura da documentação](#estrutura-da-documentação)
  - [Tecnologias e Frameworks](#tecnologias-e-frameworks)
    - [Tecnologias do Jogo](#tecnologias-do-jogo)
    - [Tecnologias da Documentação](#tecnologias-da-documentação)
  - [Ambiente de Desenvolvimento](#ambiente-de-desenvolvimento)
    - [Pré-requisitos](#pré-requisitos)
    - [Instalação do projeto](#instalação-do-projeto)
  - [Documentação](#documentação)
    - [Gerar a Documentação da API](#gerar-a-documentação-da-api)
    - [Executar Scripts do /docs](#executar-scripts-do-docs)

---

## Estrutura de arquivos

```powershell
.
├── docs                    # Documentação
└── src                     # Projeto
```

### Estrutura do jogo

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

### Estrutura da documentação

```powershell
docs/
├── api/                    # Arquivos gerados pelo DocFX a partir do projeto C#
├── content/                # Conteúdo da documentação em Markdown
│ ├── api/                  # Arquivos do DocFX processados para funcionar no DocFX
│ ├── architecture/         # Arquivos relacionados à arquitetura do projeto
│ ├── game_design/          # Arquivos relacionados ao design do jogo
│ ├── tutorials/            # Tutoriais e guias da Framework
├── public/                 # Assets estáticos (imagens, vídeos, etc.)
│ ├── img/                  # Imagens
│ └── game_design/          # Arquivos relacionados ao design do jogo
└── src/                    # Projeto do Docusaurus
  ├── components/            # Componentes React
  ├── css/                   # Estilos CSS
  └── pages/                 # Páginas do site

```

---

## Tecnologias e Frameworks

### Tecnologias do Jogo

- **Godot Engine 4+**: Motor de jogo utilizado para desenvolver o projeto.
- **C#**: Linguagem de programação utilizada para a lógica do jogo.

### Tecnologias da Documentação

- **DocFX**: Utilizado para gerar as referências de API do projeto .NET em Markdown (md).
- **Docusaurus**: Utilizado para construir o site estático a partir de arquivos Markdown, incluindo a API.

---

## Ambiente de Desenvolvimento

Para começar a desenvolver o jogo, siga as instruções abaixo:

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
