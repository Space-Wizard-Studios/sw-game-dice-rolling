using Godot;
using System.Collections.Generic;
using DiceRoll.Components.Characters;
using DiceRoll.Stores;

namespace DiceRoll.Components.Grids;

[Tool]
public partial class Grid3D : Node3D {
    [Export] public int Columns { get; set; } = 1;
    [Export] public int Rows { get; set; } = 1;
    [Export] public string Prefix { get; set; } = "G";
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Export] public PackedScene? CharacterComponentScene { get; set; }
    private readonly List<GridCell3D> gridCells = [];
    private MeshInstance3D? debugMeshInstance;
    private ArrayMesh? debugMesh;

    public override void _Ready() {
        base._Ready();
        GenerateGridCells();
        RenderBattleSquadCharacters();
    }

    public void GenerateGridCells() {
        ClearExistingCells();
        CreateNewCells();
        if (Engine.IsEditorHint()) {
            CreateDebugMesh();
        }
    }

    private void ClearExistingCells() {
        foreach (var cell in gridCells) {
            RemoveChild(cell);
            cell.QueueFree();
        }
        gridCells.Clear();
    }

    private void CreateNewCells() {
        int index = 0;
        for (int x = 0; x < Columns; x++) {
            for (int y = 0; y < Rows; y++) {
                var position = new Vector3(x, 0, y);
                var labelText = $"{Prefix}{index}({x},{y})";
                var gridCell = new GridCell3D(position, labelText);
                AddChild(gridCell);
                gridCells.Add(gridCell);
                index++;
            }
        }
    }

    private void CreateDebugMesh() {
        if (debugMeshInstance is not null) {
            RemoveChild(debugMeshInstance);
            debugMeshInstance.QueueFree();
        }

        debugMesh = new ArrayMesh();
        debugMeshInstance = new MeshInstance3D {
            Mesh = debugMesh
        };
        AddChild(debugMeshInstance);
        UpdateDebugMesh();
    }

    public void UpdateDebugMesh() {
        if (debugMesh is null) {
            return;
        }

        debugMesh.ClearSurfaces();
        var surfaceTool = new SurfaceTool();
        surfaceTool.Begin(Mesh.PrimitiveType.Lines);

        for (int x = 0; x <= Columns; x++) {
            surfaceTool.AddVertex(new Vector3(x, 0, 0));
            surfaceTool.AddVertex(new Vector3(x, 0, Rows));
        }

        for (int y = 0; y <= Rows; y++) {
            surfaceTool.AddVertex(new Vector3(0, 0, y));
            surfaceTool.AddVertex(new Vector3(Columns, 0, y));
        }

        surfaceTool.Commit(debugMesh);
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
            if (character.Location?.Name == "Battle Squad" && character.SlotIndex >= 0 && character.SlotIndex < gridCells.Count) {
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
}