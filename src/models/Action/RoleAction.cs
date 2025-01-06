using Godot;

namespace DiceRoll.Models.Actions;

[Tool]
[GlobalClass]
public partial class RoleAction : Resource {
    [Export] public ActionType? Type { get; set; }

    public RoleAction() { }

    public RoleAction(ActionType type) {
        Type = type;
    }
}