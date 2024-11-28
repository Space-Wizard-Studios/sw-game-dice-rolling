using Godot;
namespace DiceRoll.Models;

public partial class DiceSide : DiceMana {
	public DiceSide(
	ManaType manaType,
	string name,
	string description,
	Color backgroundColor,
	Color MainColor) : base(manaType, name, description, backgroundColor, MainColor) { }
}