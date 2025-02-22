namespace DiceRolling.Dice;

/// <summary>
/// Interface que define as propriedades de um lado do dado.
/// </summary>
public interface IDiceSide {
    DiceEnergy? Energy { get; }
}