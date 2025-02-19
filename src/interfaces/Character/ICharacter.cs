namespace DiceRolling.Interfaces.Character;

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