using Godot;
using System;
using System.Collections.Generic;

using DiceRolling.Logs;

namespace DiceRolling.Controllers;

public partial class BattleManager : Node3D {
    public override void _Ready() {
        RunGameLogTests();
    }

    // TODO - MOVER A LÓGICA DE LOG MESSAGES PARA O EVENT BUS
    private static void RunGameLogTests() {
        // GD.Print("RunGameLogTests called");

        var timestamp = DateTime.Now.ToString("HH:mm");
        var lines = new List<GameLogLine>();

        var newMessage = new GameLogMessage("Example Heading", timestamp, lines);
        // GD.Print("Adding new message to GameLogStore");
        GameLogStore.Instance.AddGameLogMessage(newMessage);

        var newLine = new GameLogLine(GameLogLineType.Info, "This is an informational message.");
        // GD.Print("Adding new line to GameLogStore");
        GameLogStore.Instance.AddGameLogLine(newLine);
    }
}
