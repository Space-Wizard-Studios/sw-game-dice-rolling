# <a id="DiceRolling_Characters_ICharacter"></a> Interface ICharacter

Namespace: [DiceRolling.Characters](DiceRolling.Characters.md)  
Assembly: dice\-rolling.dll  

Representa as entidades de personagens no jogo.

```csharp
public interface ICharacter : IIdentifiable, ICharacterInformationSheet, ICharacterPlacementSheet, ICharacterAssetSheet, ICharacterRoleSheet, ICharacterAttributeSheet, ICharacterActionSheet
```

#### Implements

[IIdentifiable](DiceRolling.Common.IIdentifiable.md), 
[ICharacterInformationSheet](DiceRolling.Characters.ICharacterInformationSheet.md), 
[ICharacterPlacementSheet](DiceRolling.Characters.ICharacterPlacementSheet.md), 
[ICharacterAssetSheet](DiceRolling.Characters.ICharacterAssetSheet.md), 
[ICharacterRoleSheet](DiceRolling.Characters.ICharacterRoleSheet.md), 
[ICharacterAttributeSheet](DiceRolling.Characters.ICharacterAttributeSheet.md), 
[ICharacterActionSheet](DiceRolling.Characters.ICharacterActionSheet.md)

## Methods

### <a id="DiceRolling_Characters_ICharacter_ValidateConstructor"></a> ValidateConstructor\(\)

Valida os campos do resource.

```csharp
void ValidateConstructor()
```

