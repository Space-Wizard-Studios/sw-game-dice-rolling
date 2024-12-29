using Godot;
using System;
using System.Collections.Generic;
using DiceRoll.Models;
using DiceRoll.Stores;

namespace DiceRoll.Managers;

public partial class BattleManager : Node3D {
    [Export]
    public PackedScene? GameLogScene { get; set; }

    [Export]
    public DiceManaResources? DiceManaResources { get; set; }

    public override void _Ready() {
        GD.Print("Battle _Ready called");

        // Run character tests
        RunCharacterTests();

        // Run game log tests
        RunGameLogTests();

        // Run dice tests
        RunDiceTests();
    }

    private static void RunCharacterTests() {
        var newCharacter = new Character {
            Id = Guid.NewGuid().ToString(),
            Name = "Hero",
            Role = new Role { Name = "Warrior" },
            DiceCapacity = 3
        };

        CharacterStore.Instance.AddCharacter(newCharacter);

        var characterIds = CharacterStore.Instance.GetAllCharacterIds();
        GD.Print("Character count: ", CharacterStore.Instance.Characters.Count);
        GD.Print("Character IDs: ", string.Join(", ", characterIds));
        GD.Print("Character name: ", CharacterStore.Instance.GetCharacterById(characterIds[0]).Name);
        var character = CharacterStore.Instance.GetCharacterById(characterIds[0]);
        if (character?.Role != null) {
            GD.Print("Character role: ", character.Role.Name);
        }
        else {
            GD.Print("Character role: null");
        }
        GD.Print("Character dice capacity: ", CharacterStore.Instance.GetCharacterById(characterIds[0]).DiceCapacity);
    }

    // TODO - MOVER A LÓGICA DE LOG MESSAGES PARA O EVENT BUS
    private static void RunGameLogTests() {
        GD.Print("RunGameLogTests called");

        var timestamp = DateTime.Now.ToString("HH:mm");
        var lines = new List<GameLogLine>();

        var newMessage = new GameLogMessage("Example Heading", timestamp, lines);
        GD.Print("Adding new message to GameLogStore");
        GameLogStore.Instance.AddGameLogMessage(newMessage);

        var newLine = new GameLogLine(GameLogLineType.Info, "This is an informational message.");
        GD.Print("Adding new line to GameLogStore");
        GameLogStore.Instance.AddGameLogLine(newLine);
    }

    private void RunDiceTests() {
        if (DiceManaResources == null) {
            GD.PrintErr("DiceManaResources is not assigned");
            return;
        }

        var dice = DiceFactory.CreateD20(DiceManaResources);
        GD.Print($"Generated Dice: {dice.Name} with {dice.Sides} sides");

        var diceTimestamp = DateTime.Now.ToString("HH:mm");

        // Add a message to the log system with the dice sides as lines
        var diceLogLines = new List<GameLogLine>();
        for (int i = 0; i < dice.Sides; i++) {
            var mana = dice.Manas[i];
            var line = new GameLogLine(GameLogLineType.Default, $"[url={mana.Name}]Side {i + 1}: {mana.Name}[/url]");
            diceLogLines.Add(line);
        }

        var diceLogMessage = new GameLogMessage(dice.Name, diceTimestamp, diceLogLines);
        GameLogStore.Instance.AddGameLogMessage(diceLogMessage);
    }
}
