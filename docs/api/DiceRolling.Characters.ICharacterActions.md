# <a id="DiceRolling_Characters_ICharacterActions"></a> Interface ICharacterActions

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Interface que define as ações de um personagem no jogo.

```csharp
public interface ICharacterActions
```

## Properties

### <a id="DiceRolling_Characters_ICharacterActions_Actions"></a> Actions

Lista de ações da personagem.

```csharp
Array<CharacterAction> Actions { get; }
```

#### Property Value

 Array<[CharacterAction](DiceRolling.Characters.CharacterAction.md)\>

## Methods

### <a id="DiceRolling_Characters_ICharacterActions_AddAction_DiceRolling_Characters_CharacterAction_"></a> AddAction\(CharacterAction\)

Adiciona uma nova ação à personagem.

```csharp
void AddAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

Ação a ser adicionada.

### <a id="DiceRolling_Characters_ICharacterActions_InitializeActions"></a> InitializeActions\(\)

Inicializa as ações da personagem.

```csharp
void InitializeActions()
```

### <a id="DiceRolling_Characters_ICharacterActions_RemoveAction_DiceRolling_Characters_CharacterAction_"></a> RemoveAction\(CharacterAction\)

Remove uma ação da personagem.

```csharp
void RemoveAction(CharacterAction action)
```

#### Parameters

`action` [CharacterAction](DiceRolling.Characters.CharacterAction.md)

Ação a ser removida.

