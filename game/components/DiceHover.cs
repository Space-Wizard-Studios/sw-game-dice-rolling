using Godot;
using System;

public partial class DiceHover : Control {
	[Export]
	private NodePath diceInfoPath;
	[Export]
	private NodePath diceNamePath;
	[Export]
	private NodePath hoverNodePath;

	private Control diceInfo;
	private Label diceName;
	private Control hoverNode;

	public override void _Ready() {
		diceInfo = GetNode<Control>(diceInfoPath);
		diceName = GetNode<Label>(diceNamePath);
		hoverNode = GetNode<Control>(hoverNodePath);

		if (diceInfo == null || diceName == null || hoverNode == null) {
			GD.PrintErr("DiceInfo, DiceName, or HoverNode not found. Check the paths.");
			return;
		}

		diceInfo.Visible = false;
		diceName.Visible = false;

		hoverNode.Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
		hoverNode.Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
	}

	private void OnMouseEntered() {
		GD.Print("Mouse entered");
		diceInfo.Visible = true;
		diceName.Visible = true;
	}

	private void OnMouseExited() {
		GD.Print("Mouse exited");
		diceInfo.Visible = false;
		diceName.Visible = false;
	}
}