using Godot;
using System;
using System.Linq;
using DiceRolling.Models.Characters;
using DiceRolling.Models.Characters.Locations;

namespace DiceRolling.Stores;

[Tool]
[GlobalClass]
public partial class CharacterStore : Resource
{
    private static CharacterStore? _instance;
    public static CharacterStore Instance
    {
        get
        {
            _instance ??= new CharacterStore();
            return _instance;
        }
    }

    [Export]
    public Godot.Collections.Array<Character> Characters { get; private set; } = [];

    public void AddCharacter(Character character)
    {
        character.InitializeAttributes();
        Characters.Add(character);
    }

    public void RemoveCharacter(string characterID)
    {
        Characters = [.. Characters.Where(c => c.Id != characterID)];
    }

    public Godot.Collections.Array<string> GetAllCharacterIds()
    {
        return [.. Characters.Select(c => c.Id)];
    }

    public Character GetCharacterById(string characterID)
    {
        var character = Characters.FirstOrDefault(c => c.Id == characterID) ?? throw new Exception($"Character with ID {characterID} not found");
        character.InitializeAttributes();
        return character;
    }

    public void SetCharacterLocation(string characterID, CharacterLocation location, int slotIndex)
    {
        var character = GetCharacterById(characterID);
        character.Location = location;
        character.SlotIndex = slotIndex;
    }

    public (CharacterLocation? location, int slotIndex) GetCharacterLocation(string characterID)
    {
        var character = GetCharacterById(characterID);
        return (character.Location, character.SlotIndex);
    }

    public void UpdateCharacter(string characterID, Godot.Collections.Dictionary<string, Variant> updatedFields)
    {
        var character = GetCharacterById(characterID);
        foreach (var field in updatedFields)
        {
            var property = character.GetType().GetProperty(field.Key);
            property?.SetValue(character, field.Value);
        }
        character.InitializeAttributes();
    }
    public CharacterStore() { }
}