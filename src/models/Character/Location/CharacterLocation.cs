using Godot;

namespace DiceRoll.Models.Characters.Locations;

[Tool]
[GlobalClass]
public partial class CharacterLocation : Resource {
    [Export] public string Name { get; set; } = "";
    [Export] public string Description { get; set; } = "";
    [Export] public int TotalSlots { get; set; } = 6;
}