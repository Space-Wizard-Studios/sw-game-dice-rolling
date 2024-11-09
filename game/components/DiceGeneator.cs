using Godot;
using System;
using System.Collections.Generic;

public partial class DiceGeneator : Node {
	[Export]
	public DiceActionsResource DiceActionsResource { get; set; }

	[Export]
	public DiceIconsResource DiceIconResource { get; set; }

	private Dice<DiceSide> _dice;

	public override void _Ready() {
		if (DiceActionsResource == null) {
			GD.PrintErr("DiceActionsResource is not assigned");
			return;
		}

		if (DiceIconResource == null) {
			GD.PrintErr("DiceIconResource is not assigned");
			return;
		}

		// Generate a random dice
		_dice = CreateRandomDice();
		GD.Print($"Generated Dice: {_dice.Name}");
		GD.Print($"Number of Sides: {_dice.Sides}");

		// Update DiceDisplay
		UpdateDiceDisplay();
	}

	private Dice<DiceSide> CreateRandomDice() {
		var random = new Random();
		int sides = random.Next(1, 7); // Randomly select between 4, 6, 8, 10, 20, 100 sides
		sides = sides switch {
			1 => 4,
			2 => 6,
			3 => 8,
			4 => 10,
			5 => 20,
			6 => 100,
			_ => 6
		};

		var actions = new Godot.Collections.Array<DiceSide>();
		for (int i = 0; i < sides; i++) {
			int randomIndex = random.Next(DiceActionsResource.Actions.Count);
			var action = DiceActionsResource.Actions[randomIndex];
			GD.Print($"Selected Action: {action.Name} - {action.Description}");
			actions.Add(new DiceSide(action.Name, action.Abbreviation, action.Description, action.BackgroundColor, action.TextColor));
		}

		return new Dice<DiceSide>(Guid.NewGuid().ToString(), $"D{sides}", actions, DiceLocation.None);
	}

	private void UpdateDiceDisplay() {
		var diceDisplay = GetNode<Control>("DiceDisplay");
		var diceNameLabel = diceDisplay.GetNode<Label>("DiceContainer/DiceName");
		diceNameLabel.Text = _dice.Name;

		var diceIcon = diceDisplay.GetNode<TextureRect>("DiceContainer/DiceIcon");
		diceIcon.Texture = DiceIconResource.GetIconForSides(_dice.Sides);

		var actionsListContainer = diceDisplay.GetNode<VBoxContainer>("DiceInfo/ActionsInfo/ActionsList");

		// Clear all children from the actions list container
		foreach (Node child in actionsListContainer.GetChildren()) {
			actionsListContainer.RemoveChild(child);
			child.QueueFree();
		}

		for (int i = 0; i < _dice.Sides; i++) {
			var action = _dice.Actions[i];

			var actionItem = new Control();
			var actionColor = new ColorRect {
				Color = action.BackgroundColor,
				CustomMinimumSize = new Vector2(0, 25)
			};
			actionItem.AddChild(actionColor);

			var actionLabel = new Label {
				Text = $"Side {i + 1}: {action.Name} - {action.Description}",
				Modulate = action.TextColor
			};
			actionColor.AddChild(actionLabel);

			actionsListContainer.AddChild(actionItem);
		}
	}
}