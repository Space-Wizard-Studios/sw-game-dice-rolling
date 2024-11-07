using Godot;
using System;
using System.Collections.Generic;

public partial class Test : Node {
	[Export]
	public DiceActionResource DiceActionsResource { get; set; }

	private Dice<DiceSide> _dice;
	private Label _resultLabel;
	private VBoxContainer _probabilityContainer;

	public override void _Ready() {
		if (DiceActionsResource == null) {
			GD.PrintErr("DiceActionsResource is not assigned");
			return;
		}

		// Generate a random D20 dice using actions from the resource
		_dice = CreateRandomD20Dice();

		// Print dice information for debugging
		GD.Print($"Generated Dice: {_dice.Name}");
		GD.Print($"Number of Sides: {_dice.Sides}");

		// Create the main container
		var mainContainer = new HBoxContainer {
			SizeFlagsHorizontal = Control.SizeFlags.ExpandFill
		};
		AddChild(mainContainer);

		// Create a scrollable container for the action list
		var actionScrollContainer = new ScrollContainer {
			SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
			SizeFlagsVertical = Control.SizeFlags.ExpandFill
		};
		mainContainer.AddChild(actionScrollContainer);

		// Create a VBoxContainer for the action list
		var actionListContainer = new VBoxContainer {
			SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
			SizeFlagsVertical = Control.SizeFlags.ExpandFill
		};
		actionScrollContainer.AddChild(actionListContainer);

		// Display the dice information
		DisplayDice(actionListContainer);

		// Create a VBoxContainer for the probability list, roll button, and result
		_probabilityContainer = new VBoxContainer {
			SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
			SizeFlagsVertical = Control.SizeFlags.ExpandFill
		};
		mainContainer.AddChild(_probabilityContainer);

		// Create a button to roll the dice
		var rollButton = new Button {
			Text = "Roll Dice"
		};
		rollButton.Pressed += OnRollButtonPressed;
		_probabilityContainer.AddChild(rollButton);

		// Create a label to display the roll result
		_resultLabel = new Label {
			Text = "Roll Result: "
		};
		_probabilityContainer.AddChild(_resultLabel);

		// Display action probabilities
		DisplayProbabilities();

		// Assign the dice name to the DiceDisplay control component's DiceName label
		var diceDisplay = GetNode<Control>("DiceDisplay");
		var diceNameLabel = diceDisplay.GetNode<Label>("DiceName");
		diceNameLabel.Text = _dice.Name;
	}

	private Dice<DiceSide> CreateRandomD20Dice() {
		var actions = new Godot.Collections.Array<DiceSide>();

		// Randomly select actions from the loaded resource
		var random = new Random();
		for (int i = 0; i < 20; i++) {
			int randomIndex = random.Next(DiceActionsResource.Actions.Count);
			var action = DiceActionsResource.Actions[randomIndex];
			actions.Add(new DiceSide(action.Name, action.Abbreviation, action.Description, action.TextColor, action.BackgroundColor));
		}

		return new Dice<DiceSide>(Guid.NewGuid().ToString(), "D20", actions, DiceLocation.None);
	}

	private void DisplayDice(VBoxContainer actionListContainer) {
		// Display each side of the dice and calculate probabilities
		var actionCounts = new Dictionary<string, int>();
		for (int i = 0; i < _dice.Sides; i++) {
			var action = _dice.Actions[i];
			GD.Print($"Side {i + 1}: {action.Name} - {action.Description}"); // Print action information for debugging

			// Count the occurrences of each action
			if (!actionCounts.ContainsKey(action.Name)) {
				actionCounts[action.Name] = 0;
			}
			actionCounts[action.Name]++;

			// Create a ColorRect for the action background
			var actionBackground = new ColorRect {
				Color = action.BackgroundColor,
				SizeFlagsHorizontal = Control.SizeFlags.ExpandFill,
				SizeFlagsVertical = Control.SizeFlags.ShrinkCenter
			};
			actionListContainer.AddChild(actionBackground);

			// Create a label for the action text
			var actionLabel = new Label {
				Text = $"Side {i + 1}: {action.Name} - {action.Description}"
			};
			actionLabel.AddThemeColorOverride("font_color", action.TextColor);
			actionBackground.AddChild(actionLabel);
		}
	}

	private void DisplayProbabilities() {
		// Calculate and display action probabilities
		var actionCounts = new Dictionary<string, int>();
		for (int i = 0; i < _dice.Sides; i++) {
			var action = _dice.Actions[i];
			if (!actionCounts.ContainsKey(action.Name)) {
				actionCounts[action.Name] = 0;
			}
			actionCounts[action.Name]++;
		}

		foreach (var actionCount in actionCounts) {
			float probability = (float)actionCount.Value / _dice.Sides * 100;
			var probabilityLabel = new Label {
				Text = $"{actionCount.Key}: {probability:F2}%"
			};
			_probabilityContainer.AddChild(probabilityLabel);
		}
	}

	private void OnRollButtonPressed() {
		// Simulate a dice roll
		var random = new Random();
		int rollResult = random.Next(_dice.Sides);

		// Display the roll result
		var action = _dice.Actions[rollResult];
		_resultLabel.Text = $"Roll Result: {action.Name} - {action.Description}";
	}
}
