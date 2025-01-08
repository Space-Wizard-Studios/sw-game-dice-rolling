using Godot;
using DiceRoll.Models.Actions.Targets;
using System.Collections.Generic;
using System.Linq;

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
    private const int CellSize = 40;
    private const int Padding = 10;
    private static readonly Color[] ColorsArray = [Colors.White, Colors.Yellow, Colors.Green, Colors.Red];
    private readonly List<GridConfiguration> _grids = [];
    public TargetConfiguration? TargetConfiguration { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixControl"/> class with an empty grid.
    /// </summary>
    public MatrixControl() {
        SizeFlagsHorizontal = SizeFlags.ExpandFill;
        SizeFlagsVertical = SizeFlags.ExpandFill;
        CustomMinimumSize = new Vector2(0, 0);
        UpdateMinimumSize();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixControl"/> class with a given target configuration.
    /// </summary>
    /// <param name="targetConfiguration">The target configuration to initialize the grid with.</param>
    public MatrixControl(TargetConfiguration targetConfiguration) : this() {
        TargetConfiguration = targetConfiguration;
        foreach (var grid in targetConfiguration.Grids) {
            AddGrid(grid);
        }
        UpdateMinimumSize();
    }

    /// <summary>
    /// Adds a new grid to the MatrixControl.
    /// </summary>
    /// <param name="grid">The grid configuration.</param>
    public void AddGrid(GridConfiguration grid) {
        // GD.Print($"Adding grid: Rows={grid.Rows}, Columns={grid.Columns}, Prefix={grid.Prefix}");
        _grids.Add(grid);
        if (!grid.IsConnected(nameof(GridConfiguration.ConfigurationChanged), new Callable(this, nameof(OnGridConfigurationChanged)))) {
            grid.Connect(nameof(GridConfiguration.ConfigurationChanged), new Callable(this, nameof(OnGridConfigurationChanged)));
        }
        UpdateMinimumSize();
    }

    /// <summary>
    /// Clears all grids from the MatrixControl.
    /// </summary>
    public void ClearGrids() {
        // GD.Print("Clearing all grids");
        foreach (var grid in _grids) {
            grid.Disconnect(nameof(GridConfiguration.ConfigurationChanged), new Callable(this, nameof(OnGridConfigurationChanged)));
        }
        _grids.Clear();
        UpdateMinimumSize();
        QueueRedraw();
    }

    public void ClearGridInputs() {
        foreach (var grid in _grids) {
            for (int i = 0; i < grid.Cells.Count; i++) {
                grid.Cells[i] = 0;
            }
        }
        QueueRedraw();
    }

    /// <summary>
    /// Updates the grid dimensions and recalculates the minimum size of the grid container.
    /// </summary>
    private new void UpdateMinimumSize() {
        int maxColumns = _grids.Count > 0 ? _grids.Max(g => g?.Columns ?? 0) : 0;
        int maxRows = _grids.Count > 0 ? _grids.Max(g => g?.Rows ?? 0) : 0;
        // GD.Print($"maxColumns: {maxColumns}, maxRows: {maxRows}");
        CustomMinimumSize = new Vector2(maxColumns * CellSize + Padding * 2, maxRows * CellSize + Padding * 2);
    }

    /// <summary>
    /// Flips the grid horizontally and triggers a redraw.
    /// </summary>
    /// <param name="flip">If set to <c>true</c>, the grid will be flipped horizontally.</param>
    public void FlipHorizontally(bool flip) {
        isFlippedHorizontally = flip;
        _grids.Reverse();
        QueueRedraw();
    }

    /// <summary>
    /// Draws the grid and its contents.
    /// <inheritdoc cref="Godot.CanvasItem._Draw"/>
    /// </summary>
    public override void _Draw() {
        float offsetX = 0;
        foreach (var grid in _grids) {
            if (grid != null) {
                // GD.Print($"Drawing grid: Rows={grid.Rows}, Columns={grid.Columns}, Prefix={grid.Prefix}");
                DrawGrid(grid, offsetX);
                offsetX += grid.Columns * CellSize + Padding;
            }
        }
    }
    private void DrawGrid(GridConfiguration grid, float offsetX) {
        // Set the initial vertical offset
        var offsetY = Padding;

        for (int y = 0; y < grid.Rows; y++) {
            for (int x = 0; x < grid.Columns; x++) {
                // Calculate the x position, considering horizontal flip if necessary
                int drawX = isFlippedHorizontally ? grid.Columns - 1 - x : x;
                // Define the rectangle area for the current cell
                var rect = new Rect2(drawX * CellSize + Padding + offsetX, y * CellSize + Padding + offsetY, CellSize, CellSize);
                // Calculate the index of the current cell
                int index = y * grid.Columns + x;

                // Check if the index is within the bounds of the cell list
                if (index < grid.Cells.Count) {
                    // Get the value of the current cell
                    int value = grid.Cells[index];
                    Color bgColor = ColorsArray[Mathf.Clamp(value, 0, ColorsArray.Length - 1)];
                    Color textColor = Colors.Black;
                    DrawRect(rect, bgColor);
                    DrawRect(rect, Colors.Black, false);
                    string text = $"{grid.Prefix}{index} [{value}]";
                    DrawString(GetThemeFont("font"), rect.Position + new Vector2(5, 15), text, HorizontalAlignment.Left, -1, 12, textColor);
                }
            }
        }
    }

    /// <summary>
    /// Handles mouse input to update the grid values.
    /// </summary>
    /// <param name="event">The input event.</param>
    /// <inheritdoc cref="Godot.Control._GuiInput"/>
    public override void _GuiInput(InputEvent @event) {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
            float offsetX = 0;
            foreach (var grid in _grids) {
                if (HandleMouseInput(mouseEvent, grid, offsetX)) {
                    break;
                }
                offsetX += grid.Columns * CellSize + Padding;
            }
        }
    }

    private bool HandleMouseInput(InputEventMouseButton mouseEvent, GridConfiguration grid, float offsetX) {
        var offsetY = Padding;

        var x = (int)((mouseEvent.Position.X - Padding - offsetX) / CellSize);
        var y = (int)((mouseEvent.Position.Y - Padding - offsetY) / CellSize);

        if (isFlippedHorizontally) {
            x = grid.Columns - 1 - x;
        }

        if (x >= 0 && x < grid.Columns && y >= 0 && y < grid.Rows) {
            int index = y * grid.Columns + x;

            if (index < grid.Cells.Count) {
                if (mouseEvent.ButtonIndex == MouseButton.Left) {
                    grid.Cells[index] = (grid.Cells[index] + 1) % ColorsArray.Length;
                }
                else if (mouseEvent.ButtonIndex == MouseButton.Right) {
                    grid.Cells[index] = (grid.Cells[index] - 1 + ColorsArray.Length) % ColorsArray.Length;
                }
                QueueRedraw();
                return true;
            }
        }
        return false;
    }

    private void OnGridConfigurationChanged() {
        UpdateMinimumSize();
        QueueRedraw();
    }
}