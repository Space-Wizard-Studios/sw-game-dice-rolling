using Godot;

public partial class DiceSide : DiceAction {
	public DiceSide(string name,
	string abbreviation,
	string description,
	Godot.Collections.Array<ActionTarget> targets,
	ActionColor colors)

	: base(name, abbreviation, description, targets, colors) { }
}