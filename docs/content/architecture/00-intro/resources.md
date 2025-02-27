# Resources

A criação das informações do projeto (personagens, atributos, classes, ações, efeitos, etc.) é feita através dos Resources do Godot, que funcionam como containers para armazenamento desses dados.

Os Resources podem ser editados pela interface do Godot, carregados nas cenas (Nodes) e são acessados / manipulados in game através dos `Services` e das `Stores`.

Até o momento os tipos de Resources ainda estão sendo definidos e, por isso, deve existir apenas um para cada feature, sendo que o acesso e manipulação desses tipos estão sendo feitos de forma direta.

```mermaid
flowchart
    subgraph Interfaces
        ICharacter
    end

    Types["CharacterType"]

    CharacterService

    CharacterStore

    Types-->|implementa|Interfaces

    Interfaces-->|define|Properties

    CharacterService-->|manipula|Types
    CharacterService-->|acessa|CharacterStore
    CharacterStore-->|armazena|Types

    style Types fill:#d74242,stroke:#8a0d26,stroke-width:2px;
    style Interfaces fill:#1da2d3,stroke:#1c74d5,stroke-width:2px;
```

:::info Explicação

- `CharacterType` é o tipo de Resource que implementa as interfaces `ICharacter`;
- `CharacterService` manipula `CharacterType`;
- `CharacterStore` armazena `CharacterType`.

:::

:::tip Dica

Para um melhor entendimento do que é um Resource, veja o [tutorial](https://docs.godotengine.org/en/stable/tutorials/scripting/resources.html) e a [documentação](https://docs.godotengine.org/en/stable/classes/class_resource.html) do Godot.

:::

## Abstração

A partir do momento que novos tipos de Resources forem criados para uma mesma feature, como `CharacterTypeA` e `CharacterTypeB`, será necessário que essas classes herdem uma classe abstrata como `CharacterBase`.

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

:::info Explicação

- `CharacterTypeA` e `CharacterTypeB` são os tipos de Resource que herdam `CharacterBase`;
- `CharacterBase` é a classe abstrata que herda as interfaces de `ICharacter`;
- `CharacterService` manipula os dados tipo `CharacterBase`;
- `CharacterStore` armazena dados do tipo `CharacterBase`.

:::
