# <a id="DiceRolling_Interfaces_Role_IRoleInformation"></a> Interface IRoleInformation

Namespace: [DiceRolling.Interfaces.Role](DiceRolling.Interfaces.Role.md)  
Assembly: dice\-rolling.dll  

Interface que define as informações básicas de um arquétipo de personagem no jogo.

```csharp
public interface IRoleInformation
```

## Properties

### <a id="DiceRolling_Interfaces_Role_IRoleInformation_Description"></a> Description

Descrição do arquétipo de personagem.

```csharp
string? Description { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Interfaces_Role_IRoleInformation_Id"></a> Id

Identificador único do arquétipo de personagem.

```csharp
string Id { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Interfaces_Role_IRoleInformation_Name"></a> Name

Nome do arquétipo de personagem.

```csharp
string? Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

