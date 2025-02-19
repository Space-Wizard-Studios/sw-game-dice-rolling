using Godot;
using DiceRolling.Interfaces.Dice;

namespace DiceRolling.Models.Dice;

public partial class DiceLocation : Resource, IDiceLocation {
    [Export] public DiceLocationCategory LocationCategory { get; set; }
    [Export] public string? CharacterId { get; set; }

    public DiceLocation(DiceLocationCategory locationCategory, string? characterId = null) {
        LocationCategory = locationCategory;
        CharacterId = characterId;
    }
}