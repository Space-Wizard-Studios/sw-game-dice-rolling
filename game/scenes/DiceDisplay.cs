using Godot;
using System;

public partial class DiceDisplay : Node2D {
	private Dice<DiceSide> _dice;
	private DiceActionResource _diceActionsResource;

	public override void _Ready() {
		// Load the DiceActions resource
		_diceActionsResource = (DiceActionResource)GD.Load("res://resources/DiceActions/DiceActions.tres");

		if (_diceActionsResource == null) {
			GD.PrintErr("Failed to load DiceActions.tres");
			return;
		}

		// Generate a random D4 dice using actions from the resource
		_dice = CreateRandomD4Dice();

		// Print dice information for debugging
		GD.Print($"Generated Dice: {_dice.Name}");
		GD.Print($"Number of Sides: {_dice.Sides}");

		// Display the dice information
		DisplayDice();
	}

	private Dice<DiceSide> CreateRandomD4Dice() {
		var actions = new Godot.Collections.Array<DiceSide>();

		// Randomly select actions from the loaded resource
		var random = new Random();
		for (int i = 0; i < 4; i++) {
			int randomIndex = random.Next(_diceActionsResource.Actions.Count);
			var action = _diceActionsResource.Actions[randomIndex];
			actions.Add(new DiceSide(action.Name, action.Abbreviation, action.Description, action.Targets, action.Colors));
		}

		return new Dice<DiceSide>(Guid.NewGuid().ToString(), "D4", actions, DiceLocation.None);
	}

	private void DisplayDice() {
		// Create a ColorRect for background color
		var background = new ColorRect {
			Color = new Color(0.2f, 0.2f, 0.2f, 1.0f),
			Size = new Vector2(400, 300)
		};
		AddChild(background);

		// Create a label to display the dice name
		var diceNameLabel = new Label {
			Text = $"Dice: {_dice.Name}"
		};
		diceNameLabel.SetPosition(new Vector2(10, 10));
		AddChild(diceNameLabel);

		// Display each side of the dice
		for (int i = 0; i < _dice.Sides; i++) {
			var action = _dice.Actions[i];
			GD.Print($"Side {i + 1}: {action.Name} - {action.Description}"); // Print action information for debugging

			var actionLabel = new Label {
				Text = $"Side {i + 1}: {action.Name} - {action.Description}"
			};
			actionLabel.SetPosition(new Vector2(10, 40 + i * 30));
			AddChild(actionLabel);
		}
	}
}