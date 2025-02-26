# <a id="DiceRolling_Actions_IActionCategory"></a> Interface IActionCategory

Namespace: [DiceRolling.Actions](DiceRolling.Actions.md)  
Assembly: dice\-rolling.dll  

```csharp
public interface IActionCategory : IIdentifiable
```

#### Implements

[IIdentifiable](DiceRolling.Common.IIdentifiable.md)

## Properties

### <a id="DiceRolling_Actions_IActionCategory_DefaultEffects"></a> DefaultEffects

```csharp
Array<EffectType> DefaultEffects { get; set; }
```

#### Property Value

 Array<[EffectType](DiceRolling.Effects.EffectType.md)\>

### <a id="DiceRolling_Actions_IActionCategory_DefaultRequiredEnergy"></a> DefaultRequiredEnergy

```csharp
Array<DiceEnergy> DefaultRequiredEnergy { get; set; }
```

#### Property Value

 Array<[DiceEnergy](DiceRolling.Dice.DiceEnergy.md)\>

### <a id="DiceRolling_Actions_IActionCategory_Description"></a> Description

```csharp
string? Description { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Actions_IActionCategory_Icon"></a> Icon

```csharp
Texture2D? Icon { get; set; }
```

#### Property Value

 Texture2D?

### <a id="DiceRolling_Actions_IActionCategory_IconPath"></a> IconPath

```csharp
string? IconPath { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Actions_IActionCategory_Name"></a> Name

```csharp
string Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

## Methods

### <a id="DiceRolling_Actions_IActionCategory_ValidateConstructor"></a> ValidateConstructor\(\)

```csharp
void ValidateConstructor()
```

