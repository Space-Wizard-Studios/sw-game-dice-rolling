using Godot;
namespace DiceRoll.Models;

public partial class DiceSide : DiceMana {
    public DiceSide(
    string name,
    string description,
    Color backgroundColor,
    Color MainColor) : base(name, description, backgroundColor, MainColor) { }
}