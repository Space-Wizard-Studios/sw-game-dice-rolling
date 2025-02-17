using Godot;

namespace DiceRolling.Models.Characters;

[Tool]
[GlobalClass]
public partial class CharacterCategory : Resource {
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
}
