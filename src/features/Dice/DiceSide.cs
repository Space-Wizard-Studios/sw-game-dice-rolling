using Godot;
namespace DiceRolling.Dice;

/// <summary>
/// Represents a side of a dice with specific attributes.
/// </summary>
/// <param name="name">The name of the dice side.</param>
/// <param name="description">The description of the dice side.</param>
/// <param name="backgroundColor">The background color of the dice side.</param>
/// <param name="MainColor">The main color of the dice side.</param>
public partial class DiceSide(
    string name,
    string description,
    Color backgroundColor,
    Color MainColor) : DiceMana(name, description, backgroundColor, MainColor) {
}