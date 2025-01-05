using Godot;
using DiceRoll.Models.Attributes;
using DiceRoll.Models.Actions;

namespace DiceRoll.Models.Roles;

/// <summary>
/// Represents a role in the game with attributes and actions.
/// </summary>
[Tool]
public partial class Role : Resource {
    [Export] public string? Name { get; set; }

    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }

    [Export] public Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; } = [];

    [Export] public ActionSource? RoleActionSource { get; set; }
}