using Godot;
using DiceRolling.Actions;

namespace DiceRolling.Roles;

[Tool]
public partial class RoleAction : Resource {
    [Export] public ActionType? Type { get; set; }

    public RoleAction() { }

    public RoleAction(ActionType type) {
        Type = type;
    }
}