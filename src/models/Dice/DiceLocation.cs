using Godot;
using DiceRolling.Interfaces.Dice;

namespace DiceRolling.Models.Dice;

public partial class DiceLocation(DiceLocationCategory locationCategory, string? characterId = null) : Resource, IDiceLocation {
    [Export] public DiceLocationCategory LocationCategory { get; set; } = locationCategory;
    [Export] public string? CharacterId { get; set; } = characterId;
}