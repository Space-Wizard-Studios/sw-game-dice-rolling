# <a id="DiceRolling_Dice_IDiceEnergy"></a> Interface IDiceEnergy

Namespace: [DiceRolling.Dice](DiceRolling.Dice.md)  
Assembly: dice\-rolling.dll  

Interface que define as propriedades de uma energia.

```csharp
public interface IDiceEnergy : IIdentifiable
```

#### Implements

[IIdentifiable](DiceRolling.Common.IIdentifiable.md)

## Properties

### <a id="DiceRolling_Dice_IDiceEnergy_BackgroundColor"></a> BackgroundColor

Cor de fundo da energia.

```csharp
Color BackgroundColor { get; }
```

#### Property Value

 Color

### <a id="DiceRolling_Dice_IDiceEnergy_Description"></a> Description

Descrição da energia.

```csharp
string? Description { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Dice_IDiceEnergy_Icon"></a> Icon

Ícone da energia.

```csharp
Texture2D? Icon { get; }
```

#### Property Value

 Texture2D?

### <a id="DiceRolling_Dice_IDiceEnergy_IconPath"></a> IconPath

```csharp
string? IconPath { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Dice_IDiceEnergy_MainColor"></a> MainColor

Cor principal da energia.

```csharp
Color MainColor { get; }
```

#### Property Value

 Color

### <a id="DiceRolling_Dice_IDiceEnergy_Name"></a> Name

Nome da energia.

```csharp
string Name { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

