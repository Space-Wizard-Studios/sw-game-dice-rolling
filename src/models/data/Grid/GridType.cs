using Godot;
using System;

using DiceRolling.Id;
using DiceRolling.Stores;
using DiceRolling.Services;

namespace DiceRolling.Grids;

[Tool]
[GlobalClass]
public partial class GridType : IdentifiableResource, IGrid {
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
    public Godot.Collections.Array<GridCellType?>? Cells { get; set; } = [];

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

        Cells ??= [];

        // Adjust size if needed
        int requiredSize = _rows * _columns;
        int currentSize = Cells.Count;

        if (requiredSize > currentSize) {
            // Add new cells
            for (int i = currentSize; i < requiredSize; i++) {
                int row = i / _columns;
                int col = i % _columns;
                Cells.Add(GridService.CreateCellType(0, row, col, _columns, Prefix));
            }
        }
        else if (requiredSize < currentSize) {
            // Remove excess cells
            Cells.Resize(requiredSize);
        }

        // Update existing cells' positions
        for (int i = 0; i < requiredSize; i++) {
            var cell = Cells[i];
            if (cell != null) {
                int row = i / _columns;
                int col = i % _columns;
                cell.Row = row;
                cell.Column = col;
                cell.Index = i;
                cell.Label = $"{Prefix}{i}";
            }
        }

        EmitSignal(nameof(GridChanged));
    }

    public int GetCellIndex(int row, int column) {
        return GridService.GetCellIndex(row, column, _columns);
    }

    public GridCellType? GetCell(int row, int column) {
        int index = GetCellIndex(row, column);
        return (index >= 0 && index < Cells?.Count) ? Cells[index] : null;
    }

    public void SetCell(int row, int column, int value) {
        if (row < 0 || row >= _rows || column < 0 || column >= _columns || Cells == null) {
            GD.PrintErr("Invalid cell position or cells collection is null.");
            return;
        }

        int index = GetCellIndex(row, column);
        if (index >= 0 && index < Cells.Count) {
            var cell = Cells[index];
            if (cell != null) {
                cell.Value = value;
                cell.NotifyChanged();
                EmitSignal(nameof(GridChanged));
            }
        }
    }

    public void SetCellValue(int row, int column, int value) {
        SetCell(row, column, value);
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