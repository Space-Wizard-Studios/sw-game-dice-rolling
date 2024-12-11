using Godot;
using System;
using System.Linq;
using DiceRoll.Models;

namespace DiceRoll.Stores;

[Tool]
[GlobalClass]
public partial class CharacterStore : Resource {
    private static CharacterStore? _instance;
    public static CharacterStore Instance {
        get {
            _instance ??= new CharacterStore();
            return _instance;
        }
    }

    [Export]
    public Godot.Collections.Array<Character> Characters { get; private set; } = new Godot.Collections.Array<Character>();

    public void AddCharacter(Character character) {
        Characters.Add(character);
    }

    public void RemoveCharacter(string characterID) {
        Characters = new Godot.Collections.Array<Character>(Characters.Where(c => c.Id != characterID));
    }

    public Godot.Collections.Array<string> GetAllCharacterIds() {
        return new Godot.Collections.Array<string>(Characters.Select(c => c.Id));
    }

    public Character GetCharacterById(string characterID) {
        var character = Characters.FirstOrDefault(c => c.Id == characterID) ?? throw new Exception($"Character with ID {characterID} not found");
        return character;
    }

    public void UpdateCharacter(string characterID, Godot.Collections.Dictionary<string, Variant> updatedFields) {
        var character = GetCharacterById(characterID);
        foreach (var field in updatedFields) {
            var property = character.GetType().GetProperty(field.Key);
            property?.SetValue(character, field.Value);
        }
    }

    public CharacterStore() { }
}