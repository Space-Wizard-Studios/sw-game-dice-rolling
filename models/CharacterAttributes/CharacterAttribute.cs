using Godot;

namespace DiceRoll.Models;

[Tool]
[GlobalClass]
public partial class CharacterAttribute : Resource {
	[Export]
	public CharacterAttributeType? Type { get; set; }

	[Export]
	public CharacterAttributeValue? Value { get; set; }

	public CharacterAttribute() : base() {
	}
}