using Godot;
using DiceRolling.Entities;
using DiceRolling.Grids;
using DiceRolling.Characters;
using DiceRolling.Helpers;

namespace DiceRolling.Components.Grids;

[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class CharacterGridCellComponent : Node3D {
    private GridCellEntity? _parent;
    private GridCellType? _cellData;
    private CharacterEntity? _characterEntity;

    [Export] public PackedScene? CharacterEntityScene { get; set; }
    [Export] public Vector3 CharacterOffset { get; set; } = new Vector3(0, 0, 0);

    public override void _Ready() {
        _parent = GetParent<GridCellEntity>();

        if (_parent != null) {
            // Connect to entity updates
            SignalHelper.ConnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));

            // Get initial data
            _cellData = _parent.CellData;

            if (_cellData != null) {
                // Connect to cell data changes
                SignalHelper.ConnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));

                // Initial update
                UpdateCharacter();
            }
        }
    }

    public override void _ExitTree() {
        if (_parent != null) {
            SignalHelper.DisconnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
        }

        if (_cellData != null) {
            SignalHelper.DisconnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));
        }

        DestroyCharacterEntity();
    }

    private void OnEntityUpdated() {
        if (_parent != null) {
            var newCellData = _parent.CellData;

            // If cell data reference changed
            if (_cellData != newCellData) {
                if (_cellData != null) {
                    SignalHelper.DisconnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));
                }

                _cellData = newCellData;

                if (_cellData != null) {
                    SignalHelper.ConnectSignal(_cellData, nameof(GridCellType.CellChanged), this, nameof(OnCellDataChanged));
                }

                UpdateCharacter();
            }
        }
    }

    private void OnCellDataChanged() {
        UpdateCharacter();
    }

    private void UpdateCharacter() {
        if (_cellData == null) {
            DestroyCharacterEntity();
            return;
        }

        bool hasCharacter = _cellData.IsOccupied && _cellData.Character != null;

        if (hasCharacter) {
            // If no character entity exists but we have character data, create it
            if (_characterEntity == null) {
                CreateCharacterEntity();
            }

            // Update character data
            if (_characterEntity != null && _cellData.Character != null) {
                _characterEntity.CharacterData = _cellData.Character;
                _characterEntity.Visible = true;
            }
        }
        else {
            // If no character should be here, hide or destroy entity
            if (_characterEntity != null) {
                _characterEntity.Visible = false;
            }
        }
    }

    private void CreateCharacterEntity() {
        if (CharacterEntityScene == null) {
            GD.PrintErr("Cannot create character entity: CharacterEntityScene is null");
            return;
        }

        DestroyCharacterEntity(); // Clean up any existing entity

        _characterEntity = CharacterEntityScene.Instantiate<CharacterEntity>();
        _characterEntity.Position = CharacterOffset;
        AddChild(_characterEntity);

        // If we have character data already, set it
        if (_cellData?.Character != null) {
            _characterEntity.CharacterData = _cellData.Character;
        }
        else {
            _characterEntity.Visible = false;
        }
    }

    private void DestroyCharacterEntity() {
        if (_characterEntity != null) {
            _characterEntity.QueueFree();
            _characterEntity = null;
        }
    }
}