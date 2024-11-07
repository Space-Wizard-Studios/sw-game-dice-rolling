using Godot;

public partial class DiceSide : DiceAction {
	public DiceSide(string name,
	string abbreviation,
	string description,
	Color backgroundColor,
	Color textColor) : base(name, abbreviation, description, backgroundColor, textColor) { }
}