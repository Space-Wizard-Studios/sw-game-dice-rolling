using Godot;
using System;
using System.Collections.Generic;

using DiceRolling.Logs;

namespace DiceRolling.Battle;

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

    // private void RunDiceTests() {
    //     if (DiceManaResources is null) {
    //         GD.PrintErr("DiceManaResources is not assigned");
    //         return;
    //     }

    //     var dice = DiceFactory.CreateD20(DiceManaResources);
    //     GD.Print($"Generated Dice: {dice.Name} with {dice.Sides} sides");

    //     var diceTimestamp = DateTime.Now.ToString("HH:mm");

    //     // Add a message to the log system with the dice sides as lines
    //     var diceLogLines = new List<GameLogLine>();
    //     for (int i = 0; i < dice.Sides; i++) {
    //         var mana = dice.Manas[i];
    //         var line = new GameLogLine(GameLogLineType.Default, $"[url={mana.Name}]Side {i + 1}: {mana.Name}[/url]");
    //         diceLogLines.Add(line);
    //     }

    //     var diceLogMessage = new GameLogMessage(dice.Name, diceTimestamp, diceLogLines);
    //     GameLogStore.Instance.AddGameLogMessage(diceLogMessage);
    // }
}
