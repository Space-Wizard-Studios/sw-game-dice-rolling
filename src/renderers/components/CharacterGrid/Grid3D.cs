using Godot;
using System;
using System.Collections.Generic;

using DiceRolling.Grids;
using DiceRolling.Characters;

using DiceRolling.Components.Characters;

namespace DiceRolling.Components.Grids;

[Tool]
public partial class Grid3D : Node3D {
    [Export] public GridType? GridInstance { get; set; }
    [Export] public int Rows { get; set; } = 1;
    [Export] public int Columns { get; set; } = 1;
    [Export] public string Prefix { get; set; } = "G";
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Export] public PackedScene? CharacterComponentScene { get; set; }
    [Export] public float CellPadding { get; set; }
    private GridCell3D[,]? gridCells;
    private readonly List<MeshInstance3D> cellMeshes = [];

    public override void _Ready() {
        base._Ready();
        GenerateGridCells();
        RenderBattleSquadCharacters();
    }

    public void GenerateGridCells() {
        ClearExistingCells();
        CreateNewCells();
        CreateCellRenderMeshes();
    }

    private void ClearExistingCells() {
        if (gridCells != null) {
            foreach (var cell in gridCells) {
                if (cell != null) {
                    RemoveChild(cell);
                    cell.QueueFree();
                }
            }
        }

        gridCells = new GridCell3D[Rows, Columns];

        foreach (var mesh in cellMeshes) {
            RemoveChild(mesh);
            mesh.QueueFree();
        }

        cellMeshes.Clear();
    }

    private void CreateNewCells() {
        gridCells = new GridCell3D[Rows, Columns];
        // GD.Print($"Creating new cells for grid with {Rows} rows and {Columns} columns.");
        ForEachCell((y, x) => {
            var position = new Vector3(x, 0, y);
            var labelText = $"{Prefix}{GridInstance?.GetCellIndex(y, x)}({x},{y})";
            var gridCell = new GridCell3D(position, labelText);
            AddChild(gridCell);
            gridCells[y, x] = gridCell;
            // GD.Print($"Created cell at ({y}, {x}) with label {labelText}.");
        });
    }

    private void CreateCellRenderMeshes() {
        float halfPadding = CellPadding / 2.0f;

        ForEachCell((y, x) => {
            var topLeft = new Vector3(x + halfPadding, 0, y + halfPadding);
            var topRight = new Vector3(x + 1 - halfPadding, 0, y + halfPadding);
            var bottomLeft = new Vector3(x + halfPadding, 0, y + 1 - halfPadding);
            var bottomRight = new Vector3(x + 1 - halfPadding, 0, y + 1 - halfPadding);

            var surfaceTool = new SurfaceTool();
            surfaceTool.Begin(Mesh.PrimitiveType.Triangles);

            var cellColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

            // First triangle
            surfaceTool.SetColor(cellColor);
            surfaceTool.AddVertex(topLeft);
            surfaceTool.SetColor(cellColor);
            surfaceTool.AddVertex(topRight);
            surfaceTool.SetColor(cellColor);
            surfaceTool.AddVertex(bottomLeft);

            // Second triangle
            surfaceTool.SetColor(cellColor);
            surfaceTool.AddVertex(topRight);
            surfaceTool.SetColor(cellColor);
            surfaceTool.AddVertex(bottomRight);
            surfaceTool.SetColor(cellColor);
            surfaceTool.AddVertex(bottomLeft);

            var mesh = new ArrayMesh();
            surfaceTool.Commit(mesh);

            var material = new StandardMaterial3D {
                AlbedoColor = cellColor
            };

            var meshInstance = new MeshInstance3D {
                Mesh = mesh,
                MaterialOverride = material,
                Transform = new Transform3D(Basis.Identity, new Vector3(0, 0, 0))
            };

            AddChild(meshInstance);
            cellMeshes.Add(meshInstance);
        });
    }

    private void RenderBattleSquadCharacters() {
        if (CharacterStore is null) {
            GD.PrintErr("CharacterStore is null");
            return;
        }

        if (CharacterComponentScene is null) {
            GD.PrintErr("CharacterComponentScene is null");
            return;
        }

        if (gridCells is null) {
            GD.PrintErr("gridCells is null");
            return;
        }

        // foreach (var character in CharacterStore.Characters) {
        //     if (character.Location?.Name == "Player Squad" || character.Location?.Name == "Enemy Squad" && character.SlotIndex >= 0 && character.SlotIndex < gridCells.Length) {
        //         // Instantiate the CharacterComponent from the packed scene
        //         var characterComponent = CharacterComponentScene.Instantiate<CharacterComponent>();
        //         if (characterComponent is null) {
        //             GD.PrintErr("Failed to instantiate CharacterComponent");
        //             continue;
        //         }

        //         characterComponent.Character = character;

        //         // Position the character at the center of the cell
        //         var gridCell = gridCells[character.SlotIndex / Columns, character.SlotIndex % Columns];
        //         if (gridCell is null) {
        //             GD.PrintErr($"Grid cell at index {character.SlotIndex} is null");
        //             continue;
        //         }
        //         var cellPosition = gridCell.CellMarker.Transform.Origin;
        //         var cellCenter = new Vector3(cellPosition.X + 0.5f, 0, cellPosition.Z + 0.5f); // Use exact grid positions
        //         characterComponent.Transform = new Transform3D(Basis.Identity, cellCenter);
        //         gridCell.SetCharacter(characterComponent);
        //     }
        // }
    }

    public void UpdateCellColor(int index, Color color) {
        if (index < 0 || index >= cellMeshes.Count) {
            GD.PrintErr($"Invalid cell index: {index}");
            return;
        }

        var meshInstance = cellMeshes[index];
        var material = meshInstance.MaterialOverride as StandardMaterial3D;
        if (material != null) {
            material.AlbedoColor = color;
        }
    }

    public void ForEachCell(Action<int, int> action) {
        for (int y = 0; y < Rows; y++) {
            for (int x = 0; x < Columns; x++) {
                action(y, x);
            }
        }
    }
}