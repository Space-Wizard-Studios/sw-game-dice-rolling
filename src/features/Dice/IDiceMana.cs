using Godot;

namespace DiceRolling.Dice;

/// <summary>
/// Interface que define as propriedades de uma mana.
/// </summary>
public interface IDiceMana {
    /// <summary>
    /// Nome da mana.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Descrição da mana.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Cor de fundo da mana.
    /// </summary>
    Color BackgroundColor { get; }

    /// <summary>
    /// Cor principal da mana.
    /// </summary>
    Color MainColor { get; }

    /// <summary>
    /// Ícone da mana.
    /// </summary>
    Texture2D Icon { get; }
}