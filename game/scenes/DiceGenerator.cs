using Godot;
using System;
using System.Linq;

public partial class DiceGenerator : Node {
	[Export]
	public DiceActionsResource DiceActionsResource { get; set; }

	[Export]
	public DiceIconsResource DiceIconResource { get; set; }

	[Export]
	public DiceDisplay DiceDisplay;
	private Dice<DiceSide> _dice;

	private static readonly int[] ValidSides = { 4, 6, 8, 10, 20, 100 };

	public override void _Ready() {
		if (!ValidateResources()) return;

		if (DiceDisplay == null) {
			GD.PrintErr("DiceDisplay node not found");
			return;
		}

		_dice = CreateRandomDice();
		GD.Print($"Generated Dice: {_dice.Name}");
		GD.Print($"Number of Sides: {_dice.Sides}");

		UpdateDiceDisplay();
		HideRollResult();

		var updateButton = GetNode<Button>("UpdateButton");
		if (updateButton != null) {
			updateButton.Connect("pressed", new Callable(this, nameof(OnUpdateButtonPressed)));
		}
		else {
			GD.PrintErr("UpdateButton node not found");
		}

		var rollButton = GetNode<Button>("RollButton");
		if (rollButton != null) {
			rollButton.Connect("pressed", new Callable(this, nameof(OnRollButtonPressed)));
		}
		else {
			GD.PrintErr("RollButton node not found");
		}
	}

	private void UpdateDiceDisplay() {
		DiceDisplay.DiceNameLabel.Text = _dice.Name;
		DiceDisplay.DiceIcon.Texture = DiceIconResource.GetIconForSides(_dice.Sides).Icon;

		var actionsListContainer = DiceDisplay.ActionsListContainer;
		var actionItemTemplate = DiceDisplay.ActionItemTemplate;
		if (actionItemTemplate != null) {
			actionItemTemplate.Visible = false;
		}

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

		var actionItem = actionItemTemplate.Duplicate() as DisplayActionItem;
		if (actionItem == null) {
			GD.PrintErr("Failed to duplicate ActionItemTemplate");
			return null;
		}

		actionItem.Visible = true;

		var actionItemBackground = actionItem.ActionItemBackground;
		if (actionItemBackground == null) {
			GD.PrintErr("ActionItemBackground node not found in ActionItemTemplate");
			return null;
		}
		actionItemBackground.Color = action.BackgroundColor;

		var actionLabel = actionItem.ActionItemLabel;
		if (actionLabel == null) {
			GD.PrintErr("ActionItemLabel node not found in ActionItemTemplate");
			return null;
		}
		actionLabel.Text = $"Side {sideNumber}: {action.Name} - {action.Description}";
		actionLabel.Modulate = action.TextColor;

		return actionItem;
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

		return new Dice<DiceSide>(Guid.NewGuid().ToString(), $"Dado D{sides}", actions, DiceLocation.None);
	}

	private void OnUpdateButtonPressed() {
		_dice = CreateRandomDice();
		UpdateDiceDisplay();
		HideRollResult();
	}

	private void OnRollButtonPressed() {
		var random = new Random();
		int rolledSide = random.Next(1, _dice.Sides + 1);
		var action = _dice.Actions[rolledSide - 1];

		var rollResultLabel = GetNode<RichTextLabel>("RollResult");
		if (rollResultLabel != null) {
			rollResultLabel.BbcodeEnabled = true;
			var diceIconResult = DiceIconResource.GetIconForSides(_dice.Sides);
			if (diceIconResult != null) {
				rollResultLabel.Text = $"Rolled {rolledSide} on {_dice.Name} ([img=24x24]{diceIconResult.Path}[/img]).\nAction: {action.Name} - {action.Description}";
			}
			else {
				rollResultLabel.Text = $"Rolled {rolledSide} on {_dice.Name}.\nAction: {action.Name} - {action.Description}";
			}
			rollResultLabel.Visible = true;
		}
		else {
			GD.PrintErr("RollResult label not found");
		}
	}

	private void HideRollResult() {
		var rollResultLabel = GetNode<RichTextLabel>("RollResult");
		if (rollResultLabel != null) {
			rollResultLabel.Visible = false;
		}
		else {
			GD.PrintErr("RollResult label not found");
		}
	}
}