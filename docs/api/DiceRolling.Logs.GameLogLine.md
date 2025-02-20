# <a id="DiceRolling_Logs_GameLogLine"></a> Class GameLogLine

Namespace: [DiceRolling.Logs](DiceRolling.Logs.md)  
Assembly: dice\-rolling.dll  

```csharp
public class GameLogLine
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[GameLogLine](DiceRolling.Logs.GameLogLine.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Constructors

### <a id="DiceRolling_Logs_GameLogLine__ctor_DiceRolling_Logs_GameLogLineType_System_String_"></a> GameLogLine\(GameLogLineType, string\)

```csharp
public GameLogLine(GameLogLineType type, string text)
```

#### Parameters

`type` [GameLogLineType](DiceRolling.Logs.GameLogLineType.md)

`text` [string](https://learn.microsoft.com/dotnet/api/system.string)

## Properties

### <a id="DiceRolling_Logs_GameLogLine_Text"></a> Text

```csharp
public string Text { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRolling_Logs_GameLogLine_Type"></a> Type

```csharp
public GameLogLineType Type { get; }
```

#### Property Value

 [GameLogLineType](DiceRolling.Logs.GameLogLineType.md)

