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
		GameLogStore.Instance.Connect("GameLogUpdatedEventHandler", Callable.From(OnGameLogUpdated));
		UpdateGameLog();
		_headingLabelTemplateNode.Text = "";
		_timestampLabelTemplateNode.Text = "";
		_lineTemplateNode.Text = "";
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
		if (_messageTemplateNode == null) {
			GD.PrintErr("MessageTemplate node is not assigned.");
			return;
		}

		var messageTemplate = (VBoxContainer)_messageTemplateNode.Duplicate();
		messageTemplate.Visible = true;

		// Clear texts inside the labels and rich text
		var headerTemplate = messageTemplate.GetNode<HBoxContainer>("HeaderTemplate");
		var headingLabel = headerTemplate.GetNode<Label>("Heading");
		var timestampLabel = headerTemplate.GetNode<Label>("Timestamp");
		headingLabel.Text = "";
		timestampLabel.Text = "";

		var linesContainer = messageTemplate.GetNode<VBoxContainer>("LinesContainer");

		// Update Heading and Timestamp labels
		headingLabel.Text = message.Heading;
		timestampLabel.Text = message.Timestamp;

		// Update Lines
		foreach (var line in message.Lines) {
			var lineLabel = (RichTextLabel)_lineTemplateNode.Duplicate();
			lineLabel.Visible = true;
			lineLabel.BbcodeEnabled = true;
			lineLabel.Clear();
			lineLabel.AppendText($"[color={GetColorForLineType(line.Type)}]{line.Text}[/color]");
			linesContainer.AddChild(lineLabel);
		}

		_messageContainerNode?.AddChild(messageTemplate);
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