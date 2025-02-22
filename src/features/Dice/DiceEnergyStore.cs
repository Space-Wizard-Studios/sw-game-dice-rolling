using Godot;
namespace DiceRolling.Dice;

[Tool]
public partial class DiceEnergyStore : Resource {
    [Export]
    public Godot.Collections.Array<DiceEnergy> Energy { get; set; } = [];

    public DiceEnergyStore() { }
}