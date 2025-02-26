# <a id="DiceRolling_Services_GridService"></a> Class GridService

Namespace: [DiceRolling.Services](DiceRolling.Services.md)  
Assembly: dice\-rolling.dll  

```csharp
public class GridService
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[GridService](DiceRolling.Services.GridService.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### <a id="DiceRolling_Services_GridService_Instance"></a> Instance

```csharp
public static GridService Instance { get; }
```

#### Property Value

 [GridService](DiceRolling.Services.GridService.md)

## Methods

### <a id="DiceRolling_Services_GridService_GetCell_Godot_Collections_Array_System_Int32__System_Int32_System_Int32_System_Int32_"></a> GetCell\(Array<int\>, int, int, int\)

```csharp
public static int GetCell(Array<int> cells, int row, int column, int columns)
```

#### Parameters

`cells` Array<[int](https://learn.microsoft.com/dotnet/api/system.int32)\>

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Services_GridService_GetCellIndex_System_Int32_System_Int32_System_Int32_"></a> GetCellIndex\(int, int, int\)

```csharp
public static int GetCellIndex(int row, int column, int columns)
```

#### Parameters

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Services_GridService_ResizeCells_Godot_Collections_Array_System_Int32__System_Int32_System_Int32_"></a> ResizeCells\(Array<int\>, int, int\)

```csharp
public static void ResizeCells(Array<int> cells, int rows, int columns)
```

#### Parameters

`cells` Array<[int](https://learn.microsoft.com/dotnet/api/system.int32)\>

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Services_GridService_SetCell_Godot_Collections_Array_System_Int32__System_Int32_System_Int32_System_Int32_System_Int32_"></a> SetCell\(Array<int\>, int, int, int, int\)

```csharp
public static void SetCell(Array<int> cells, int row, int column, int value, int columns)
```

#### Parameters

`cells` Array<[int](https://learn.microsoft.com/dotnet/api/system.int32)\>

`row` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`column` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`value` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

