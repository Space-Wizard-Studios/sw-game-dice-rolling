# <a id="DiceRolling_Actions_IActionInformation"></a> Interface IActionInformation

Namespace: [DiceRolling.Actions](DiceRolling.Actions.md)  
Assembly: dice\-rolling.dll  

Interface que define as informações básicas de uma ação no jogo.

```csharp
public interface IActionInformation
```

## Properties

### <a id="DiceRolling_Actions_IActionInformation_Category"></a> Category

Categoria da ação.

```csharp
ActionCategory? Category { get; set; }
```

#### Property Value

 [ActionCategory](DiceRolling.Actions.ActionCategory.md)?

### <a id="DiceRolling_Actions_IActionInformation_Description"></a> Description

Descrição da ação.

```csharp
string? Description { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Actions_IActionInformation_Name"></a> Name

Nome da ação.

```csharp
string Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

