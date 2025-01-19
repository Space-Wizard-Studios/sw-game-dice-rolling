using Godot;
using System.Collections.Generic;
using DiceRoll.Components.Characters;
using DiceRoll.Stores;

namespace DiceRoll.Components.Grids;

[Tool]
public partial class Grid3D : Node3D {
    [Export] public int Rows { get; set; } = 1;
    [Export] public int Columns { get; set; } = 1;
    [Export] public string Prefix { get; set; } = "G";
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Export] public PackedScene? CharacterComponentScene { get; set; }
    [Export] public float CellPadding { get; set; }
    private readonly List<GridCell3D> gridCells = new();
    private readonly List<MeshInstance3D> cellMeshes = new();

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
        foreach (var cell in gridCells) {
            RemoveChild(cell);
            cell.QueueFree();
        }
        gridCells.Clear();

        foreach (var mesh in cellMeshes) {
            RemoveChild(mesh);
            mesh.QueueFree();
        }
        cellMeshes.Clear();
    }

    private void CreateNewCells() {
        int index = 0;
        for (int y = 0; y < Rows; y++) {
            for (int x = 0; x < Columns; x++) {
                var position = new Vector3(x, 0, y);
                var labelText = $"{Prefix}{index}({x},{y})";
                var gridCell = new GridCell3D(position, labelText);
                AddChild(gridCell);
                gridCells.Add(gridCell);
                index++;
            }
        }
    }

    private void CreateCellRenderMeshes() {
        float halfPadding = CellPadding / 2.0f;

        for (int x = 0; x < Columns; x++) {
            for (int y = 0; y < Rows; y++) {
                var topLeft = new Vector3(x + halfPadding, 0, y + halfPadding);
                var topRight = new Vector3(x + 1 - halfPadding, 0, y + halfPadding);
                var bottomLeft = new Vector3(x + halfPadding, 0, y + 1 - halfPadding);
                var bottomRight = new Vector3(x + 1 - halfPadding, 0, y + 1 - halfPadding);

                var surfaceTool = new SurfaceTool();
                surfaceTool.Begin(Mesh.PrimitiveType.Triangles);

                var cellColor = new Color(0.5f, 0.5f, 0.5f, 0.5f); // Semi-transparent gray

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

                var material = new StandardMaterial3D();
                material.AlbedoColor = cellColor;

                var meshInstance = new MeshInstance3D {
                    Mesh = mesh,
                    MaterialOverride = material,
                    Transform = new Transform3D(Basis.Identity, new Vector3(0, 0, 0))
                };

                AddChild(meshInstance);
                cellMeshes.Add(meshInstance);
            }
        }
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

        foreach (var character in CharacterStore.Characters) {
            if (character.Location?.Name == "Player Squad" || character.Location?.Name == "Enemy Squad" && character.SlotIndex >= 0 && character.SlotIndex < gridCells.Count) {
                // Instantiate the CharacterComponent from the packed scene
                var characterComponent = CharacterComponentScene.Instantiate<CharacterComponent>();
                if (characterComponent is null) {
                    GD.PrintErr("Failed to instantiate CharacterComponent");
                    continue;
                }

                characterComponent.Character = character;

                // Position the character at the middle point of the cell
                var gridCell = gridCells[character.SlotIndex];
                var cellPosition = gridCell.CellMarker.Transform.Origin;
                characterComponent.Transform = new Transform3D(Basis.Identity, new Vector3(cellPosition.X + 0.5f, 0, cellPosition.Z + 0.5f));
                gridCell.SetCharacter(characterComponent);
            }
        }
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
}