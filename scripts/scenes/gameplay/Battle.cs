using Godot;
using System;
using System.Collections.Generic;
using DiceRoll.Models;
using DiceRoll.Stores;

namespace DiceRoll.Scenes.Gameplay;

public partial class Battle : Control {
	[Export]
	public PackedScene GameLogScene { get; set; }

	public override void _Ready() {
		GD.Print("Battle _Ready called");

		// Instantiate and add the GameLog UI component
		if (GameLogScene != null) {
			var gameLog = (ScrollContainer)GameLogScene.Instantiate();
			AddChild(gameLog);
			GD.Print("GameLog instantiated and added to the scene");
		}
		else {
			GD.PrintErr("GameLogScene is not set in the editor.");
		}

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
		GD.Print("Character role: ", CharacterStore.Instance.GetCharacterById(characterIds[0]).Role.Name);
		GD.Print("Character dice capacity: ", CharacterStore.Instance.GetCharacterById(characterIds[0]).DiceCapacity);

		// GAME LOG TESTS
		var newMessage = new GameLogMessage {
			Lines = new List<GameLogLine>
			{
				new() { Text = "Welcome to the game!" }
			},
			GameState = "Introduction"
		};
		GameLogStore.Instance.AddGameLogMessage(newMessage);
		var newLine = new GameLogLine { Text = "Let's start the adventure." };
		GameLogStore.Instance.AddGameLogLine(newLine);
	}
}