# <a id="DiceRolling_Characters_ICharacterPlacement"></a> Interface ICharacterPlacement

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Interface que define a localização de um personagem no jogo.

```csharp
public interface ICharacterPlacement
```

## Properties

### <a id="DiceRolling_Characters_ICharacterPlacement_Location"></a> Location

Localização do personagem no jogo.

```csharp
LocationType? Location { get; set; }
```

#### Property Value

 [LocationType](DiceRolling.Locations.LocationType.md)?

### <a id="DiceRolling_Characters_ICharacterPlacement_SlotIndex"></a> SlotIndex

Índice do slot onde o personagem está localizado.

```csharp
int SlotIndex { get; set; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

