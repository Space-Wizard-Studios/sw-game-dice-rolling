using Godot;
using System;
using DiceRoll.Models;
using DiceRoll.Stores;

namespace DiceRoll.Scenes.Gameplay;

public partial class Battle : Control {
	[Export]
	public PackedScene GameLogScene { get; set; }

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
		GD.Print("Character role: ", CharacterStore.Instance.GetCharacterById(characterIds[0]).Role.Name);
		GD.Print("Character dice capacity: ", CharacterStore.Instance.GetCharacterById(characterIds[0]).DiceCapacity);

		// GAME LOG TESTS
		// Instantiate and add the GameLog UI component
		var newMessage = new GameLogMessage(null, null, null);
		GameLogStore.Instance.AddGameLogMessage(newMessage);
		var newLine = new GameLogLine(GameLogLineType.Info, null);
		GameLogStore.Instance.AddGameLogLine(newLine);
	}
}