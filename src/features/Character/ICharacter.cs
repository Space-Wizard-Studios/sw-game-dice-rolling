using DiceRolling.Id;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define as entidades de personagens no jogo.
/// </summary>

public interface ICharacter :
    IIdentifiable,
    ICharacterInformationSheet,
    ICharacterAssetSheet,
    ICharacterRoleSheet,
    ICharacterActionSheet,
    ICharacterAttributeSheet,
    ICharacterPlacementSheet {
    void ValidateConstructor();
}