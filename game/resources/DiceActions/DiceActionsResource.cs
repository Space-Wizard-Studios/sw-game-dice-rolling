using Godot;
using System.Collections.Generic;

[Tool]
public partial class DiceActionsResource : Resource {
	[Export]
	public Godot.Collections.Array<DiceAction> DiceActions { get; set; } = new Godot.Collections.Array<DiceAction>();

	public DiceActionsResource() { }
}
