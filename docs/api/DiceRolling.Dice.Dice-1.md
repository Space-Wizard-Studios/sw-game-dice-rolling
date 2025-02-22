# <a id="DiceRolling_Dice_Dice_1"></a> Class Dice<T\>

Namespace: [DiceRolling.Dice](DiceRolling.Dice.md)  
Assembly: dice\-rolling.dll  

```csharp
public class Dice<T> where T : DiceSide
```

#### Type Parameters

`T` 

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[Dice<T\>](DiceRolling.Dice.Dice\-1.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### <a id="DiceRolling_Dice_Dice_1__ctor_System_String_System_String_Godot_Collections_Array__0__DiceRolling_Dice_DiceLocation_"></a> Dice\(string, string, Array<T\>, DiceLocation\)

```csharp
public Dice(string id, string name, Array<T> manas, DiceLocation location)
```

#### Parameters

`id` [string](https://learn.microsoft.com/dotnet/api/system.string)

`name` [string](https://learn.microsoft.com/dotnet/api/system.string)

`manas` Array<T\>

`location` [DiceLocation](DiceRolling.Dice.DiceLocation.md)

## Properties

### <a id="DiceRolling_Dice_Dice_1_Id"></a> Id

```csharp
public string Id { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Dice_Dice_1_Location"></a> Location

```csharp
public DiceLocation Location { get; set; }
```

#### Property Value

 [DiceLocation](DiceRolling.Dice.DiceLocation.md)

### <a id="DiceRolling_Dice_Dice_1_Manas"></a> Manas

```csharp
public Array<T> Manas { get; set; }
```

#### Property Value

 Array<T\>

### <a id="DiceRolling_Dice_Dice_1_Name"></a> Name

```csharp
public string Name { get; set; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Dice_Dice_1_Sides"></a> Sides

```csharp
public int Sides { get; }
```

#### Property Value

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

