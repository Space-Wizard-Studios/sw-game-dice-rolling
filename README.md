# DICE ROLL GAME

Este é o projeto para um jogo de turnos feito em C# na game engine Godot 4+. O jogo envolve evoluir personagens, gerenciar recursos, explorar masmorras, engajar-se em batalhas e progredir.

## Sumário

- [DICE ROLL GAME](#dice-roll-game)
  - [Sumário](#sumário)
  - [Estrutura de Pastas](#estrutura-de-pastas)
  - [Conceito Geral](#conceito-geral)
    - [Transição entre cenas](#transição-entre-cenas)
    - [Gameplay](#gameplay)
      - [Lobby](#lobby)
      - [Dungeon](#dungeon)
      - [Batalha](#batalha)
  - [Instalação](#instalação)
    - [Pré-requisitos](#pré-requisitos)
    - [Passos para Instalação](#passos-para-instalação)
  - [Tecnologias e Frameworks](#tecnologias-e-frameworks)

## Estrutura de Pastas

```txt
sw-game-dice-roll/          # root
├── addons/                 # third party libs
├── assets/                 # assets como sprites, sons, texturas e respectivos arquivos de configuração
├── components/             # nodes a serem exibidos nas cenas
├── core/                   # core game logic and systems
│ ├── managers/             # game managers
│ ├── scenes/               # scene-specific scripts
│ ├── stores/               # singletons
│ └── ui/                   # UI-related scripts
├── models/                 # modelos de objetos
│ └── [DOMAIN]              #
│   └── [RESOURCES]         #
├── scenes/                 # cenas do jogo
└── scripts/                # additional scripts (if needed)
```

## Conceito Geral

As principais mecânicas do jogo giram em torno da manutenção de recursos para que os personagens tenham ações disponíveis nos combates.

### Transição entre cenas

O jogo possui dois managers responsáveis pelo controle dos estados do jogo.

- **[MenuTransitionManager](scripts/managers/MenuTransitionManager.cs)**: Gerencia as transições entre os menus do jogo.
- **[GameplayTransitionManager](scripts/managers/GameplayTransitionManager.cs)**: Gerencia as transições durante a gameplay.

### Gameplay

A gameplay é dividida da seguinte maneira:

- **Lobby**: Área onde os jogadores podem preparar seus personagens e equipamentos antes de entrar na dungeon.
- **Dungeon**: A área de exploração e combate.
- **Battle**: Encontros de combate dentro da dungeon.
  - **Battle Setup**: Preparação para a batalha, incluindo a geração de inimigos.
  - **Turns**: Turnos de combate onde os jogadores e inimigos realizam ações.
  - **Battle End**: Conclusão da batalha, determinando vitória ou derrota.

#### Lobby

O lobby é a "cidade principal" do jogo, onde o jogador pode realizar diversas atividades essenciais para a preparação de suas aventuras. No lobby, o jogador pode, por exemplo:

- Recrutar Personagens: Adicionar novos membros à equipe.
- Treinar Personagens: Melhorar as habilidades e atributos dos personagens.
- Equipar Personagens: Adquirir e equipar armas, armaduras e outros itens.
- Curar Personagens: Recuperar a saúde dos personagens após batalhas.
- Comprar Itens: Adquirir itens úteis para a exploração e combate.
- Modificar Dados de Mana: Ajustar os dados de mana que serão utilizados nas batalhas.

#### Dungeon

A dungeon é a cena que representa a exploração da masmorra. Nela, o jogador escolhe caminhos e avança por pontos específicos, onde pode ocorrer uma variedade de interações, como:

- Acampamento: Encontrar um local seguro para descansar e recuperar recursos.
- Batalhas contra inimigos regulares.
- Batalhas contra de elite (inimigos mais fortes e desafiadores).
- Batalhas contra chefes poderosos que guardam grandes recompensas.
- Encontrar Baús: Descobrir tesouros contendo itens valiosos.
- Interagir com NPCs: Encontrar personagens não jogáveis que podem oferecer missões, informações ou itens.

#### Batalha

As batalhas no jogo são divididas em três etapas principais: setup, turnos e resultado.

- Setup: Durante esta fase, o jogador pode distribuir os dados de mana entre os personagens e organizá-los no campo de batalha.
- Turnos: Em cada turno, os personagens rolam os dados para obter mana, que é utilizada para ativar suas habilidades e realizar ações.
- Resultado: Após todos os turnos, a batalha é concluída, determinando a vitória ou derrota do jogador, e distribuindo recompensas ou penalidades conforme o resultado.

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
