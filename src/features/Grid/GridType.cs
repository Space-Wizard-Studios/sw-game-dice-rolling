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
        if (_rows <= 0 || _columns <= 0) {
            GD.PrintErr("Invalid grid size: Rows and Columns must be greater than 0.");
            return;
        }
        GridService.ResizeCells(Cells, _rows, _columns);
        EmitSignal(nameof(GridChanged));
    }

    public int GetCellIndex(int row, int column) {
        return GridService.GetCellIndex(row, column, _columns);
    }

    public int GetCell(int row, int column) {
        return GridService.GetCell(Cells, row, column, _columns);
    }

    public void SetCell(int row, int column, int value) {
        if (row < 0 || row >= _rows || column < 0 || column >= _columns) {
            GD.PrintErr("Invalid cell position.");
            return;
        }
        GridService.SetCell(Cells, row, column, value, _columns);
        EmitSignal(nameof(GridChanged));
    }

    public void ValidateConstructor() {
        if (Rows <= 0) {
            throw new ArgumentException("O número de Rows não pode ser 0 ou menor.", nameof(_rows));
        }
        if (Columns <= 0) {
            throw new ArgumentException("O número de Columns não pode ser 0 ou menor.", nameof(_columns));
        }
        if (Offset < 0) {
            throw new ArgumentException("Offset não pode ser negativo.", nameof(Offset));
        }
        if (!Enum.IsDefined(Direction)) {
            throw new ArgumentException("Grid Direction inválida.", nameof(Direction));
        }
    }
}