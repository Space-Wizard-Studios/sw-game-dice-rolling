using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using DiceRoll.Models;
namespace DiceRoll.Stores;

public partial class CharacterStore : Node {
	private static CharacterStore _instance;
	public static CharacterStore Instance {
		get {
			_instance ??= new CharacterStore();
			return _instance;
		}
	}

	public List<Character> Characters { get; private set; } = new List<Character>();

	private CharacterStore() { }

	public void AddCharacter(Character character) {
		Characters.Add(character);
	}

	public void RemoveCharacter(string characterID) {
		Characters = Characters.Where(c => c.Id != characterID).ToList();
	}

	public List<string> GetAllCharacterIds() {
		return Characters.Select(c => c.Id).ToList();
	}

	public Character GetCharacterById(string characterID) {
		var character = Characters.FirstOrDefault(c => c.Id == characterID) ?? throw new Exception($"Character with ID {characterID} not found");
		return character;
	}

	public void UpdateCharacter(string characterID, Dictionary<string, object> updatedFields) {
		var character = GetCharacterById(characterID);
		foreach (var field in updatedFields) {
			var property = character.GetType().GetProperty(field.Key);
			property?.SetValue(character, field.Value);
		}
	}
}