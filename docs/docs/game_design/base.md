# Conceito Geral

As principais mecânicas do jogo giram em torno da manutenção de recursos para que os personagens tenham ações disponíveis nos combates.

## Transição entre cenas

O jogo possui dois managers responsáveis pelo controle dos estados do jogo.

- MenuTransitionManager: Gerencia as transições entre os menus do jogo.
- GameplayTransitionManager: Gerencia as transições durante a gameplay.

## Gameplay

A gameplay é dividida da seguinte maneira:

- **Lobby**: Área onde os jogadores podem preparar seus personagens e equipamentos antes de entrar na dungeon.
- **Dungeon**: A área de exploração e combate.
- **Battle**: Encontros de combate dentro da dungeon.
  - **Battle Setup**: Preparação para a batalha, incluindo a geração de inimigos.
  - **Turns**: Turnos de combate onde os jogadores e inimigos realizam ações.
  - **Battle End**: Conclusão da batalha, determinando vitória ou derrota.

### Lobby

O lobby é a "cidade principal" do jogo, onde o jogador pode realizar diversas atividades essenciais para a preparação de suas aventuras. No lobby, o jogador pode, por exemplo:

- Recrutar Personagens: Adicionar novos membros à equipe.
- Treinar Personagens: Melhorar as habilidades e atributos dos personagens.
- Equipar Personagens: Adquirir e equipar armas, armaduras e outros itens.
- Curar Personagens: Recuperar a saúde dos personagens após batalhas.
- Comprar Itens: Adquirir itens úteis para a exploração e combate.
- Modificar Dados de Mana: Ajustar os dados de mana que serão utilizados nas batalhas.

### Dungeon

A dungeon é a cena que representa a exploração da masmorra. Nela, o jogador escolhe caminhos e avança por pontos específicos, onde pode ocorrer uma variedade de interações, como:

- Acampamento: Encontrar um local seguro para descansar e recuperar recursos.
- Batalhas contra inimigos regulares.
- Batalhas contra de elite (inimigos mais fortes e desafiadores).
- Batalhas contra chefes poderosos que guardam grandes recompensas.
- Encontrar Baús: Descobrir tesouros contendo itens valiosos.
- Interagir com NPCs: Encontrar personagens não jogáveis que podem oferecer missões, informações ou itens.

### Batalha

As batalhas no jogo são divididas em três etapas principais: setup, turnos e resultado.

- Setup: Durante esta fase, o jogador pode distribuir os dados de mana entre os personagens e organizá-los no campo de batalha.
- Turnos: Em cada turno, os personagens rolam os dados para obter mana, que é utilizada para ativar suas habilidades e realizar ações.
- Resultado: Após todos os turnos, a batalha é concluída, determinando a vitória ou derrota do jogador, e distribuindo recompensas ou penalidades conforme o resultado.
