using DiceRolling.Models.Locations;

namespace DiceRolling.Interfaces.Character;

/// <summary>
/// Interface que define a localização de um personagem no jogo.
/// </summary>
public interface ICharacterPlacement {
    /// <summary>
    /// Localização do personagem no jogo.
    /// </summary>
    LocationType? Location { get; set; }

    /// <summary>
    /// Índice do slot onde o personagem está localizado.
    /// </summary>
    int SlotIndex { get; set; }
}