using Godot;
using System.Collections.Generic;

[Tool]
public partial class ComboAction : Resource {
	[Export]
	public string Name { get; set; }
	[Export]
	public string Description { get; set; }
	[Export]
	public Godot.Collections.Array<DiceAction> RequiredActions { get; set; } = new Godot.Collections.Array<DiceAction>();

	public ComboAction() { }

	public ComboAction(string name, string description, Godot.Collections.Array<DiceAction> requiredActions) {
		Name = name;
		Description = description;
		RequiredActions = requiredActions;
	}
}