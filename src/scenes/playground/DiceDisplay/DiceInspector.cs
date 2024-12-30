using Godot;
using System;

public partial class DiceInspector : Control {
	[Export]
	private NodePath diceInfoPath;
	[Export]
	private NodePath diceNamePath;
	[Export]
	private NodePath interactiveNodePath;

	private Control diceInfo;
	private Label diceName;
	private Control interactiveNode;
	private bool isVisible = false;

	public override void _Ready() {
		diceInfo = GetNode<Control>(diceInfoPath);
		diceName = GetNode<Label>(diceNamePath);
		interactiveNode = GetNode<Control>(interactiveNodePath);

		if (diceInfo is null || diceName is null || interactiveNode is null) {
			GD.PrintErr("DiceInfo, DiceName, or HoverNode not found. Check the paths.");
			return;
		}

		diceInfo.Visible = false;
		diceName.Visible = false;

		interactiveNode.Connect("gui_input", new Callable(this, nameof(OnMouseClick)));
	}

	private void OnMouseClick(InputEvent @event) {
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
			isVisible = !isVisible;
			diceInfo.Visible = isVisible;
			diceName.Visible = isVisible;
		}
	}
}
