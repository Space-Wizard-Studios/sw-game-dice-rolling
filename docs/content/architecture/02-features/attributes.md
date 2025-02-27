# Attributes

**Attributes** são as características que definem os atributos dos personagens no jogo.

Para mais detalhes, veja a [Referência de API](../../api/DiceRolling.Attributes.md).

## Arquitetura

```mermaid
flowchart LR
    subgraph Interfaces
        IAttribute
    end

    subgraph Models
    direction TB
        AttributeType
    end

    subgraph Stores
        AttributeStore
    end

    Interfaces --> Models
    Models --> Stores
    Models <--> Stores
```

---

## Interfaces

- **IAttribute**: define um atributo no jogo e agrega as interfaces:
  - **IAttributeInformation**: informações básicas de um atributo.
  - **IAttributeAssets**: recursos visuais de um atributo.
  - **IAttributeValues**: valores de um atributo.

---

## Models

- **AttributeType**: Representa um tipo de atributo no jogo e inclui suas informações e valores. Esta classe também fornece métodos para inicializar e gerenciar esses aspectos.

---

## Stores

- **AttributeStore**: Armazena dados dos atributos em coleções e facilita a manipulação desses atributos.