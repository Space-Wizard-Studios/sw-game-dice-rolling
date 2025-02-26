using System;
using Godot;

namespace DiceRolling.Services;

public class GridService {
    private static GridService? _instance;
    public static GridService Instance => _instance ??= new GridService();

    private GridService() { }

    public static void ResizeCells(Godot.Collections.Array<int> cells, int rows, int columns) {
        ArgumentNullException.ThrowIfNull(cells);
        if (rows <= 0)
            throw new ArgumentException("O número de Rows não pode ser 0 ou menor.", nameof(rows));
        if (columns <= 0)
            throw new ArgumentException("O número de Columns não pode ser 0 ou menor.", nameof(columns));
        cells.Resize(rows * columns);
    }

    public static int GetCellIndex(int row, int column, int columns) {
        if (row < 0) {
            throw new ArgumentException("O número de Rows não pode ser 0 ou menor.", nameof(row));
        }
        if (column < 0) {
            throw new ArgumentException("O número de Columns não pode ser 0 ou menor.", nameof(column));
        }
        return row * columns + column;
    }

    public static int GetCell(Godot.Collections.Array<int> cells, int row, int column, int columns) {
        GD.Print($"Getting cell at Row: {row}, Column: {column}");
        ArgumentNullException.ThrowIfNull(cells);
        return cells[GetCellIndex(row, column, columns)];
    }

    public static void SetCell(Godot.Collections.Array<int> cells, int row, int column, int value, int columns) {
        ArgumentNullException.ThrowIfNull(cells);
        cells[GetCellIndex(row, column, columns)] = value;
    }
}