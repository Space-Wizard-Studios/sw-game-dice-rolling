using Godot;
using DiceRoll.Models.Actions.Target;

namespace DiceRoll.Editor;

[Tool]
public partial class TargetConfigurationEditorPlugin : EditorPlugin {
    public override void _EnterTree() {
        AddInspectorPlugin(new TargetConfigurationInspectorPlugin());
    }

    public override void _ExitTree() {
        RemoveInspectorPlugin(new TargetConfigurationInspectorPlugin());
    }
}

public partial class MatrixControl : Control {
    private const int CellSize = 20;
    private const int Padding = 5;
    private static readonly Color[] ColorsArray = [Colors.White, Colors.Yellow, Colors.Green, Colors.Red];

    private Godot.Collections.Array<int> _grid;
    private int _rows;
    private int _columns;

    public TargetConfiguration? TargetConfiguration { get; }

    public MatrixControl() {
        _grid = [];
        _rows = 0;
        _columns = 0;
        UpdateMinimumSize();
    }

    public MatrixControl(TargetConfiguration targetConfiguration) {
        TargetConfiguration = targetConfiguration;
        _grid = targetConfiguration.Grid;
        _rows = targetConfiguration.Rows;
        _columns = targetConfiguration.Columns;
        UpdateMinimumSize();
    }

    public void UpdateDimensions(int rows, int columns) {
        _rows = rows;
        _columns = columns;
        UpdateMinimumSize();
        TargetConfiguration?.UpdateGrid();
    }

    private new void UpdateMinimumSize() {
        CustomMinimumSize = new Vector2(_columns * CellSize + 10, _rows * CellSize + 10); // Adding padding
    }

    public override void _Draw() {
        var totalWidth = _columns * CellSize + Padding * 2;
        var totalHeight = _rows * CellSize + Padding * 2;
        var offsetX = (Size.X - totalWidth) / 2;
        var offsetY = (Size.Y - totalHeight) / 2;

        for (int y = 0; y < _rows; y++) {
            for (int x = 0; x < _columns; x++) {
                var rect = new Rect2(x * CellSize + Padding + offsetX, y * CellSize + Padding + offsetY, CellSize, CellSize);
                int index = y * _columns + x;
                if (index < _grid.Count) {
                    int value = _grid[index];
                    Color bgColor = ColorsArray[Mathf.Clamp(value, 0, ColorsArray.Length - 1)];
                    Color textColor = Colors.Black;

                    DrawRect(rect, bgColor);
                    // Draw border
                    DrawRect(rect, Colors.Black, false);
                    DrawString(GetThemeFont("font"), rect.Position + new Vector2(5, 15), value.ToString(), HorizontalAlignment.Left, -1, 12, textColor);
                }
            }
        }
    }

    public override void _GuiInput(InputEvent @event) {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
            var totalWidth = _columns * CellSize + Padding * 2;
            var totalHeight = _rows * CellSize + Padding * 2;
            var offsetX = (Size.X - totalWidth) / 2;
            var offsetY = (Size.Y - totalHeight) / 2;

            var x = (int)((mouseEvent.Position.X - Padding - offsetX) / CellSize);
            var y = (int)((mouseEvent.Position.Y - Padding - offsetY) / CellSize);
            if (x >= 0 && x < _columns && y >= 0 && y < _rows) {
                int index = y * _columns + x;
                if (index < _grid.Count) {
                    if (mouseEvent.ButtonIndex == MouseButton.Left) {
                        // Cycle forwards
                        _grid[index] = (_grid[index] + 1) % ColorsArray.Length;
                    }
                    else if (mouseEvent.ButtonIndex == MouseButton.Right) {
                        // Cycle backwards
                        _grid[index] = (_grid[index] - 1 + ColorsArray.Length) % ColorsArray.Length;
                    }
                    // Call QueueRedraw to update the MatrixControl instance
                    QueueRedraw();
                }
            }
        }
    }
}