# Actions

**Actions** são entidades que representam as ações que podem ser realizadas pelos personagens no jogo.

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Actions.md).

## Arquitetura

```mermaid
flowchart TD
    subgraph Interfaces
        IAction
    end

    subgraph Types
        ActionType
    end

    subgraph Properties["Properties"]
        ...
        Category
        DiceEnergy
        Effects
        TargetBoard
    end

    subgraph Features
        CategoryFeature["Category"]
        DiceFeature["DiceType"]
        EffectsFeature["EffectType"]
        BoardFeature["TargetBoardType"]
    end

    Types-->|implementa|Interfaces

    Interfaces-->|define|Properties

    Category-->|resource|CategoryFeature
    DiceEnergy-->|resource|DiceFeature
    Effects-->|resource|EffectsFeature
    TargetBoard-->|resource|BoardFeature

    style Types fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style Interfaces fill:#1da2d3,stroke:#1c74d5,stroke-width:2px;
```

---

## Interfaces

- **IAction**: define as entidades de ações que são realizadas por personagens do jogo e agrega as interfaces:
  - **IActionInformation**: informações gerais de uma ação.
  - **IActionAssets**: recursos visuais de uma ação.
  - **IActionBehavior**: comportamento de uma ação.
  - **IActionContext**: contexto de uma ação.
  - **IActionResult**: resultado de uma ação.

---

## Types (Resources)

- **ActionType**: Representa um tipo de ação no jogo e inclui suas informações, comportamento, categoria, contexto e efeitos. Esta classe também fornece métodos para gerenciar esses aspectos.

### External Properties

- **Category**: categoria da ação.
- **DiceEnergy**: energia necessária para realizar a ação.
- **Effects**: efeitos da ação.
- **TargetBoard**: configuração do alvo da ação.

## Services

N/A

## Stores

N/A
