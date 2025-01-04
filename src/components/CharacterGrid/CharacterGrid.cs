using Godot;
using Godot.Collections;
using DiceRoll.Models.CharacterGrid;

namespace DiceRoll.Components.Grids;

/// <summary>
/// Represents a 3D grid of characters in the game.
/// </summary>
[Tool]
public partial class CharacterGrid : Node3D {
    [Export] public CharacterGridType[] GridConfigurations = [];
    [Export] public PackedScene? CharacterComponentScene { get; set; }
    private readonly Dictionary<CharacterGridType, Callable> _connections = [];
    private readonly Dictionary<Grid3D, float> _initialPositions = [];

    [ExportToolButton("Generate Grid")]
    private Callable GenerateGridButton => Callable.From(GenerateGrids);

    public override void _Ready() {
        base._Ready();
        GenerateGrids();
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
    private static bool IsValidGridConfiguration(CharacterGridType config) {
        return config is not null && config.Rows > 0 && config.Columns > 0;
    }

    /// <summary>
    /// Creates a new grid based on the configuration.
    /// </summary>
    /// <param name="config">The grid configuration.</param>
    /// <param name="currentXPosition">The current X position for the grid.</param>
    /// <returns>The created grid.</returns>
    private Grid3D CreateGrid(CharacterGridType config, ref float currentXPosition) {
        var grid = new Grid3D {
            Rows = config.Rows,
            Columns = config.Columns,
            Prefix = config.Prefix,
            CharacterStore = config.CharacterStore,
            CharacterComponentScene = CharacterComponentScene
        };

        currentXPosition += config.Offset;
        float centerZPosition = -config.Rows / 2.0f;
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
}