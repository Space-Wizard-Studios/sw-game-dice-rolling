using Godot;

namespace DiceRolling.Characters;

/// <summary>
/// Representa uma categoria de um personagem.
/// </summary>
[Tool]
[GlobalClass]
public partial class CharacterCategory : Resource {
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
}
