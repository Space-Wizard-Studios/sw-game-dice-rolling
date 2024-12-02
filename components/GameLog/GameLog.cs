using Godot;
using DiceRoll.Stores;

namespace DiceRoll.Components;

public partial class GameLog : ScrollContainer {
	[Export] public VBoxContainer _messageTemplateNode;
	[Export] public RichTextLabel _lineTemplateNode;
	[Export] public Label _headingLabelTemplateNode;
	[Export] public Label _timestampLabelTemplateNode;

	public override void _Ready() {
		GameLogStore.Instance.Connect("GameLogUpdatedEventHandler", Callable.From(OnGameLogUpdated));
		UpdateGameLog();
	}

	private void OnGameLogUpdated() {
		GD.Print("GameLogUpdatedEventHandler signal received");
		AddMessageToLog(GameLogStore.Instance.Messages[^1]);
	}

	private void UpdateGameLog() {
		GD.Print("UpdateGameLog called");
		_messageTemplateNode.Visible = false;
		_headingLabelTemplateNode.Visible = false;
		_timestampLabelTemplateNode.Visible = false;
		_lineTemplateNode.Visible = false;

		foreach (var message in GameLogStore.Instance.Messages) {
			AddMessageToLog(message);
		}
	}

	private void AddMessageToLog(GameLogMessage message) {
		var messageContainer = (VBoxContainer)_messageTemplateNode.Duplicate();
		messageContainer.Visible = true;

		// Update Heading and Timestamp labels
		var headerTemplate = messageContainer.GetNode<HBoxContainer>("HeaderTemplate");
		var headingLabel = (Label)_headingLabelTemplateNode.Duplicate();
		headingLabel.Visible = true;
		headingLabel.Text = message.Heading;
		headerTemplate.AddChild(headingLabel);

		var timestampLabel = (Label)_timestampLabelTemplateNode.Duplicate();
		timestampLabel.Visible = true;
		timestampLabel.Text = message.Timestamp;
		headerTemplate.AddChild(timestampLabel);

		var linesContainer = messageContainer.GetNode<VBoxContainer>("LinesContainer");
		foreach (var line in message.Lines) {
			var lineLabel = (RichTextLabel)_lineTemplateNode.Duplicate();
			lineLabel.Visible = true;
			lineLabel.BbcodeEnabled = true;
			lineLabel.AppendText($"[color={GetColorForLineType(line.Type)}]{line.Text}[/color]");
			linesContainer.AddChild(lineLabel);
		}
		AddChild(messageContainer);
	}

	private static string GetColorForLineType(GameLogLineType type) {
		return type switch {
			GameLogLineType.Error => "red",
			GameLogLineType.Info => "blue",
			GameLogLineType.Success => "green",
			GameLogLineType.Warning => "yellow",
			GameLogLineType.Wip => "gray",
			_ => "white",
		};
	}
}