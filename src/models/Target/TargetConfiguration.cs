using Godot;
using DiceRolling.Models.Grids;

namespace DiceRolling.Models.Actions.Targets;

[Tool]
[GlobalClass]
public partial class TargetConfiguration : Resource
{
    [Signal]
    public delegate void ConfigurationChangedEventHandler();

    [Export] public bool IsSingleTarget { get; set; } = false;

    [Export] public Godot.Collections.Array<GridType> Grids { get; set; } = [];

    public TargetConfiguration() { }

    public void AddGrid(int rows, int columns)
    {
        Grids.Add(new GridType(rows, columns, 0, "G"));
        EmitSignal(nameof(ConfigurationChanged));
    }

    public void UpdateGrid(int index)
    {
        if (index >= 0 && index < Grids.Count)
        {
            Grids[index].Cells.Resize(Grids[index].Rows * Grids[index].Columns);
            EmitSignal(nameof(ConfigurationChanged));
        }
    }
}
