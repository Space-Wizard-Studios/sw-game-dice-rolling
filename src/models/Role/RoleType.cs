using Godot;
using System;
using DiceRolling.Models.Attributes;
using DiceRolling.Models.Actions;
using DiceRolling.Interfaces.Role;

namespace DiceRolling.Models.Roles;

[Tool]
[GlobalClass]
public partial class RoleType : Resource, IRole {
    [Export] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; } = [];
    [Export] public Godot.Collections.Array<RoleAction> RoleActions { get; set; } = [];
}