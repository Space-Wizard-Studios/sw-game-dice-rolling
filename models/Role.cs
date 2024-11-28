using Godot;
namespace DiceRoll.Models;

[Tool]
public partial class Role : Resource {
	[Export]
	public string Name { get; set; }

	[Export]
	public string Description { get; set; }

	[Export]
	public Health BaseHealth { get; set; }

	[Export]
	public Godot.Collections.Array<CharacterAction> AllowedActions { get; set; } = new Godot.Collections.Array<CharacterAction>();
}