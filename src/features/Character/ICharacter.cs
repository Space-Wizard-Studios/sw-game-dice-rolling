using DiceRolling.Common;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define um personagem completo no jogo.
/// </summary>

public interface ICharacter :
    IIdentifiable,
    ICharacterInformation,
    ICharacterPlacement,
    ICharacterAssets,
    ICharacterRole,
    ICharacterAttributes,
    ICharacterActions {

    /// <summary>
    /// Valida os campos do resource.
    /// </summary>
    void ValidateConstructor();
}