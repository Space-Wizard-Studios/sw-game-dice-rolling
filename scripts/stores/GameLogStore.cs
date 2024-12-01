using Godot;
using System;
using System.Collections.Generic;

namespace DiceRoll.Stores {
	public enum GameLogLineType {
		Error,
		Info,
		Success,
		Warning,
		Wip,
	}

	public class GameLogMessage {
		public List<GameLogLine> Lines { get; set; } = new List<GameLogLine>();
		public string GameState { get; set; }
	}

	public class GameLogLine {
		public string Text { get; set; }
		public GameLogLineType Type { get; set; } = GameLogLineType.Info;
	}

	public partial class GameLogStore : Node {
		private static GameLogStore _instance;
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
}