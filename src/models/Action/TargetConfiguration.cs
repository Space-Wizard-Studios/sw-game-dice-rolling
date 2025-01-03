using Godot;

namespace DiceRoll.Models.Actions.Target;

[Tool]
[GlobalClass]
public partial class TargetConfiguration : Resource {
    [Signal]
    public delegate void ConfigurationChangedEventHandler();
    private int rows = 3;
    private int columns = 2;

    [Export]
    public int Rows {
        get => rows;
        set {
            rows = value;
            UpdateGrid();
            EmitSignal(nameof(ConfigurationChanged));
        }
    }

    [Export]
    public int Columns {
        get => columns;
        set {
            columns = value;
            UpdateGrid();
            EmitSignal(nameof(ConfigurationChanged));
        }
    }

    [Export] public Godot.Collections.Array<int> Grid { get; set; } = [.. new int[6]];

    public TargetConfiguration() { }

    public void UpdateGrid() {
        Grid.Resize(rows * columns);
    }
}