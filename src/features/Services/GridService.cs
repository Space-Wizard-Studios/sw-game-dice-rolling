using System;

namespace DiceRolling.Services;

public class GridService {
    private static GridService? _instance;
    public static GridService Instance => _instance ??= new GridService();

    private GridService() { }

    public void ResizeCells(Godot.Collections.Array<int> cells, int rows, int columns) {
        if (cells == null)
            throw new ArgumentNullException(nameof(cells));
        if (rows <= 0)
            throw new ArgumentException("O número de Rows não pode ser 0 ou menor.", nameof(rows));
        if (columns <= 0)
            throw new ArgumentException("O número de Columns não pode ser 0 ou menor.", nameof(columns));
        cells.Resize(rows * columns);
    }

    public int GetCellIndex(int row, int column, int columns) {
        if (row <= 0)
            throw new ArgumentException("O número de Rows não pode ser 0 ou menor.", nameof(row));
        if (column <= 0)
            throw new ArgumentException("O número de Columns não pode ser 0 ou menor.", nameof(column));
        return row * columns + column;
    }

    public int GetCell(Godot.Collections.Array<int> cells, int row, int column, int columns) {
        if (cells == null)
            throw new ArgumentNullException(nameof(cells));
        return cells[GetCellIndex(row, column, columns)];
    }

    public void SetCell(Godot.Collections.Array<int> cells, int row, int column, int value, int columns) {
        if (cells == null)
            throw new ArgumentNullException(nameof(cells));
        cells[GetCellIndex(row, column, columns)] = value;
    }
}