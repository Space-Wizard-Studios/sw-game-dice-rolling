namespace DiceRolling.Dice;

/// <summary>
/// Interface que define as propriedades de um lado do dado.
/// </summary>
public interface IDiceSide {
    /// <summary>
    /// Tipo de mana associada ao lado.
    /// </summary>
    IDiceMana Mana { get; }
}