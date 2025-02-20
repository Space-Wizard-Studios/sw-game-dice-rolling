# <a id="DiceRolling_Dice_IDiceLocation"></a> Interface IDiceLocation

Namespace: [DiceRolling.Dice](DiceRolling.Dice.md)  
Assembly: dice\-rolling.dll  

Interface que define a localização de um dado.

```csharp
public interface IDiceLocation
```

## Properties

### <a id="DiceRolling_Dice_IDiceLocation_CharacterId"></a> CharacterId

ID do personagem, se estiver com um personagem.

```csharp
string? CharacterId { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)?

### <a id="DiceRolling_Dice_IDiceLocation_LocationCategory"></a> LocationCategory

Categoria de localização do dado.

```csharp
DiceLocationCategory LocationCategory { get; }
```

#### Property Value

 [DiceLocationCategory](DiceRolling.Dice.DiceLocationCategory.md)

