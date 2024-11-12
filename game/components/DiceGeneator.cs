using Godot;
using System;
using System.Linq;

public partial class DiceGeneator : Node {
	[Export]
	public DiceActionsResource DiceActionsResource { get; set; }

	[Export]
	public DiceIconsResource DiceIconResource { get; set; }

	private Dice<DiceSide> _dice;

	private const int MinSides = 4;
	private const int MaxSides = 100;
	private static readonly int[] ValidSides = { 4, 6, 8, 10, 20, 100 };

	public override void _Ready() {
		if (!ValidateResources()) return;

		_dice = CreateRandomDice();
		GD.Print($"Generated Dice: {_dice.Name}");
		GD.Print($"Number of Sides: {_dice.Sides}");

		UpdateDiceDisplay();

		var updateButton = GetNode<Button>("UpdateButton");
		if (updateButton != null) {
			updateButton.Connect("pressed", new Callable(this, nameof(OnUpdateButtonPressed)));
		}
		else {
			GD.PrintErr("UpdateButton node not found");
		}
	}

	private bool ValidateResources() {
		if (DiceActionsResource == null) {
			GD.PrintErr("DiceActionsResource is not assigned");
			return false;
		}

		if (DiceIconResource == null) {
			GD.PrintErr("DiceIconResource is not assigned");
			return false;
		}

		return true;
	}

	private Dice<DiceSide> CreateRandomDice() {
		var random = new Random();
		int sides = ValidSides[random.Next(ValidSides.Length)];

		var actions = new Godot.Collections.Array<DiceSide>(
			Enumerable.Range(0, sides).Select(_ => {
				int randomIndex = random.Next(DiceActionsResource.Actions.Count);
				var action = DiceActionsResource.Actions[randomIndex];
				GD.Print($"Selected Action: {action.Name} - {action.Description}");
				return new DiceSide(action.Name, action.Abbreviation, action.Description, action.BackgroundColor, action.TextColor);
			}).ToArray()
		);

		return new Dice<DiceSide>(Guid.NewGuid().ToString(), $"D{sides}", actions, DiceLocation.None);
	}

	private void UpdateDiceDisplay() {
		var diceDisplay = GetNode<Control>("DiceDisplay");
		var diceNameLabel = diceDisplay.GetNode<Label>("DiceContainer/DiceName");
		diceNameLabel.Text = _dice.Name;

		var diceIcon = diceDisplay.GetNode<TextureRect>("DiceContainer/DiceIcon");
		diceIcon.Texture = DiceIconResource.GetIconForSides(_dice.Sides);

		var actionsListContainer = diceDisplay.GetNode<VBoxContainer>("DiceInfo/ActionsInfo/ActionsList");

		// Hide the ActionItemTemplate
		var actionItemTemplate = actionsListContainer.GetNode<Control>("ActionItemTemplate");
		if (actionItemTemplate != null) {
			actionItemTemplate.Visible = false;
		}

		// Clear existing children except the template
		foreach (Node child in actionsListContainer.GetChildren()) {
			if (child != actionItemTemplate) {
				child.QueueFree();
			}
		}

		foreach (var action in _dice.Actions.Select((value, index) => new { value, index })) {
			var actionItem = CreateActionItem(action.value, action.index + 1, actionItemTemplate);
			actionsListContainer.AddChild(actionItem);
		}
	}

	private Control CreateActionItem(DiceSide action, int sideNumber, Control actionItemTemplate) {
		if (actionItemTemplate == null) {
			GD.PrintErr("ActionItemTemplate node not found");
			return null;
		}

		var actionItem = actionItemTemplate.Duplicate() as Control;
		if (actionItem == null) {
			GD.PrintErr("Failed to duplicate ActionItemTemplate");
			return null;
		}

		actionItem.Visible = true;

		var actionColor = actionItem.GetNode<ColorRect>("ActionColor");
		if (actionColor == null) {
			GD.PrintErr("ActionColor node not found in ActionItemTemplate");
			return null;
		}
		actionColor.Color = action.BackgroundColor;

		var actionLabel = actionItem.GetNode<Label>("ActionLabel");
		if (actionLabel == null) {
			GD.PrintErr("ActionLabel node not found in ActionItemTemplate");
			return null;
		}
		actionLabel.Text = $"Side {sideNumber}: {action.Name} - {action.Description}";
		actionLabel.Modulate = action.TextColor;

		return actionItem;
	}

	private void OnUpdateButtonPressed() {
		_dice = CreateRandomDice();
		UpdateDiceDisplay();
	}
}
