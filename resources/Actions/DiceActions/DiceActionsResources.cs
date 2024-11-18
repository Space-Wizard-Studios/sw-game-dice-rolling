using Godot;

namespace DiceRoll.Models;

[Tool]
public partial class DiceActionsResources : Resource {
    [Export]
    public Godot.Collections.Array<DiceAction> DiceActions { get; set; } = new Godot.Collections.Array<DiceAction>();

    public DiceActionsResources() { }
}
