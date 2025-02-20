using Godot;
namespace DiceRolling.Dice;

[Tool]
public partial class DiceManaResources : Resource {
    [Export]
    public Godot.Collections.Array<DiceMana> DiceManas { get; set; } = [];

    public DiceManaResources() { }
}
