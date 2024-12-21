using Godot;

namespace DiceRoll.Models;

[Tool]
public partial class RolesResources : Resource {
    [Export]
    public Godot.Collections.Array<Role> Roles { get; set; } = [];

    public RolesResources() { }
}
