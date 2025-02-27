# Resources

Até o momento a tipagem das features ainda estão sendo definidas e, por isso, existe basicamente um tipo de Resource para cada feature.

Para um melhor entendimento do que é um Resource, veja o [tutorial](https://docs.godotengine.org/en/stable/tutorials/scripting/resources.html) e a [documentação](https://docs.godotengine.org/en/stable/classes/class_resource.html) do Godot.

Então a manipulação dos Resources até o momento está sendo feita diretamente.

```mermaid
flowchart LR
    subgraph Interfaces
        ICharacter
    end

    CharacterType

    CharacterService

    CharacterStore

    CharacterType-->|implementa|Interfaces

    Interfaces-->|define|Properties

    CharacterService-->|manipula|CharacterType
    CharacterService-->|acessa|CharacterStore
    CharacterStore-->|armazena|CharacterType

    style CharacterType fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style Interfaces fill:#1da2d3,stroke:#1c74d5,stroke-width:2px;
```

:::info

`CharacterType` é o tipo de Resource para a feature `Character`.

`CharacterService` manipula `CharacterType` e `CharacterStore` armazena `CharacterType`.

:::

## Abstração

A partir do momento que novos tipos de recursos forem criados para uma mesma feature, como `CharacterTypeA` e `CharacterTypeB`, será necessário que essas classes herdem uma classe abstrata como `CharacterBase`.

No gráfico abaixo, `CharacterBase` é a classe herdada e que abstrai as interfaces de `ICharacter`.

```mermaid
flowchart
    subgraph Interfaces
        ICharacter
    end

    subgraph Types
        CharacterTypeA
        CharacterTypeB
    end

    CharacterService

    CharacterStore

    subgraph Properties
        Other["..."]
        CharacterAction["Actions[]<br>(CharacterAction)"]
        CharacterAttribute["Attributes[]<br>(CharacterAttribute)"]
        Category["Category<br>(Category)"]
        Role["Role<br>(Role)"]
        Location["Location<br>(Location)"]
    end

    subgraph Features
        subgraph ActionFeature
            direction TB
            ActionBase-->|Abstrai|IAction
        end
        subgraph AttributeFeature
            direction TB
            AttributeBase-->|Abstrai|IAttribute
        end
        subgraph CategoryFeature
            direction TB
            CategoryBase-->|Abstrai|ICategory
        end
        subgraph RoleFeature
            direction TB
            RoleBase-->|Abstrai|IRole
        end
        subgraph LocationFeature
            direction TB
            LocationBase-->|Abstrai|ILocation
        end
    end

    CharacterBase-->|abstrai|Interfaces
    Types-->|implementam|Interfaces
    Types-->|herdam|CharacterBase

    Interfaces-->|define|Properties

    CharacterService-->|manipula|CharacterBase
    CharacterService-->|acessa|CharacterStore
    CharacterStore-->|armazena|CharacterBase

    CharacterAction-->|resource|ActionFeature
    CharacterAttribute-->|resource|AttributeFeature
    Category-->|resource|CategoryFeature
    Role-->|resource|RoleFeature
    Location-->|resource|LocationFeature

    style Types fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style Interfaces fill:#1da2d3,stroke:#1c74d5,stroke-width:2px;
    style CharacterBase fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style ActionBase fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style AttributeBase fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style CategoryBase fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style RoleBase fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
    style LocationBase fill:#8a1fd1,stroke:#8a1fd1,stroke-width:2px;
```
