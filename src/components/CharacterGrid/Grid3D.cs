using Godot;
using System.Collections.Generic;
using DiceRoll.Components.Characters;
using DiceRoll.Stores;

namespace DiceRoll.Components.Grids;

[Tool]
public partial class Grid3D : Node3D {
    [Export] public int Columns { get; set; } = 0;
    [Export] public int Rows { get; set; } = 0;
    [Export] public string Prefix { get; set; } = "G";
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Export] public PackedScene? CharacterComponentScene { get; set; }
    private readonly List<Marker3D> gridCells = [];
    private readonly List<Label3D> debugLabels = [];
    private MeshInstance3D? debugMeshInstance;
    private ArrayMesh? debugMesh;

    public override void _Ready() {
        base._Ready();
        GenerateGridCells();
        if (Engine.IsEditorHint()) {
            CreateDebugMesh();
        }
    }

    public void GenerateGridCells() {
        // Clear existing cells and labels
        foreach (var cell in gridCells) {
            RemoveChild(cell);
            cell.QueueFree();
        }

        gridCells.Clear();

        foreach (var label in debugLabels) {
            RemoveChild(label);
            label.QueueFree();
        }

        debugLabels.Clear();

        // Generate new cells
        int index = 0;
        for (int x = 0; x < Columns; x++) {
            for (int y = 0; y < Rows; y++) {
                Marker3D cell = new() {
                    Transform = new Transform3D(Basis.Identity, new Vector3(x, 0, y))
                };
                AddChild(cell);
                gridCells.Add(cell);

                // Create and add label for cell index
                Label3D label = new() {
                    Text = $"{Prefix}{index}({x},{y})",
                    Transform = new Transform3D(Basis.Identity, new Vector3(x + 0.55f, 0.25f, y + 1)),
                    Billboard = BaseMaterial3D.BillboardModeEnum.Enabled,
                };
                AddChild(label);
                debugLabels.Add(label);

                index++;
            }
        }

        if (Engine.IsEditorHint()) {
            CreateDebugMesh();
        }

        RenderBattleSquadCharacters();
    }

    private void CreateDebugMesh() {
        if (debugMeshInstance is not null) {
            RemoveChild(debugMeshInstance);
            debugMeshInstance.QueueFree();
        }

        debugMesh = new ArrayMesh();
        debugMeshInstance = new MeshInstance3D();
        debugMeshInstance.Mesh = debugMesh;
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
            if (character.Location?.Name == "Battle Squad" && character.SlotIndex >= 0) {
                int x = character.SlotIndex % Columns;
                int y = character.SlotIndex / Columns;

                // Instantiate the CharacterComponent from the packed scene
                var characterComponent = (CharacterComponent)CharacterComponentScene.Instantiate();
                if (characterComponent is null) {
                    GD.PrintErr("Failed to instantiate CharacterComponent");
                    continue;
                }

                characterComponent.Character = character;

                // Position the character at the middle point of the cell
                characterComponent.Transform = new Transform3D(Basis.Identity, new Vector3(x + 0.5f, 0, y + 0.5f));
                AddChild(characterComponent);
            }
        }
    }
}