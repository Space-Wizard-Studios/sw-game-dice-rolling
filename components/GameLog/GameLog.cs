using Godot;
using DiceRoll.Stores;

namespace DiceRoll.Components;

public partial class GameLog : ScrollContainer {
	[Export] public BoxContainer? _messageContainerNode;
	[Export] public VBoxContainer? _messageTemplateNode;
	[Export] public Label? _headingLabelTemplateNode;
	[Export] public Label? _timestampLabelTemplateNode;
	[Export] public RichTextLabel? _lineTemplateNode;

	public override void _Ready() {
		// Connect to the GameLogStore signal
		GameLogStore.Instance.Connect("GameLogUpdatedEventHandler", Callable.From(OnGameLogUpdated));
		// Initialize the game log
		UpdateGameLog();
		// Clear template texts
		ClearTemplateTexts();
	}

	private void OnGameLogUpdated() {
		GD.Print("GameLogUpdatedEventHandler signal received");
		AddMessageToLog(GameLogStore.Instance.Messages[^1]);
	}

	private void UpdateGameLog() {
		GD.Print("UpdateGameLog called");

		if (_messageTemplateNode == null) {
			GD.PrintErr("MessageTemplate node is not assigned.");
			return;
		}

		_messageTemplateNode.Visible = false;

		foreach (var message in GameLogStore.Instance.Messages) {
			AddMessageToLog(message);
		}
	}

	private void AddMessageToLog(GameLogMessage message) {
		if (_messageTemplateNode == null || _messageContainerNode == null) {
			GD.PrintErr("MessageTemplate or MessageContainer node is not assigned.");
			return;
		}

		// Duplicate the message template
		var messageTemplate = (VBoxContainer)_messageTemplateNode.Duplicate();
		messageTemplate.Visible = true;

		// Update the header and timestamp
		UpdateHeaderAndTimestamp(messageTemplate, message);

		// Update the lines
		UpdateLines(messageTemplate, message);

		// Add the message template to the container
		_messageContainerNode.AddChild(messageTemplate);
	}

	private void UpdateHeaderAndTimestamp(VBoxContainer messageTemplate, GameLogMessage message) {
		var headerTemplate = messageTemplate.GetNode<HBoxContainer>("HeaderTemplate");
		var headingLabel = headerTemplate.GetNode<Label>("Heading");
		var timestampLabel = headerTemplate.GetNode<Label>("Timestamp");

		headingLabel.Text = message.Heading;
		timestampLabel.Text = message.Timestamp;
	}

	private void UpdateLines(VBoxContainer messageTemplate, GameLogMessage message) {
		if (_lineTemplateNode == null) {
			GD.PrintErr("LineTemplate node is not assigned.");
			return;
		}

		var linesContainer = messageTemplate.GetNode<VBoxContainer>("LinesContainer");

		foreach (var line in message.Lines) {
			var lineLabel = (RichTextLabel)_lineTemplateNode.Duplicate();
			lineLabel.Visible = true;
			lineLabel.BbcodeEnabled = true;
			lineLabel.Clear();
			lineLabel.AppendText($"[color={GetColorForLineType(line.Type)}]{line.Text}[/color]");
			linesContainer.AddChild(lineLabel);
		}
	}

	private void ClearTemplateTexts() {
		if (_headingLabelTemplateNode != null) _headingLabelTemplateNode.Text = "";
		if (_timestampLabelTemplateNode != null) _timestampLabelTemplateNode.Text = "";
		if (_lineTemplateNode != null) _lineTemplateNode.Text = "";
	}

	private static string GetColorForLineType(GameLogLineType type) {
		return type switch {
			GameLogLineType.Default => "white",
			GameLogLineType.Error => "red",
			GameLogLineType.Info => "blue",
			GameLogLineType.Success => "green",
			GameLogLineType.Warning => "yellow",
			GameLogLineType.Wip => "gray",
			_ => "white",
		};
	}
}