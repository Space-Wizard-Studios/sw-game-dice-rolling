# <a id="DiceRolling_Dice_IDice_1"></a> Interface IDice<T\>

Namespace: [DiceRolling.Dice](DiceRolling.Dice.md)  
Assembly: dice\-rolling.dll  

Interface que define um dado completo no jogo.

```csharp
public interface IDice<T> : IIdentifiable where T : DiceSide
```

#### Type Parameters

`T` 

Tipo de lado do dado.

#### Implements

[IIdentifiable](DiceRolling.Common.IIdentifiable.md)

## Properties

### <a id="DiceRolling_Dice_IDice_1_Location"></a> Location

```csharp
DiceLocation Location { get; }
```

#### Property Value

 [DiceLocation](DiceRolling.Dice.DiceLocation.md)

### <a id="DiceRolling_Dice_IDice_1_Name"></a> Name

```csharp
string Name { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Dice_IDice_1_SideCount"></a> SideCount

```csharp
int SideCount { get; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Dice_IDice_1_Sides"></a> Sides

```csharp
Array<T> Sides { get; }
```

#### Property Value

 Array<T\>

## Methods

### <a id="DiceRolling_Dice_IDice_1_ValidateConstructor"></a> ValidateConstructor\(\)

```csharp
void ValidateConstructor()
```

