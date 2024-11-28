using Godot;
namespace DiceRoll.Models;

public partial class DiceSide : DiceMana {
	public DiceSide(string name,
	string abbreviation,
	string description,
	Color backgroundColor,
	Color textColor) : base(name, abbreviation, description, backgroundColor, textColor) { }
}