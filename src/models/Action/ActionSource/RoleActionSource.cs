using Godot;
using DiceRoll.Models.Roles;

namespace DiceRoll.Models.Actions.Sources;

[Tool]
[GlobalClass]
public partial class RoleActionSource : ActionSource {
    [Export] public Role? Role { get; set; }
    public RoleActionSource() { }
}