using Godot;

namespace DiceRoll.Models.Actions.Targets;

[Tool]
[GlobalClass]
public partial class GridConfiguration : Resource {
    [Signal] public delegate void ConfigurationChangedEventHandler();
    private int _rows = 1;
    private int _columns = 1;

    [Export]
    public string Prefix { get; set; } = "G";

    [Export]
    public int Rows {
        get => _rows;
        set {
            _rows = value;
            ResizeCells();
            EmitSignal(nameof(ConfigurationChanged));
        }
    }

    [Export]
    public int Columns {
        get => _columns;
        set {
            _columns = value;
            ResizeCells();
            EmitSignal(nameof(ConfigurationChanged));
        }
    }

    [Export]
    public Godot.Collections.Array<int> Cells { get; set; } = [];

    public GridConfiguration() {
        ResizeCells();
    }

    public GridConfiguration(int rows, int columns) {
        _rows = rows;
        _columns = columns;
        ResizeCells();
    }

    private void ResizeCells() {
        Cells.Resize(_rows * _columns);
        EmitSignal(nameof(ConfigurationChanged));
    }
}