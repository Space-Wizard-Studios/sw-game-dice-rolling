using Godot;

namespace DiceRolling.Models.Roles;

/// <summary>
/// Represents a resource containing roles for the dice roll game.
/// </summary>
[Tool]
public partial class RolesResources : Resource
{
    [Export] public Godot.Collections.Array<Role> Roles { get; set; } = [];

    public RolesResources() { }
}
