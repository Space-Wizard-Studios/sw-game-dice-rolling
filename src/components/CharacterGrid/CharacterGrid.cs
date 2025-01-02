using Godot;
using Godot.Collections;
using DiceRoll.Models.CharacterGrid;

namespace DiceRoll.Components.Grids;

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

    private void GenerateGrids() {
        if (GridConfigurations is null || GridConfigurations.Length == 0) {
            GD.PrintErr("GridConfigurations is null or empty");
            return;
        }

        ClearExistingGrids();
        CreateNewGrids();
    }

    private void ClearExistingGrids() {
        foreach (var child in GetChildren()) {
            if (child is Grid3D grid) {
                CallDeferred("remove_child", grid);
                grid.QueueFree();
            }
        }
    }

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

    private static bool IsValidGridConfiguration(CharacterGridType config) {
        return config is not null && config.Columns > 0 && config.Rows > 0;
    }

    private Grid3D CreateGrid(CharacterGridType config, ref float currentXPosition) {
        var grid = new Grid3D {
            Columns = config.Columns,
            Rows = config.Rows,
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

    private void DisconnectGridConfigurations() {
        foreach (var config in GridConfigurations) {
            if (_connections.TryGetValue(config, out var callable)) {
                config.Disconnect("changed", callable);
            }
        }
        _connections.Clear();
    }
}