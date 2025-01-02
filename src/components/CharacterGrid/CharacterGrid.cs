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

    // TODO: testar
    [ExportToolButton("Generate Grid")]
    private Callable GenerateGridButton => Callable.From(GenerateGrids);

    public override void _Ready() {
        base._Ready();
        GenerateGrids();
    }

    public override void _ExitTree() {
        base._ExitTree();
        foreach (var config in GridConfigurations) {
            if (_connections.TryGetValue(config, out var callable)) {
                config.Disconnect("changed", callable);
            }
        }
        _connections.Clear();
    }

    private void GenerateGrids() {
        if (GridConfigurations is null || GridConfigurations.Length == 0) {
            return;
        }

        // Clear existing grids
        foreach (var child in GetChildren()) {
            if (child is Grid3D grid) {
                RemoveChild(grid);
                grid.QueueFree();
            }
        }

        float currentXPosition = 0;

        foreach (var config in GridConfigurations) {
            if (config is null || config.Columns <= 0 || config.Rows <= 0) {
                continue;
            }

            Grid3D grid = new Grid3D {
                Columns = config.Columns,
                Rows = config.Rows,
                Prefix = config.Prefix,
                CharacterStore = config.CharacterStore,
                CharacterComponentScene = CharacterComponentScene
            };

            currentXPosition += config.Offset;

            float centerZPosition = -config.Rows / 2.0f;
            grid.Transform = new Transform3D(Basis.Identity, new Vector3(currentXPosition, 0, centerZPosition));
            AddChild(grid);
            grid.GenerateGridCells();
            _initialPositions[grid] = currentXPosition;

            currentXPosition += config.Columns;
        }
    }
}