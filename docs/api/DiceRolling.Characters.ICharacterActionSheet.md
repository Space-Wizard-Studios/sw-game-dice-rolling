# <a id="DiceRolling_Characters_ICharacterActionSheet"></a> Interface ICharacterActionSheet

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Interface que define as ações que um personagem pode realizar.

```csharp
public interface ICharacterActionSheet
```

## Properties

### <a id="DiceRolling_Characters_ICharacterActionSheet_Actions"></a> Actions

```csharp
Array<CharacterAction> Actions { get; }
```

#### Property Value

 Array<[CharacterAction](DiceRolling.Characters.CharacterAction.md)\>

## Methods

### <a id="DiceRolling_Characters_ICharacterActionSheet_AddAction_DiceRolling_Characters_CharacterAction_"></a> AddAction\(CharacterAction\)

```csharp
void AddAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

### <a id="DiceRolling_Characters_ICharacterActionSheet_InitializeActions"></a> InitializeActions\(\)

```csharp
void InitializeActions()
```

### <a id="DiceRolling_Characters_ICharacterActionSheet_RemoveAction_DiceRolling_Characters_CharacterAction_"></a> RemoveAction\(CharacterAction\)

```csharp
void RemoveAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

