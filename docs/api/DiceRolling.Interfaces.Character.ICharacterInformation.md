# <a id="DiceRolling_Interfaces_Character_ICharacterInformation"></a> Interface ICharacterInformation

Namespace: [DiceRolling.Interfaces.Character](DiceRolling.Interfaces.Character.md)  
Assembly: dice\-rolling.dll  

Interface que define as informações básicas de um personagem no jogo.

```csharp
public interface ICharacterInformation
```

## Properties

### <a id="DiceRolling_Interfaces_Character_ICharacterInformation_Category"></a> Category

Categoria do personagem.

```csharp
CharacterCategory? Category { get; set; }
```

#### Property Value

 [CharacterCategory](DiceRolling.Models.Characters.CharacterCategory.md)?

### <a id="DiceRolling_Interfaces_Character_ICharacterInformation_DiceCapacity"></a> DiceCapacity

Capacidade de dados do personagem.

```csharp
int DiceCapacity { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Interfaces_Character_ICharacterInformation_Id"></a> Id

Identificador único do personagem.

```csharp
string Id { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Interfaces_Character_ICharacterInformation_Name"></a> Name

Nome do personagem.

```csharp
string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Interfaces_Character_ICharacterInformation_Role"></a> Role

Papel do personagem no jogo.

```csharp
RoleType? Role { get; set; }
```

#### Property Value

 [RoleType](DiceRolling.Models.Roles.RoleType.md)?

