using Godot;
using DiceRoll.Stores;

namespace DiceRoll.Components;

public partial class GameLog : ScrollContainer {
	[Export] private NodePath _messageContainerTemplatePath;
	[Export] private NodePath _lineTemplatePath;

	private VBoxContainer _messageContainerTemplate;
	private RichTextLabel _lineTemplate;

	public override void _Ready() {
		GD.Print("GameLog _Ready called");

		// Get the template nodes
		_messageContainerTemplate = GetNode<VBoxContainer>(_messageContainerTemplatePath);
		_lineTemplate = GetNode<RichTextLabel>(_lineTemplatePath);

		GameLogStore.Instance.Connect("GameLogUpdatedEventHandler", Callable.From(OnGameLogUpdated));
		UpdateGameLog();
	}

	private void OnGameLogUpdated() {
		GD.Print("GameLogUpdatedEventHandler signal received");
		UpdateGameLog();
	}

	private void UpdateGameLog() {
		GD.Print("UpdateGameLog called");

		// Remove all existing children except the templates
		foreach (Node child in GetChildren()) {
			if (child != _messageContainerTemplate && child != _lineTemplate) {
				GD.Print("Removing child: ", child.Name);
				child.QueueFree();
			}
		}

		// Add new messages
		foreach (var message in GameLogStore.Instance.Messages) {
			GD.Print("Adding message: ", message.GameState);
			var messageContainer = (VBoxContainer)_messageContainerTemplate.Duplicate();
			messageContainer.Visible = true;

			foreach (var line in message.Lines) {
				GD.Print("Adding line: ", line.Text);
				var lineLabel = (RichTextLabel)_lineTemplate.Duplicate();
				lineLabel.Visible = true;
				lineLabel.AppendText($"[color=white]{line.Text}[/color]");
				messageContainer.AddChild(lineLabel);
			}
			AddChild(messageContainer);
		}
	}
}