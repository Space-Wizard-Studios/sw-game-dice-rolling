using Godot;
using System.Collections.Generic;

[Tool]
public partial class DiceActionResource : Resource {
	[Export]
	public Godot.Collections.Array<DiceAction> Actions { get; set; } = new Godot.Collections.Array<DiceAction>();

	public DiceActionResource() { }
}