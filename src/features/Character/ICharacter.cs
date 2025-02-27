using DiceRolling.Id;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define as entidades de personagens no jogo.
/// </summary>

public interface ICharacter :
    IIdentifiable,
    ICharacterInformationSheet,
    ICharacterPlacementSheet,
    ICharacterAssetSheet,
    ICharacterRoleSheet,
    ICharacterAttributeSheet,
    ICharacterActionSheet {

    /// <summary>
    /// Valida os campos do resource.
    /// </summary>
    void ValidateConstructor();
}