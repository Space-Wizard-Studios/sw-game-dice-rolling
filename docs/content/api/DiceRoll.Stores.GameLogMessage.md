---
title: Stores.GameLogMessage
---

# <a id="DiceRoll_Stores_GameLogMessage"></a> Class GameLogMessage

Namespace: [DiceRoll.Stores](DiceRoll.Stores.md)  
Assembly: dice\-roll.dll  

```csharp
public class GameLogMessage
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[GameLogMessage](DiceRoll.Stores.GameLogMessage.md)

#### Inherited Members

<details>
<summary>Show/Hide Inherited Members</summary>

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)),   
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)),   
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode),   
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype),   
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone),   
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals),   
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

</details>
## Constructors

### <a id="DiceRoll_Stores_GameLogMessage__ctor_System_String_System_String_System_Collections_Generic_List_DiceRoll_Stores_GameLogLine__"></a> GameLogMessage\(string, string, List\<GameLogLine\>\)

```csharp
public GameLogMessage(string heading, string timestamp, List<GameLogLine> lines)
```

#### Parameters

`heading` [string](https://learn.microsoft.com/dotnet/api/system.string)

`timestamp` [string](https://learn.microsoft.com/dotnet/api/system.string)

`lines` [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)\<[GameLogLine](DiceRoll.Stores.GameLogLine.md)\>

## Properties

### <a id="DiceRoll_Stores_GameLogMessage_Heading"></a> Heading

```csharp
public string Heading { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

### <a id="DiceRoll_Stores_GameLogMessage_Lines"></a> Lines

```csharp
public List<GameLogLine> Lines { get; }
```

#### Property Value

 [List](https://learn.microsoft.com/dotnet/api/system.collections.generic.list\-1)\<[GameLogLine](DiceRoll.Stores.GameLogLine.md)\>

### <a id="DiceRoll_Stores_GameLogMessage_Timestamp"></a> Timestamp

```csharp
public string Timestamp { get; }
```

#### Property Value

 [string](https://learn.microsoft.com/dotnet/api/system.string)

