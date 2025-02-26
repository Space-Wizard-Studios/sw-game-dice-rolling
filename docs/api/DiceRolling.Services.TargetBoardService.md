# <a id="DiceRolling_Services_TargetBoardService"></a> Class TargetBoardService

Namespace: [DiceRolling.Services](DiceRolling.Services.md)  
Assembly: dice\-rolling.dll  

Serviço para manipulação de tabuleiros de alvos.

```csharp
public class TargetBoardService
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[TargetBoardService](DiceRolling.Services.TargetBoardService.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### <a id="DiceRolling_Services_TargetBoardService_Instance"></a> Instance

```csharp
public static TargetBoardService Instance { get; }
```

#### Property Value

 [TargetBoardService](DiceRolling.Services.TargetBoardService.md)

## Methods

### <a id="DiceRolling_Services_TargetBoardService_AddGrid_DiceRolling_Targets_TargetBoardType_System_Int32_System_Int32_"></a> AddGrid\(TargetBoardType, int, int\)

```csharp
public static void AddGrid(TargetBoardType targetBoard, int rows, int columns)
```

#### Parameters

`targetBoard` [TargetBoardType](DiceRolling.Targets.TargetBoardType.md)

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Services_TargetBoardService_UpdateGrid_DiceRolling_Targets_TargetBoardType_System_Int32_"></a> UpdateGrid\(TargetBoardType, int\)

```csharp
public static void UpdateGrid(TargetBoardType targetBoard, int index)
```

#### Parameters

`targetBoard` [TargetBoardType](DiceRolling.Targets.TargetBoardType.md)

`index` [int](https://learn.microsoft.com/dotnet/api/system.int32)

