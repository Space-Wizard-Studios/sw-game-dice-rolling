using Godot;

public partial class DiceDisplay : Control {
	[Export] public Label DiceNameLabel { get; private set; }
	[Export] public TextureRect DiceIcon { get; private set; }
	[Export] public VBoxContainer ActionsListContainer { get; private set; }
	[Export] public Control ActionItemTemplate { get; private set; }

	public override void _Ready() { }
}