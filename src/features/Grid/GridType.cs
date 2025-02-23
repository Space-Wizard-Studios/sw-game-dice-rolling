using Godot;
using DiceRolling.Services;
using System;
using DiceRolling.Characters;

namespace DiceRolling.Grids;

[Tool]
[GlobalClass]
public partial class GridType : Resource, IGrid {
    [Signal] public delegate void GridChangedEventHandler();
    private int _rows = 1;
    private int _columns = 1;

    [Export]
    public string Prefix { get; set; } = "G";

    [Export]
    public int Offset { get; set; } = 0;

    [Export]
    public CharacterStore? CharacterStore { get; set; }

    [Export(PropertyHint.Enum, "LeftToRight,RightToLeft")]
    public GridDirection Direction { get; set; } = GridDirection.LeftToRight;

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
        Rows = rows;
        Columns = columns;
        Offset = offset;
        Prefix = prefix;
        ValidateConstructor();
        ResizeCells();
    }

    private void ResizeCells() {
        GridService.Instance.ResizeCells(Cells, _rows, _columns);
        EmitSignal(nameof(GridChanged));
    }

    public int GetCellIndex(int row, int column) {
        return GridService.Instance.GetCellIndex(row, column, _columns);
    }

    public int GetCell(int row, int column) {
        return GridService.Instance.GetCell(Cells, row, column, _columns);
    }

    public void SetCell(int row, int column, int value) {
        GridService.Instance.SetCell(Cells, row, column, value, _columns);
        EmitSignal(nameof(GridChanged));
    }

    public void ValidateConstructor() {
        if (_rows <= 0) {
            throw new ArgumentException("Rows must be greater than 0", nameof(_rows));
        }
        if (_columns <= 0) {
            throw new ArgumentException("Columns must be greater than 0", nameof(_columns));
        }
        if (string.IsNullOrWhiteSpace(Prefix)) {
            throw new ArgumentException("Prefix cannot be null or whitespace", nameof(Prefix));
        }
        if (Offset < 0) {
            throw new ArgumentException("Offset cannot be negative", nameof(Offset));
        }
        if (!Enum.IsDefined(typeof(GridDirection), Direction)) {
            throw new ArgumentException("Invalid grid direction", nameof(Direction));
        }
    }
}