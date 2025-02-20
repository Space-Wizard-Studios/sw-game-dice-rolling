# <a id="DiceRolling_Dice_IDice_1"></a> Interface IDice<T\>

Namespace: [DiceRolling.Dice](DiceRolling.Dice.md)  
Assembly: dice\-rolling.dll  

Interface que define um dado completo no jogo.

```csharp
public interface IDice<T> where T : IDiceSide
```

#### Type Parameters

`T` 

Tipo de lado do dado.

## Properties

### <a id="DiceRolling_Dice_IDice_1_Id"></a> Id

Identificador único do dado.

```csharp
string Id { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Dice_IDice_1_Location"></a> Location

Localização do dado.

```csharp
IDiceLocation Location { get; }
```

#### Property Value

 [IDiceLocation](DiceRolling.Dice.IDiceLocation.md)

### <a id="DiceRolling_Dice_IDice_1_Name"></a> Name

Nome do dado.

```csharp
string Name { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Dice_IDice_1_SideCount"></a> SideCount

Número de lados do dado.

```csharp
int SideCount { get; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Dice_IDice_1_Sides"></a> Sides

Coleção de lados do dado.

```csharp
Array<T> Sides { get; }
```

#### Property Value

 Array<T\>

