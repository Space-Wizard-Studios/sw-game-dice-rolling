# <a id="DiceRolling_Services_ValidationService"></a> Class ValidationService

Namespace: [DiceRolling.Services](DiceRolling.Services.md)  
Assembly: dice\-rolling.dll  

```csharp
public class ValidationService
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[ValidationService](DiceRolling.Services.ValidationService.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### <a id="DiceRolling_Services_ValidationService_Instance"></a> Instance

```csharp
public static ValidationService Instance { get; }
```

#### Property Value

 [ValidationService](DiceRolling.Services.ValidationService.md)

## Methods

### <a id="DiceRolling_Services_ValidationService_ValidateGridDimensions_System_Int32_System_Int32_"></a> ValidateGridDimensions\(int, int\)

```csharp
public static bool ValidateGridDimensions(int rows, int columns)
```

#### Parameters

`rows` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`columns` [int](https://learn.microsoft.com/dotnet/api/system.int32)

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Services_ValidationService_ValidateId_System_String_"></a> ValidateId\(string?\)

```csharp
public static bool ValidateId(string? value)
```

#### Parameters

`value` [string](https://learn.microsoft.com/dotnet/api/system.string)?

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Services_ValidationService_ValidateMinMaxValues_System_Int32_System_Int32_"></a> ValidateMinMaxValues\(int, int\)

```csharp
public static bool ValidateMinMaxValues(int minValue, int maxValue)
```

#### Parameters

`minValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

`maxValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

### <a id="DiceRolling_Services_ValidationService_ValidateName_System_String_"></a> ValidateName\(string?\)

```csharp
public static bool ValidateName(string? value)
```

#### Parameters

`value` [string](https://learn.microsoft.com/dotnet/api/system.string)?

#### Returns

 [bool](https://learn.microsoft.com/dotnet/api/system.boolean)

