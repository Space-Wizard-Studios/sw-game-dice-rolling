# Protótipo

Este projeto é um protótipo para um jogo de turnos construído usando Solid.js e Astro. O jogo envolve gerenciar personagens, engajar-se em batalhas e navegar por diferentes cenas do jogo.

## Sumário

- [Protótipo](#protótipo)
  - [Sumário](#sumário)
  - [Estrutura de arquivos](#estrutura-de-arquivos)
  - [Conceito Geral](#conceito-geral)
    - [Principais componentes](#principais-componentes)
  - [Instalação e Desenvolvimento](#instalação-e-desenvolvimento)
  - [Play Test](#play-test)
  - [Tecnologias e Frameworks](#tecnologias-e-frameworks)
  - [Contribuindo](#contribuindo)
  - [Licença](#licença)

## Estrutura de arquivos

```txt
game-prototype/
├── public/                 # Ativos estáticos
├── src/                    # Arquivos fonte  
│   ├── components/         # Componentes React
│   │   ├── Board/          # Componente de Tabuleiro
│   │   ├── Character/      # Componente de Personagem
│   │   ├── Dialogue/       # Componente de Diálogo
│   │   ├── Dice/           # Componente de Dados
│   │   ├── ItemSelection/  # Componente de Seleção de Itens
│   │   ├── Scenes/         # Componentes de Cena
│   │   └── ui/             # Componentes de UI                        @shadcn-solid
│   ├── controllers/        # Controladores
│   ├── helpers/            # Funções auxiliares
│   ├── layouts/            # Componentes de Layout                    @astro
│   ├── models/             # Modelos de dados
│   ├── pages/              # Componentes de Página                    @astro
│   ├── stores/             # Armazenamento de estado
│   └── styles/             # Estilos CSS
├── astro.config.mjs        # Configuração do Astro
├── package.json            # Configuração do pacote NPM
├── tailwind.config.cjs     # Configuração do Tailwind CSS
└── README.md               # Documentação do projeto
```

## Conceito Geral

Este é um protótipo para um jogo de estratégia onde os jogadores gerenciam personagens e se envolvem em batalhas.

O jogo possui 3 cenas distintas que são controladas por seus respectivos controladores:

- MainMenu
- Gameplay
- Gameover

A gameplay acontece através de estados:

- **Introduction**: introdução e apresentação do jogo;
- **Initial Setup**: preparação dos personagens e conjunto de dados do jogador;
- **Battle**: batalha contra inimigos, que acontece em etapas:
  - **Battle Setup**: gera inimigos e condições da batalha;
  - **Battle Turns**: loop de turnos
    - Se ainda há inimigos vivos, inicia um novo turno;
    - Se não há mais inimigos vivos, segue para o resultado da batalha (vitória);
    - Se todos os personagens do jogador foram derrotados, segue para o resultado da batalha (derrota);
  - **Battle End**: apresenta o resultado da batalha e inicia a cena de Game Over se o jogador foi derrotado.

### Principais componentes

- **Board**: tabuleiro onde a gameplay acontece;
- **Character**: ficha dos personagens e interação com seus componentes;
- **Dialogue**: diálogos no jogo;
- **Dice**: dados que são atribuídos à personagens ou movidos ao inventário;
- **Item Selection**: modal que permite ao jogador escolher entre opções;
- **Scenes**: gerencia diferentes cenas do jogo.

## Instalação e Desenvolvimento

Instale os pacotes e execute o ambiente de desenvolvimento.

```shell
npm i
npm run dev
```

## Play Test

Para testes em uma cena controlada, inicialize o server com `-- --test` como argumento.
Se necessário, edite o arquivo [TestRenderer.tsx](/game-prototype/src/components/TestRenderer.tsx) para inicializar o teste como desejar.

```shell
npm run dev -- --test
```

## Tecnologias e Frameworks

- **Solid**: Para construir todo o jogo no client.
- **Astro**: Para geração do site estático.
- **Tailwind CSS**: Para estilizar toda a aplicação.

## Contribuindo

Sinta-se à vontade para fazer um fork deste projeto e enviar pull requests. Para grandes mudanças, por favor, abra uma issue primeiro para discutir o que você gostaria de mudar.

## Licença

Este projeto está licenciado sob a Licença MIT.
