using Godot;
using DiceRoll.Models;

namespace DiceRoll.Components;

public partial class HealthComponent : Node2D {
	[Export]
	public Health HealthResource;

	[Export]
	public Label HealthLabel;

	public override void _Ready() {
		base._Ready();
		UpdateHealthLabel();
	}

	public void UpdateHealthLabel() {
		if (HealthResource != null && HealthLabel != null) {
			HealthLabel.Text = $"{HealthResource.Current}/{HealthResource.Max}";
		}
	}
}
