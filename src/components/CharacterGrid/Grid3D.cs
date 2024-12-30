using Godot;
using System.Collections.Generic;

namespace DiceRoll.Components;

[Tool]
public partial class Grid3D : Node3D {

    [Export] public int Columns { get; set; } = 0;

    [Export] public int Rows { get; set; } = 0;

    [Export] public string Prefix { get; set; } = "G";

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
                    Transform = new Transform3D(Basis.Identity, new Vector3(x + 0.5f, 0.5f, y + 0.5f))
                };
                AddChild(label);
                debugLabels.Add(label);

                index++;
            }
        }

        if (Engine.IsEditorHint()) {
            CreateDebugMesh();
        }
    }

    private void CreateDebugMesh() {
        if (debugMeshInstance != null) {
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
        if (debugMesh == null) {
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
}