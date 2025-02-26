using Godot;
using System.Collections.Generic;

using DiceRolling.Events;
using DiceRolling.Grids;
using DiceRolling.Targets;

namespace DiceRolling.Components.Grids;

/// <summary>
/// Represents a 3D grid of characters in the game.
/// </summary>
[Tool]
public partial class CharacterGrid : Node3D {
    [Export] public GridType[] GridConfigurations = [];
    [Export] public PackedScene? CharacterComponentScene { get; set; }
    [Export] public PackedScene? ArrowMesh { get; set; }

    private readonly Dictionary<GridType, Callable> _connections = [];
    private readonly Dictionary<Grid3D, float> _initialPositions = [];
    [Export] public float CellPadding { get; set; } = 0.1f;

    [ExportToolButton("Generate Grid")]
    private Callable GenerateGridButton => Callable.From(GenerateGrids);

    public override void _Ready() {
        base._Ready();
        GenerateGrids();
        EventBus.Instance.Connect(nameof(EventBus.ActionSelected), new Callable(this, nameof(OnActionSelected)));
    }

    public override void _ExitTree() {
        base._ExitTree();
        DisconnectGridConfigurations();
    }

    /// <summary>
    /// Generates the grids based on the configurations.
    /// </summary>
    private void GenerateGrids() {
        if (GridConfigurations is null || GridConfigurations.Length == 0) {
            GD.PrintErr("GridConfigurations is null or empty");
            return;
        }

        ClearExistingGrids();
        CreateNewGrids();
    }

    /// <summary>
    /// Clears existing grids from the scene.
    /// </summary>
    private void ClearExistingGrids() {
        foreach (var child in GetChildren()) {
            if (child is Grid3D grid) {
                CallDeferred("remove_child", grid);
                grid.QueueFree();
            }
        }
    }

    /// <summary>
    /// Creates new grids based on the configurations.
    /// </summary>
    private void CreateNewGrids() {
        float currentXPosition = 0;

        foreach (var config in GridConfigurations) {
            if (IsValidGridConfiguration(config)) {
                var grid = CreateGrid(config, ref currentXPosition);
                CallDeferred("add_child", grid);
                _initialPositions[grid] = currentXPosition;
            }
            else {
                GD.PrintErr($"Invalid grid configuration: {config}");
            }
        }
    }

    /// <summary>
    /// Validates the grid configuration.
    /// </summary>
    /// <param name="config">The grid configuration to validate.</param>
    /// <returns>True if the configuration is valid, otherwise false.</returns>
    private static bool IsValidGridConfiguration(GridType config) {
        return config is not null && config.Rows > 0 && config.Columns > 0;
    }

    /// <summary>
    /// Creates a new grid based on the configuration.
    /// </summary>
    /// <param name="config">The grid configuration.</param>
    /// <param name="currentXPosition">The current X position for the grid.</param>
    /// <returns>The created grid.</returns>
    private Grid3D CreateGrid(GridType config, ref float currentXPosition) {
        var grid = new Grid3D {
            Rows = config.Rows,
            Columns = config.Columns,
            Prefix = config.Prefix,
            CharacterStore = config.CharacterStore,
            CharacterComponentScene = CharacterComponentScene,
            CellPadding = CellPadding
        };


        float centerZPosition = -config.Rows / 2.0f;

        // Add arrow to indicate direction
        if (ArrowMesh != null) {
            var arrowMeshInstance = ArrowMesh.Instantiate<Node3D>();
            arrowMeshInstance.Transform = new Transform3D(Basis.Identity, new Vector3(currentXPosition, 2, centerZPosition));

            // Rotate arrow based on direction
            if (config.Direction == GridDirection.RightToLeft) {
                arrowMeshInstance.RotateY(Mathf.Pi);
            }

            grid.AddChild(arrowMeshInstance);
        }

        currentXPosition += config.Offset;
        grid.Transform = new Transform3D(Basis.Identity, new Vector3(currentXPosition, 0, centerZPosition));
        grid.GenerateGridCells();
        currentXPosition += config.Columns;
        return grid;
    }

    /// <summary>
    /// Disconnects the grid configurations.
    /// </summary>
    private void DisconnectGridConfigurations() {
        foreach (var config in GridConfigurations) {
            if (_connections.TryGetValue(config, out var callable)) {
                config.Disconnect("changed", callable);
            }
        }
        _connections.Clear();
    }

    private void OnActionSelected(TargetBoardType TargetBoard) {
        UpdateCellColors(TargetBoard);
    }

    private static Color GetCellColor(int value) {
        return value switch {
            0 => new Color(Colors.White), // Ignored (white)
            1 => new Color(Colors.Yellow), // Placement (yellow)
            2 => new Color(Colors.Green), // Ally (green)
            3 => new Color(Colors.Red), // Enemy (red)
            _ => new Color(Colors.DimGray) // Default (gray)
        };
    }

    // ...existing code...

    private void UpdateCellColors(TargetBoardType TargetBoard) {
        if (TargetBoard.Grids.Count < 2) {
            GD.PrintErr("Expected at least two grids in the target configuration.");
            return;
        }

        var gridConfig1 = TargetBoard.Grids[0];
        var gridConfig2 = TargetBoard.Grids[1];

        var grid3DInstances = new List<Grid3D>();
        foreach (Node child in GetChildren()) {
            if (child is Grid3D grid3D) {
                grid3DInstances.Add(grid3D);
            }
        }

        if (grid3DInstances.Count < 2) {
            GD.PrintErr("Expected at least two Grid3D instances in the scene.");
            return;
        }

        var grid3D1 = grid3DInstances[0];
        var grid3D2 = grid3DInstances[1];

        // GD.Print("Target Configuration for Grid 1:");
        // for (int i = 0; i < gridConfig1.Cells.Count; i++) {
        //     GD.Print($"Cell {i}: Value = {gridConfig1.Cells[i]}");
        // }

        // GD.Print("Applying colors to Grid 1:");
        for (int i = 0; i < gridConfig1.Cells.Count; i++) {
            int value1 = gridConfig1.Cells[i];
            Color cellColor1 = GetCellColor(value1);
            // GD.Print($"Grid 1 Cell {i}: Value = {value1}, Color = {cellColor1}");
            grid3D1.UpdateCellColor(i, cellColor1);
        }

        // GD.Print("Target Configuration for Grid 2:");
        // for (int j = 0; j < gridConfig2.Cells.Count; j++) {
        //     GD.Print($"Cell {j}: Value = {gridConfig2.Cells[j]}");
        // }

        // GD.Print("Applying colors to Grid 2:");
        for (int j = 0; j < gridConfig2.Cells.Count; j++) {
            int value2 = gridConfig2.Cells[j];
            Color cellColor2 = GetCellColor(value2);
            // GD.Print($"Grid 2 Cell {j}: Value = {value2}, Color = {cellColor2}");
            grid3D2.UpdateCellColor(j, cellColor2);
        }
    }
}