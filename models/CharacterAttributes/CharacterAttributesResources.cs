using Godot;
namespace DiceRoll.Models;

[Tool]
public partial class CharacterAttributesResources : Resource {
	[Export]
	public Godot.Collections.Array<CharacterAttribute> Attributes { get; set; } = new Godot.Collections.Array<CharacterAttribute>();

	public CharacterAttributesResources() { }
}