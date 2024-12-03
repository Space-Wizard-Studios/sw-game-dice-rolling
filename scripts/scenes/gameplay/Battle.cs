using Godot;
using System;
using System.Collections.Generic;
using DiceRoll.Models;
using DiceRoll.Stores;

namespace DiceRoll.Scenes.Gameplay;

public partial class Battle : Control {
	[Export]
	public PackedScene? GameLogScene { get; set; }

	[Export]
	public DiceManaResources? DiceManaResources { get; set; }

	public override void _Ready() {
		GD.Print("Battle _Ready called");

		// CHARACTER TESTS
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

		// GAME LOG TESTS
		// Instantiate and add the GameLog UI component
		var timestamp = DateTime.Now.ToString("HH:mm");
		var lines = new List<GameLogLine>();

		var newMessage = new GameLogMessage("Example Heading", timestamp, lines);
		GameLogStore.Instance.AddGameLogMessage(newMessage);

		var newLine = new GameLogLine(GameLogLineType.Info, "This is an informational message.");
		GameLogStore.Instance.AddGameLogLine(newLine);

		// DICE TESTS
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