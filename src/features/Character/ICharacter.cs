namespace DiceRolling.Characters;

/// <summary>
/// Interface que define um personagem completo no jogo.
/// </summary>

public interface
ICharacter :
ICharacterInformation,
ICharacterPlacement,
ICharacterAssets,
ICharacterAttributes,
ICharacterActions { }