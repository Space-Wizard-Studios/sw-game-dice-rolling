# Characters

**Characters** são entidades que representam os personagens **jogáveis e não-jogáveis** no jogo.

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Characters.md).

## Visão Geral

```mermaid
flowchart
    subgraph Interfaces
        ICharacter
    end

    subgraph Types
        CharacterType
    end

    subgraph Services["Services"]
        CharacterService
    end

    subgraph Stores["Stores"]
        CharacterStore
    end

    subgraph Properties
        ...
        CharacterAction
        CharacterAttribute
        Category
        CharacterRole
        CharacterPlacement
    end

    subgraph Features
        ActionFeature[ActionType]
        AttributeFeature[AttributeType]
        CategoryFeature[Category]
        RoleFeature[RoleType]
        LocationFeature[LocationType]
    end

    Types-->|implementa|Interfaces

    Interfaces-->|define|Properties

    Services-->|manipula|Types
    Services-->|acessa|Stores
    Stores-->|armazena|Types

    CharacterAction-->|resource|ActionFeature
    CharacterAttribute-->|resource|AttributeFeature
    Category-->|resource|CategoryFeature
    CharacterRole-->|resource|RoleFeature
    CharacterPlacement-->|resource|LocationFeature

    style Types fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style Interfaces fill:#1da2d3,stroke:#1c74d5,stroke-width:2px;
```

---

## Interfaces

- **ICharacter**: define um personagem no jogo e agrega as interfaces:
  - **IIdentifiable**: define uma ID única.
  - **ICharacterInformationSheet**: informações gerais de um personagem e categoria.
  - **ICharacterAssetSheet**: recursos visuais de um personagem.
  - **ICharacterRoleSheet**: role de um personagem.
  - **ICharacterActionSheet**: ações de um personagem.
  - **ICharacterAttributeSheet**: atributos de um personagem.
  - **ICharacterPlacementSheet**: localização de um personagem.

---

## Types (Resources)

- **CharacterType**: Representa um tipo de personagem no jogo e inclui suas informações, atributos, ações, recursos visuais, localização e papel. Esta classe também fornece métodos para inicializar e gerenciar esses aspectos.

  ![CharacterType model](../../../public/architecture/02-features/characters/CharacterType.png)

### External Properties

- **Category**: Categoria do personagem.
- **CharacterRole**: Role do personagem.
- **CharacterAction**: Ação do personagem.
- **CharacterAttribute**: Atributo do personagem.
- **CharacterPlacement**: Localização do personagem.

---

## Services

- **CharacterService**: Fornece métodos para manipulação dos dados de personagens.

---

## Stores

- **CharacterStore**: Armazena dados dos personagens em coleções e facilita a manipulação desses personagens.
