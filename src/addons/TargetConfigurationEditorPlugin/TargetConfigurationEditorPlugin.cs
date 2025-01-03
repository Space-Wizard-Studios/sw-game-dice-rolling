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

/// <summary>
/// Manages a grid configuration for a target.
/// </summary>
public partial class MatrixControl : Control {
    private bool isFlippedHorizontally = false;
    private const int CellSize = 40; // Increased to fit the new text format
    private const int Padding = 5;
    private static readonly Color[] ColorsArray = [Colors.White, Colors.Yellow, Colors.Green, Colors.Red];
    private Godot.Collections.Array<int> _grid;
    private int _rows;
    private int _columns;
    public TargetConfiguration? TargetConfiguration { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixControl"/> class with an empty grid.
    /// </summary>
    public MatrixControl() {
        _grid = [];
        _rows = 0;
        _columns = 0;
        UpdateMinimumSize();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixControl"/> class with a given target configuration.
    /// </summary>
    /// <param name="targetConfiguration">The target configuration to initialize the grid with.</param>
    public MatrixControl(TargetConfiguration targetConfiguration) {
        TargetConfiguration = targetConfiguration;
        _grid = targetConfiguration.Grid;
        _rows = targetConfiguration.Rows;
        _columns = targetConfiguration.Columns;
        UpdateMinimumSize();
    }

    /// <summary>
    /// Updates the grid dimensions and recalculates the minimum size.
    /// </summary>
    /// <param name="rows">The number of rows in the grid.</param>
    /// <param name="columns">The number of columns in the grid.</param>
    public void UpdateDimensions(int rows, int columns) {
        _rows = rows;
        _columns = columns;
        UpdateMinimumSize();
        TargetConfiguration?.UpdateGrid();
    }

    /// <summary>
    /// Recalculates the minimum size of the grid based on its dimensions.
    /// </summary>
    private new void UpdateMinimumSize() {
        CustomMinimumSize = new Vector2(_columns * CellSize + 10, _rows * CellSize + 10); // Adding padding
    }

    /// <summary>
    /// Flips the grid horizontally and triggers a redraw.
    /// </summary>
    /// <param name="flip">If set to <c>true</c>, the grid will be flipped horizontally.</param>
    public void FlipHorizontally(bool flip) {
        isFlippedHorizontally = flip;
        QueueRedraw();
    }

    /// <summary>
    /// Draws the grid and its contents.
    /// <inheritdoc cref="Godot.CanvasItem._Draw"/>
    /// </summary>
    public override void _Draw() {
        // Calculate the total width and height of the grid including padding
        var totalWidth = _columns * CellSize + Padding * 2;
        var totalHeight = _rows * CellSize + Padding * 2;

        // Calculate the offset to center the grid within the control's size
        var offsetX = (Size.X - totalWidth) / 2;
        var offsetY = (Size.Y - totalHeight) / 2;

        // Iterate through each cell in the grid
        for (int y = 0; y < _rows; y++) {
            for (int x = 0; x < _columns; x++) {
                // Determine the x-coordinate for drawing, considering horizontal flip
                int drawX = isFlippedHorizontally ? _columns - 1 - x : x;

                // Calculate the rectangle for the current cell
                var rect = new Rect2(drawX * CellSize + Padding + offsetX, y * CellSize + Padding + offsetY, CellSize, CellSize);

                // Calculate the index in the grid array
                int index = y * _columns + x;

                // Check if the index is within the grid array bounds
                if (index < _grid.Count) {
                    int value = _grid[index];

                    // Determine the background color based on the grid value
                    Color bgColor = ColorsArray[Mathf.Clamp(value, 0, ColorsArray.Length - 1)];
                    Color textColor = Colors.Black;

                    // Draw the cell background and border
                    DrawRect(rect, bgColor);
                    DrawRect(rect, Colors.Black, false);

                    // Draw the text inside the cell
                    string text = $"{index:D2} [{value}]";
                    DrawString(GetThemeFont("font"), rect.Position + new Vector2(5, 15), text, HorizontalAlignment.Left, -1, 12, textColor);
                }
            }
        }
    }

    /// <summary>
    /// Handles mouse input to update the grid values.
    /// </summary>
    /// <param name="event">The input event.</param>
    public override void _GuiInput(InputEvent @event) {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
            // Calculate the total width and height of the grid including padding
            var totalWidth = _columns * CellSize + Padding * 2;
            var totalHeight = _rows * CellSize + Padding * 2;

            // Calculate the offset to center the grid within the control's size
            var offsetX = (Size.X - totalWidth) / 2;
            var offsetY = (Size.Y - totalHeight) / 2;

            // Determine the grid cell coordinates based on the mouse position
            var x = (int)((mouseEvent.Position.X - Padding - offsetX) / CellSize);
            var y = (int)((mouseEvent.Position.Y - Padding - offsetY) / CellSize);

            // Adjust the x-coordinate if the grid is flipped horizontally
            if (isFlippedHorizontally) {
                x = _columns - 1 - x;
            }

            // Check if the calculated cell coordinates are within the grid bounds
            if (x >= 0 && x < _columns && y >= 0 && y < _rows) {
                int index = y * _columns + x;

                // Check if the index is within the grid array bounds
                if (index < _grid.Count) {
                    // Update the grid value based on the mouse button pressed
                    if (mouseEvent.ButtonIndex == MouseButton.Left) {
                        // Cycle forwards through the color array
                        _grid[index] = (_grid[index] + 1) % ColorsArray.Length;
                    }
                    else if (mouseEvent.ButtonIndex == MouseButton.Right) {
                        // Cycle backwards through the color array
                        _grid[index] = (_grid[index] - 1 + ColorsArray.Length) % ColorsArray.Length;
                    }

                    // Call QueueRedraw to update the MatrixControl instance
                    QueueRedraw();
                }
            }
        }
    }
}