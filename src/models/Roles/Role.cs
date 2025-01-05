using Godot;
using DiceRoll.Models.Attributes;

namespace DiceRoll.Models;

/// <summary>
/// Represents a role in the game with attributes and actions.
/// </summary>
[Tool]
public partial class Role : Resource {
    [Export] public string? Name { get; set; }

    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }

    [Export] public Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; } = [];

    // [Export] public Godot.Collections.Array<WeaponAction> RoleActions { get; set; } = [];
}