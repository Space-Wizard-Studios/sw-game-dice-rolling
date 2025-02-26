# <a id="DiceRolling_Characters_ICharacterAttributeSheet"></a> Interface ICharacterAttributeSheet

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Interface que define os atributos de um personagem.

```csharp
public interface ICharacterAttributeSheet
```

## Properties

### <a id="DiceRolling_Characters_ICharacterAttributeSheet_Attributes"></a> Attributes

```csharp
Array<CharacterAttribute> Attributes { get; }
```

#### Property Value

 Array<[CharacterAttribute](DiceRolling.Characters.CharacterAttribute.md)\>

## Methods

### <a id="DiceRolling_Characters_ICharacterAttributeSheet_GetAttributeBaseValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeBaseValue\(AttributeType\)

```csharp
int GetAttributeBaseValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_ICharacterAttributeSheet_GetAttributeCurrentValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeCurrentValue\(AttributeType\)

```csharp
int GetAttributeCurrentValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_ICharacterAttributeSheet_GetAttributeMaxValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeMaxValue\(AttributeType\)

```csharp
int GetAttributeMaxValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

### <a id="DiceRolling_Characters_ICharacterAttributeSheet_InitializeAttributes"></a> InitializeAttributes\(\)

```csharp
void InitializeAttributes()
```

### <a id="DiceRolling_Characters_ICharacterAttributeSheet_UpdateAttributeCurrentValue_DiceRolling_Attributes_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(AttributeType, int\)

```csharp
void UpdateAttributeCurrentValue(AttributeType type, int newValue)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

