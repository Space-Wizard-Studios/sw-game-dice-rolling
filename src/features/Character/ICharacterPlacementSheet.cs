using DiceRolling.Locations;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define a localização de um personagem no jogo.
/// </summary>
public interface ICharacterPlacementSheet {
    LocationType? Location { get; set; }
    int SlotIndex { get; set; }
}