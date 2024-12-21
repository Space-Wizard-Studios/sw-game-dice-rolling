using Godot;
using DiceRoll.Models.CharacterActions;

namespace DiceRoll.Models;

[Tool]
public partial class Role : Resource {
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; } = [];
    [Export] public Godot.Collections.Array<CharacterAction> RoleActions { get; set; } = [];
}