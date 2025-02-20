using Godot;
using System;

namespace DiceRolling.Roles;

[Tool]
[GlobalClass]
public partial class RoleType : Resource, IRole {
    [Export] public string Id { get; private set; } = Guid.NewGuid().ToString();
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; } = [];
    [Export] public Godot.Collections.Array<RoleAction> RoleActions { get; set; } = [];
}