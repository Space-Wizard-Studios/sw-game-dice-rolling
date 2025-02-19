using Godot;
namespace DiceRolling.Models;

[Tool]
public partial class DiceManaResources : Resource
{
    [Export]
    public Godot.Collections.Array<DiceMana> DiceManas { get; set; } = [];

    public DiceManaResources() { }
}
