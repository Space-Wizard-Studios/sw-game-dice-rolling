using Godot;
using System;
using System.Collections.Generic;
namespace DiceRoll.Stores;

public enum GameLogLineType {
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

	public List<GameLogMessage> Messages { get; private set; } = new List<GameLogMessage>();

	private GameLogStore() {
		AddUserSignal(nameof(GameLogUpdatedEventHandler));
	}

	public void AddGameLogMessage(GameLogMessage message) {
		Messages.Add(message);
		EmitSignal(nameof(GameLogUpdatedEventHandler));
	}

	public void AddGameLogLine(GameLogLine line) {
		if (Messages.Count == 0) {
			throw new InvalidOperationException("No messages to add a line to.");
		}

		var lastMessage = Messages[^1];
		lastMessage.Lines.Add(line);
		EmitSignal(nameof(GameLogUpdatedEventHandler));
	}
}