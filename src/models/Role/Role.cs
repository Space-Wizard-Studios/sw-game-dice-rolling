using Godot;
using DiceRolling.Models.Attributes;
using DiceRolling.Models.Actions;

namespace DiceRolling.Models.Roles;

[Tool]
[GlobalClass]
public partial class Role : Resource
{
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; } = new();
    [Export] public Godot.Collections.Array<RoleAction> RoleActions { get; set; } = new();
}