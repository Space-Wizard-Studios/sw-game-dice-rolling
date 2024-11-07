using Godot;
using System;

public partial class DiceHover : TextureRect {
	private ScrollContainer infoLabel;

	public override void _Ready() {
		infoLabel = GetNode<ScrollContainer>("../SidesInfoContainer");

		Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
		Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
	}

	private void OnMouseEntered() {
		infoLabel.Visible = true;
	}

	private void OnMouseExited() {
		infoLabel.Visible = false;
	}
}