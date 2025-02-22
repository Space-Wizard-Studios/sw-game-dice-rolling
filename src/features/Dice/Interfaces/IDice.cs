using Godot;
using DiceRolling.Common;

namespace DiceRolling.Dice;

/// <summary>
/// Interface que define um dado completo no jogo.
/// </summary>
/// <typeparam name="T">Tipo de lado do dado.</typeparam>
public interface IDice<[MustBeVariant] T> : IIdentifiable where T : IDiceSide {
    string Name { get; }
    int SideCount { get; }
    Godot.Collections.Array<T> Sides { get; }
    IDiceLocation Location { get; }
}