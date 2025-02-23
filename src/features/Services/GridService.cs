namespace DiceRolling.Services;

public class GridService {
    private static GridService? _instance;
    public static GridService Instance => _instance ??= new GridService();

    private GridService() { }

    public void ResizeCells(Godot.Collections.Array<int> cells, int rows, int columns) {
        cells.Resize(rows * columns);
    }

    public int GetCellIndex(int row, int column, int columns) {
        return row * columns + column;
    }

    public int GetCell(Godot.Collections.Array<int> cells, int row, int column, int columns) {
        return cells[GetCellIndex(row, column, columns)];
    }

    public void SetCell(Godot.Collections.Array<int> cells, int row, int column, int value, int columns) {
        cells[GetCellIndex(row, column, columns)] = value;
    }
}