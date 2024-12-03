using Godot;
using System;
using System.Collections.Generic;
namespace DiceRoll.Stores;

public enum GameLogLineType {
	Default,
	Error,
	Info,
	Success,
	Warning,
	Wip,
}
public class GameLogMessage {
	public string Heading { get; }
	public string Timestamp { get; }
	public List<GameLogLine> Lines { get; }

	public GameLogMessage(string heading, string timestamp, List<GameLogLine> lines) {
		if (string.IsNullOrWhiteSpace(heading)) {
			throw new ArgumentException("Heading cannot be null or empty", nameof(heading));
		}
		if (string.IsNullOrWhiteSpace(timestamp)) {
			throw new ArgumentException("Timestamp cannot be null or empty", nameof(timestamp));
		}
		Heading = heading;
		Timestamp = timestamp;
		Lines = lines ?? throw new ArgumentNullException(nameof(lines));
	}
}

public class GameLogLine {
	public GameLogLineType Type { get; }
	public string Text { get; }

	public GameLogLine(GameLogLineType type, string text) {
		Type = type;
		Text = text ?? throw new ArgumentNullException(nameof(text));
	}
}

public partial class GameLogStore : Node {
	private static GameLogStore? _instance;
	public static GameLogStore Instance {
		get {
			_instance ??= new GameLogStore();
			return _instance;
		}
	}

	[Signal]
	public delegate void GameLogUpdatedEventHandler();

	[Signal]
	public delegate void GameLogLineAddedEventHandler();

	public List<GameLogMessage> Messages { get; private set; } = new List<GameLogMessage>();

	private GameLogStore() {
		AddUserSignal(nameof(GameLogUpdatedEventHandler));
		AddUserSignal(nameof(GameLogLineAddedEventHandler));
	}

	public void AddGameLogMessage(GameLogMessage message) {
		GD.Print("AddGameLogMessage called with heading: ", message.Heading);
		Messages.Add(message);
		EmitSignal(nameof(GameLogUpdatedEventHandler));
	}

	public void AddGameLogLine(GameLogLine line) {
		GD.Print("AddGameLogLine called with text: ", line.Text);
		if (Messages.Count == 0) {
			GD.PrintErr("No messages in GameLogStore to add a line to.");
			return;
		}
		Messages[^1].Lines.Add(line);
		EmitSignal(nameof(GameLogLineAddedEventHandler));
	}
}