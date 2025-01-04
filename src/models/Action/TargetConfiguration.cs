using Godot;

namespace DiceRoll.Models.Actions.Target;

[Tool]
[GlobalClass]
public partial class TargetConfiguration : Resource {
    [Signal]
    public delegate void ConfigurationChangedEventHandler();

    [Export] public bool IsSingleTarget { get; set; } = false;

    [Export] public Godot.Collections.Array<GridConfiguration> Grids { get; set; } = [];

    public TargetConfiguration() { }

    public void AddGrid(int rows, int columns) {
        Grids.Add(new GridConfiguration(rows, columns));
        EmitSignal(nameof(ConfigurationChanged));
    }

    public void UpdateGrid(int index) {
        if (index >= 0 && index < Grids.Count) {
            Grids[index].Cells.Resize(Grids[index].Rows * Grids[index].Columns);
            EmitSignal(nameof(ConfigurationChanged));
        }
    }
}
