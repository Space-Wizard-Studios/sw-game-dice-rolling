using Godot;

namespace DiceRoll.Models;

[Tool]
public partial class CharacterActionsResources : Resource {
	[Export]
	public Godot.Collections.Array<CharacterAction> CharacterActions { get; set; } = new Godot.Collections.Array<CharacterAction>();

	public CharacterActionsResources() { }
}
