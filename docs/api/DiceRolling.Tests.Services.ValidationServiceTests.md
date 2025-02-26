# <a id="DiceRolling_Tests_Services_ValidationServiceTests"></a> Class ValidationServiceTests

Namespace: [DiceRolling.Tests.Services](DiceRolling.Tests.Services.md)  
Assembly: dice\-rolling.dll  

```csharp
[TestSuite(7, "")]
public class ValidationServiceTests
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[ValidationServiceTests](DiceRolling.Tests.Services.ValidationServiceTests.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Methods

### <a id="DiceRolling_Tests_Services_ValidationServiceTests_ValidateName_ShouldReturnFalse_WhenSetToNullOrEmpty"></a> ValidateName\_ShouldReturnFalse\_WhenSetToNullOrEmpty\(\)

```csharp
[TestCase(new object?[] { })]
public static void ValidateName_ShouldReturnFalse_WhenSetToNullOrEmpty()
```

### <a id="DiceRolling_Tests_Services_ValidationServiceTests_ValidateValues_ShouldReturnFalse_WhenMinValueIsGreaterThanMaxValue"></a> ValidateValues\_ShouldReturnFalse\_WhenMinValueIsGreaterThanMaxValue\(\)

```csharp
[TestCase(new object?[] { })]
public static void ValidateValues_ShouldReturnFalse_WhenMinValueIsGreaterThanMaxValue()
```

