using Godot;

namespace DiceRoll.Models;

[Tool]
public partial class CommonActionsResources : Resource {
    [Export]
    public Godot.Collections.Array<CommonAction> CommonActions { get; set; } = new Godot.Collections.Array<CommonAction>();

    public CommonActionsResources() { }
}
