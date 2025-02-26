# <a id="DiceRolling_Characters_CharacterService"></a> Class CharacterService

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Fornece métodos para manipulação dos dados de personagens.

```csharp
public class CharacterService
```

#### Inheritance

[object](https://learn.microsoft.com/dotnet/api/system.object) ← 
[CharacterService](DiceRolling.Characters.CharacterService.md)

#### Inherited Members

[object.Equals\(object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\)), 
[object.Equals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.equals\#system\-object\-equals\(system\-object\-system\-object\)), 
[object.GetHashCode\(\)](https://learn.microsoft.com/dotnet/api/system.object.gethashcode), 
[object.GetType\(\)](https://learn.microsoft.com/dotnet/api/system.object.gettype), 
[object.MemberwiseClone\(\)](https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone), 
[object.ReferenceEquals\(object?, object?\)](https://learn.microsoft.com/dotnet/api/system.object.referenceequals), 
[object.ToString\(\)](https://learn.microsoft.com/dotnet/api/system.object.tostring)

## Properties

### <a id="DiceRolling_Characters_CharacterService_Instance"></a> Instance

```csharp
public static CharacterService Instance { get; }
```

#### Property Value

 [CharacterService](DiceRolling.Characters.CharacterService.md)

## Methods

### <a id="DiceRolling_Characters_CharacterService_AddAction_DiceRolling_Characters_CharacterType_DiceRolling_Characters_CharacterAction_"></a> AddAction\(CharacterType, CharacterAction\)

```csharp
public void AddAction(CharacterType character, CharacterAction action)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

### <a id="DiceRolling_Characters_CharacterService_GetAttributeBaseValue_DiceRolling_Characters_CharacterType_DiceRolling_Attributes_AttributeType_"></a> GetAttributeBaseValue\(CharacterType, AttributeType\)

```csharp
public int GetAttributeBaseValue(CharacterType character, AttributeType type)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterService_GetAttributeCurrentValue_DiceRolling_Characters_CharacterType_DiceRolling_Attributes_AttributeType_"></a> GetAttributeCurrentValue\(CharacterType, AttributeType\)

```csharp
public int GetAttributeCurrentValue(CharacterType character, AttributeType type)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterService_GetAttributeMaxValue_DiceRolling_Characters_CharacterType_DiceRolling_Attributes_AttributeType_"></a> GetAttributeMaxValue\(CharacterType, AttributeType\)

```csharp
public int GetAttributeMaxValue(CharacterType character, AttributeType type)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_CharacterService_InitializeActions_DiceRolling_Characters_CharacterType_"></a> InitializeActions\(CharacterType\)

```csharp
public virtual void InitializeActions(CharacterType character)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

### <a id="DiceRolling_Characters_CharacterService_InitializeAttributes_DiceRolling_Characters_CharacterType_"></a> InitializeAttributes\(CharacterType\)

```csharp
public virtual void InitializeAttributes(CharacterType character)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

### <a id="DiceRolling_Characters_CharacterService_RemoveAction_DiceRolling_Characters_CharacterType_DiceRolling_Characters_CharacterAction_"></a> RemoveAction\(CharacterType, CharacterAction\)

```csharp
public void RemoveAction(CharacterType character, CharacterAction action)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

### <a id="DiceRolling_Characters_CharacterService_UpdateAttributeCurrentValue_DiceRolling_Characters_CharacterType_DiceRolling_Attributes_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(CharacterType, AttributeType, int\)

```csharp
public void UpdateAttributeCurrentValue(CharacterType character, AttributeType type, int newValue)
```

#### Parameters

`character` [CharacterType](DiceRolling.Characters.CharacterType.md)

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

