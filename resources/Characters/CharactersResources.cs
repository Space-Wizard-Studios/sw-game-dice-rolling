using Godot;

namespace DiceRoll.Models;

[Tool]
public partial class CharactersResources : Resource {
	[Export]
	public Godot.Collections.Array<Character> Characters { get; set; } = new Godot.Collections.Array<Character>();

	public CharactersResources() { }
}
