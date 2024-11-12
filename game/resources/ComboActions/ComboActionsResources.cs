using Godot;
using System.Collections.Generic;

[Tool]
public partial class ComboActionsResources : Resource {
    [Export]
    public Godot.Collections.Array<ComboAction> ComboActions { get; set; } = new Godot.Collections.Array<ComboAction>();

    public ComboActionsResources() { }
}
