# Release 0.1.0

Essa milestone define o escopo mínimo para o lançamento inicial do jogo / framework.

O objetivo é ter uma versão jogável que demonstre as mecânicas básicas de combate e interação entre personagens. A maioria das funcionalidades já estão implementadas, mas ainda há algumas melhorias e ajustes a serem feitos para considerarmos um lançamento estável e funcional.

Diversas revisões precisam ser feitas para garantir que o código esteja limpo e organizado, e que as mecânicas de combate estejam equilibradas. Além disso, é importante garantir que a interface do usuário na framework seja intuitiva e fácil de usar.

Batalha Completa:

- Geração de inimigos com alguma aleatoriedade (posicionamento)
- Personagens rolam dados pré-configurados e consomem energia para ações
- Ciclo de Round funcional (Declaração -> Resolução -> Fim/Próximo)
- Condições de vitória/derrota funcionais (BattleResultsController)

2 personagens:

- 2 classes
- 8 animações (idle, hit, attack, death)
- 2 ataques pra cada (1 ataque básico + 1 ataque especial para cada)
- Implementar ação "Defender"

HUD Mínimo:

- Exibir HP, energia e ordem dos turnos.
- Permitir seleção básica das ações disponíveis (Ataque, Especial, Defender)
