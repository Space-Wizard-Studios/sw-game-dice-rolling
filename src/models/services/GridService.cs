using System;
using DiceRolling.Grids;

namespace DiceRolling.Services;

public class GridService {
    private static GridService? _instance;
    public static GridService Instance => _instance ??= new GridService();

    private GridService() { }

    public static void ResizeCells(Godot.Collections.Array<int> cells, int rows, int columns) {
        cells.Resize(rows * columns);
    }

    public static int GetCellIndex(int row, int column, int columns) {
        return row * columns + column;
    }

    public static int GetCell(Godot.Collections.Array<int> cells, int row, int column, int columns) {
        ArgumentNullException.ThrowIfNull(cells);
        return cells[GetCellIndex(row, column, columns)];
    }

    public static void SetCell(Godot.Collections.Array<int> cells, int row, int column, int value, int columns) {
        ArgumentNullException.ThrowIfNull(cells);
        cells[GetCellIndex(row, column, columns)] = value;
    }

    public static GridCellType CreateCellType(int value, int row, int column, int columns, string prefix = "") {
        int index = GetCellIndex(row, column, columns);
        return new GridCellType {
            Value = value,
            Row = row,
            Column = column,
            Index = index,
            Label = string.IsNullOrEmpty(prefix) ? $"({row},{column})" : $"{prefix}{index}"
        };
    }

    public static GridCellType? GetCellType(Godot.Collections.Array<int> cells, int row, int column, int columns, string prefix = "") {
        if (cells == null) return null;
        int value = GetCell(cells, row, column, columns);
        return CreateCellType(value, row, column, columns, prefix);
    }
}