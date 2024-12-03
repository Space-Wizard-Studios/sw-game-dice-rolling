using Godot;
namespace DiceRoll.Models;

[Tool]
[GlobalClass]
public partial class CharacterAttributeValue : Resource {
	[Export]
	public int Value { get; set; }

	public CharacterAttributeValue() { }

	public CharacterAttributeValue(int value) {
		Value = value;
	}
}