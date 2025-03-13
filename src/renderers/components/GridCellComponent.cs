using Godot;
using DiceRolling.Entities;
using DiceRolling.Grids;
using DiceRolling.Characters;
using DiceRolling.Helpers;

namespace DiceRolling.Components.Grids;

[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class GridCellComponent : Node3D {
    private Entity3D? _parent;
    private GridCellEntity? _cellEntity;
    private GridCellType? _cellData;

    [Export] public MeshInstance3D? CellMeshNode { get; set; }
    [Export] public Label3D? LabelNode { get; set; }
    [Export] public bool ShowLabel { get; set; } = true;
    [Export] public Color HighlightColor { get; set; } = new Color(1, 1, 0, 0.5f);
    [Export] public Color DefaultColor { get; set; } = new Color(1, 1, 1, 1);
    [Export] public Color OccupiedColor { get; set; } = new Color(0.8f, 0.8f, 1, 1);

    public override void _Ready() {
        _parent = GetParent<Entity3D>();
        _cellEntity = _parent as GridCellEntity;

        if (_cellEntity != null) {
            // Connect to entity updates
            SignalHelper.ConnectSignal(_cellEntity, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));

            // Get initial data
            _cellData = _cellEntity.CellData;

            if (_cellData != null) {
                // Connect to cell data changes
                SignalHelper.ConnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));

                // Initial update
                UpdateVisual();
            }
        }
    }

    public override void _ExitTree() {
        if (_cellEntity != null) {
            SignalHelper.DisconnectSignal(_cellEntity, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
        }

        if (_cellData != null) {
            SignalHelper.DisconnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));
        }
    }

    private void OnEntityUpdated() {
        if (_cellEntity != null) {
            // Get possibly updated data reference
            var newCellData = _cellEntity.CellData;

            // If data reference changed, reconnect signals
            if (_cellData != newCellData) {
                if (_cellData != null) {
                    SignalHelper.DisconnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));
                }

                _cellData = newCellData;

                if (_cellData != null) {
                    SignalHelper.ConnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));
                }
            }

            UpdateVisual();
        }
    }

    private void OnCellDataChanged() {
        UpdateVisual();
    }

    private void UpdateVisual() {
        if (_cellData == null) return;

        // Update label text if we have a label component
        if (LabelNode != null && ShowLabel) {
            LabelNode.Text = _cellData.Label;
            LabelNode.Visible = true;
        }
        else if (LabelNode != null) {
            LabelNode.Visible = false;
        }

        // Update cell color/appearance based on state
        if (CellMeshNode != null) {
            // Set different appearance based on whether cell is occupied
            if (_cellData.IsOccupied) {
                SetCellMaterial(OccupiedColor);
            }
            else {
                SetCellMaterial(DefaultColor);
            }
        }
    }

    private void SetCellMaterial(Color color) {
        if (CellMeshNode == null) return;

        // Creating a new material if needed
        if (CellMeshNode.MaterialOverride is not StandardMaterial3D currentMat) {
            currentMat = new StandardMaterial3D();
            CellMeshNode.MaterialOverride = currentMat;
        }

        // Update material properties
        ((StandardMaterial3D)CellMeshNode.MaterialOverride).AlbedoColor = color;
    }
}