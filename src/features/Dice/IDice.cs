using Godot;

namespace DiceRolling.Interfaces.Dice;

/// <summary>
/// Interface que define um dado completo no jogo.
/// </summary>
/// <typeparam name="T">Tipo de lado do dado.</typeparam>
public interface IDice<[MustBeVariant] T> where T : IDiceSide {
    /// <summary>
    /// Identificador único do dado.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Nome do dado.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Coleção de lados do dado.
    /// </summary>
    Godot.Collections.Array<T> Sides { get; }

    /// <summary>
    /// Número de lados do dado.
    /// </summary>
    int SideCount { get; }

    /// <summary>
    /// Localização do dado.
    /// </summary>
    IDiceLocation Location { get; }
}