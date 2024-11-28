using Godot;

namespace DiceRoll.Models;
[Tool]
public partial class AttributesResources : Resource {
	[Export]
	public Godot.Collections.Array<Attribute> Attributes { get; set; } = new Godot.Collections.Array<Attribute>();

	public AttributesResources() { }
}