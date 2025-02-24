# DICE ROLLING FRAMEWORK

[![GitHub License](https://img.shields.io/github/license/Space-Wizard-Studios/sw-game-dice-rolling)](https://github.com/Space-Wizard-Studios/sw-game-dice-rolling/blob/main/LICENSE)
![GitHub commit activity](https://img.shields.io/github/commit-activity/w/Space-Wizard-Studios/sw-game-dice-rolling)

[![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/Space-Wizard-Studios_sw-game-dice-rolling?server=https%3A%2F%2Fsonarcloud.io)](https://sonarcloud.io/summary/new_code?id=Space-Wizard-Studios_sw-game-dice-rolling)
[![CodeRabbit Pull Request Reviews](https://img.shields.io/coderabbit/prs/github/Space-Wizard-Studios/sw-game-dice-rolling)](https://app.coderabbit.ai/login?grsf=danilo-nob-yhhdp8)

👋 Olá!

Nós somos a [**Space Wizard Studios**](https://spacewiz.dev/) e este é o repositório do nosso projeto chamado **Dice Rolling Framework** (nome temporário).

> [!WARNING]  
> **Aviso:** Este projeto está em desenvolvimento (em uma fase **bem inicial**!) e, por isso, não recomendamos para uso em produção.
> Por isso, use esse projeto apenas como um estudo de caso, para dar suas sugestões ou simplesmente como um lugar para discutirmos suas ideias.

---

## Sumário

- [DICE ROLLING FRAMEWORK](#dice-rolling-framework)
  - [Sumário](#sumário)
  - [Sobre](#sobre)
    - [Por que código aberto?](#por-que-código-aberto)
    - [E por que os assets não são abertos?](#e-por-que-os-assets-não-são-abertos)
  - [Links](#links)
  - [Estrutura de arquivos](#estrutura-de-arquivos)
  - [Contribuições e Código de Conduta](#contribuições-e-código-de-conduta)
  - [Licença](#licença)

---

## Sobre

Este é um projeto de código aberto para o desenvolvimento de uma framework para criação de jogos no estilo [Roguelike](https://en.wikipedia.org/wiki/Roguelike) com batalha por turnos, feita em C# na [Godot Engine](https://godotengine.org/).

Os objetivos são:

1. Criar uma **Framework** modular e aberta que permita a quaisquer desenvolvedores, artistas, estudantes ou curiosos a [clonarem e fazer alterações no código base](CONTRIBUTING.md).

2. Desenvolver um **Protótipo** que possa ser usado como base para outros jogos, mods e afins.

3. Criar um **Jogo completo** da **Space Wizard Studios** que utilize a **Framework** e que possa ser publicado em plataformas de distribuição.

A premissa deste projeto é que tanto o design da **Framework** quanto do **Jogo** serão guiados pela comunidade, porém, a produção dos assets usados no jogo (áudios, imagens etc.) será realizada de forma independente e o jogo final será publicado em plataformas de distribuição como Steam, itch.io, etc. (ainda a ser definido).

```mermaid
flowchart LR
    A(🤝<br>**Comunidade**) --> B@{ shape: diamond, label: "📦<br>**Framework**" } --> C(👨‍🚀<br>**SpaceWiz**) --> D(🎨<br>Assets)

    B -->E(🎮<br>Jogo de Protótipo )
    D -->F(👨‍🚀🎮<br>Jogo da SpaceWiz )

    style A fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style B fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style C fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
```

<!-- markdownlint-disable MD033 -->

<details>

<summary>Nossa política de código aberto</summary>

### Por que código aberto?

Acreditamos que a colaboração e a transparência são essenciais para o desenvolvimento de softwares de qualidade. Esses sempre foram nossos valores em projetos desenvolvidos para clientes e queremos manter isso em nosso próprio projeto.

Por isso, decidimos desde o começo em manter o código do nosso projeto aberto para que qualquer pessoa possa contribuir, aprender, ensinar e se divertir com a gente.

### E por que os assets não são abertos?

Queremos manter a qualidade, coerência artística e, também, desenvolver a nossa própria visão do jogo. Por isso a produção dos assets será feita de forma independente (mas sempre recebendo feedbacks!).

Isso significa que os áudios, imagens e outros recursos que não sejam parte do protótipo **não estarão disponíveis neste repositório**.

</details>

<!-- markdownlint-enable MD033 -->

---

## Links

[Documentação](https://space-wizard-studios.github.io/sw-game-dice-rolling/) (em construção)

---

## Estrutura de arquivos

```powershell
.
├── docs                    # Documentação no Docusaurus
└── src                     # Projeto na Godot Engine
```

Para mais detalhes, veja os arquivos da [framework](src/README.md) ou da [documentação](docs/README.md).

## Contribuições e Código de Conduta

Se você deseja contribuir com o projeto, leia o nosso [Guia de Contribuição](CONTRIBUTING.md).

Este projeto e todos os participantes são regidos pelo nosso [Código de Conduta](CODE_OF_CONDUCT.md). Ao participar, você deve seguir este código.

## Licença

Todo o código deste projeto é licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

Os assets são licenciados sob a licença [CC BY-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0) a menos que especificado de outra forma.
