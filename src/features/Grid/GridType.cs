using Godot;
using DiceRolling.Characters;

namespace DiceRolling.Grids;

[Tool]
[GlobalClass]
public partial class GridType : Resource, IGrid {
    [Signal] public delegate void GridChangedEventHandler();
    private int _rows = 1;
    private int _columns = 1;

    [Export] public string Prefix { get; set; } = "G";
    [Export] public int Offset { get; set; } = 0;
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Export(PropertyHint.Enum, "LeftToRight,RightToLeft")] public GridDirection Direction { get; set; } = GridDirection.LeftToRight;

    [Export]
    public int Rows {
        get => _rows;
        set {
            _rows = value;
            ResizeCells();
            EmitSignal(nameof(GridChanged));
        }
    }

    [Export]
    public int Columns {
        get => _columns;
        set {
            _columns = value;
            ResizeCells();
            EmitSignal(nameof(GridChanged));
        }
    }

    [Export]
    public Godot.Collections.Array<int> Cells { get; set; } = new();

    public GridType() {
        ResizeCells();
    }

    public GridType(int rows, int columns, int offset, string prefix) {
        _rows = rows;
        _columns = columns;
        Offset = offset;
        Prefix = prefix;
        ResizeCells();
    }

    private void ResizeCells() {
        Cells.Resize(_rows * _columns);
        EmitSignal(nameof(GridChanged));
    }

    public int GetCellIndex(int row, int column) {
        return row * _columns + column;
    }

    public Vector3 GetCellPosition(int row, int column, float cellPadding) {
        return new Vector3(column + cellPadding / 2.0f, 0, row + cellPadding / 2.0f);
    }

    public int GetCell(int row, int column) {
        return Cells[GetCellIndex(row, column)];
    }

    public void SetCell(int row, int column, int value) {
        Cells[GetCellIndex(row, column)] = value;
        EmitSignal(nameof(GridChanged));
    }
}