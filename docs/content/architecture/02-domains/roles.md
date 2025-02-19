# Roles

**Roles** são os arquétipos que os personagens podem assumir no jogo. Cada papel define um conjunto de habilidades e características específicas que os personagens podem ter.

## Interfaces

A interface `IRole` agrega várias interfaces menores para definir uma _Role_ completa no jogo.

```csharp
public interface IRole :
    IRoleInformation,
    IRoleAttributes,
    IRoleActions { }
```

Para mais detalhes, veja a [Referência da API](../../api/DiceRolling.Interfaces.Role.IRole.md).

### Informações

`IRoleInformation` define as informações básicas de um arquétipo.

- **Id**: Identificador único do arquétipo de personagem.
- **Name**: Nome do arquétipo de personagem.
- **Description**: Descrição do arquétipo de personagem.

### Atributos

`IRoleAttributes` define os atributos de uma arquétipo.

- **Attributes**: Coleção de `RoleAttribute`.

### Ações

`IRoleActions` define as ações que um arquétipo pode executar.

- **Actions**: Coleção de `RoleAction`.
