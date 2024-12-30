using Godot;
using System.Collections.Generic;
using DiceRoll.Models.CharacterGrid;

namespace DiceRoll.Components;

[Tool]
public partial class CharacterGrid : Node3D {
    [Export] public CharacterGridType[] GridConfigurations { get; set; } = [];

    private readonly Dictionary<CharacterGridType, Callable> _connections = [];
    private readonly Dictionary<Grid3D, float> _initialPositions = [];

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
        // Clear existing grids
        foreach (var child in GetChildren()) {
            if (child is Grid3D grid) {
                RemoveChild(grid);
                grid.QueueFree();
            }
        }

        float currentXPosition = 0;

        foreach (var config in GridConfigurations) {
            Grid3D grid = new Grid3D {
                Columns = config.Columns,
                Rows = config.Rows,
                Prefix = config.Prefix
            };

            currentXPosition += config.Offset;

            float centerZPosition = -config.Rows / 2.0f;
            grid.Transform = new Transform3D(Basis.Identity, new Vector3(currentXPosition, 0, centerZPosition));
            AddChild(grid);
            grid.GenerateGridCells();

            _initialPositions[grid] = currentXPosition;

            currentXPosition += config.Columns;

            // Connect a signal or method to update the grid when the configuration changes
            if (!_connections.ContainsKey(config)) {
                var callable = Callable.From(() => OnGridConfigurationChanged());
                config.Connect("changed", callable);
                _connections[config] = callable;
            }
        }
    }

    private void OnGridConfigurationChanged() {
        GD.PrintT("Grid configuration changed");
        GenerateGrids();
    }
}