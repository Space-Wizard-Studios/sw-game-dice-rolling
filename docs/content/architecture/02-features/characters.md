# Characters

**Characters** são entidades que representam os personagens **jogáveis e não-jogáveis** no jogo.

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Characters.md).

## Arquitetura

```mermaid
flowchart LR
    subgraph Interfaces
        ICharacter
    end

    subgraph Models
    direction TB
        CharacterType
        subgraph SubModels
            CharacterActions
            CharacterAttributes
            CharacterCategories
        end
    end

    subgraph Services
        CharacterService
    end

    subgraph Stores
        CharacterStore
    end

    Interfaces --> Models
    SubModels --> CharacterType
    Models --> Stores
    Models <--> Services
    Services <--> Stores

```

---

## Interfaces

- **ICharacter**: define um personagem no jogo e agrega as interfaces:
  - **ICharacterActionSheet**: ações de um personagem.
  - **ICharacterAssetSheet**: recursos visuais de um personagem.
  - **ICharacterAttributeSheet**: atributos de um personagem.
  - **ICharacterInformationSheet**: informações gerais de um personagem e categoria.
  - **ICharacterPlacementSheet**: localização de um personagem.
  - **ICharacterRoleSheet**: role de um personagem.

---

## Models

- **CharacterType**: Representa um tipo de personagem no jogo e inclui suas informações, atributos, ações, recursos visuais, localização e papel. Esta classe também fornece métodos para inicializar e gerenciar esses aspectos.

  ![CharacterType model](../../../public/architecture/02-features/characters/CharacterType.png)

### Sub Models

- **CharacterAction**: Ação de um personagem.
- **CharacterAttribute**: Atributo de um personagem.
- **CharacterCategory**: Categoria de um personagem.

---

## Services

- **CharacterService**: Fornece métodos para manipulação dos dados de personagens.

---

## Stores

- **CharacterStore**: Armazena dados dos personagens em coleções e facilita a manipulação desses personagens.
