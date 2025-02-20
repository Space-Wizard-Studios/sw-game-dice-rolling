# <a id="DiceRolling_Characters_ICharacterAttributes"></a> Interface ICharacterAttributes

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Interface que define os atributos de um personagem no jogo.

```csharp
public interface ICharacterAttributes
```

## Properties

### <a id="DiceRolling_Characters_ICharacterAttributes_Attributes"></a> Attributes

Lista de atributos da personagem.

```csharp
Array<CharacterAttribute> Attributes { get; }
```

#### Property Value

 Array<[CharacterAttribute](DiceRolling.Characters.CharacterAttribute.md)\>

## Methods

### <a id="DiceRolling_Characters_ICharacterAttributes_GetAttributeBaseValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeBaseValue\(AttributeType\)

Obtém o valor base de um atributo.

```csharp
int GetAttributeBaseValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor base do atributo.

### <a id="DiceRolling_Characters_ICharacterAttributes_GetAttributeCurrentValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeCurrentValue\(AttributeType\)

Obtém o valor atual de um atributo.

```csharp
int GetAttributeCurrentValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor atual do atributo.

### <a id="DiceRolling_Characters_ICharacterAttributes_GetAttributeMaxValue_DiceRolling_Attributes_AttributeType_"></a> GetAttributeMaxValue\(AttributeType\)

Obtém o valor máximo de um atributo.

```csharp
int GetAttributeMaxValue(AttributeType type)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

#### Returns

 [int](https://learn.microsoft.com/dotnet/api/system.int32)

Valor máximo do atributo.

### <a id="DiceRolling_Characters_ICharacterAttributes_InitializeAttributes"></a> InitializeAttributes\(\)

Inicializa os atributos da personagem.

```csharp
void InitializeAttributes()
```

### <a id="DiceRolling_Characters_ICharacterAttributes_UpdateAttributeCurrentValue_DiceRolling_Attributes_AttributeType_System_Int32_"></a> UpdateAttributeCurrentValue\(AttributeType, int\)

Atualiza o valor atual de um atributo.

```csharp
void UpdateAttributeCurrentValue(AttributeType type, int newValue)
```

#### Parameters

`type` [AttributeType](DiceRolling.Attributes.AttributeType.md)

Tipo do atributo.

`newValue` [int](https://learn.microsoft.com/dotnet/api/system.int32)

Novo valor do atributo.

