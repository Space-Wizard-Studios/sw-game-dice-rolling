using Godot;
using DiceRolling.Entities;
using DiceRolling.Characters;
using DiceRolling.Helpers;

namespace DiceRolling.Components;

/// <summary>
/// Component that displays an animated sprite for a character entity.
/// </summary>
/// <remarks>
/// This component listens for updates to the parent Entity3D's CharacterType and updates the sprite accordingly.
/// </remarks>
[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class AnimatedSpriteComponent : AnimatedSprite3D {
    private Entity3D? _parent;

    public override void _Ready() {
        _parent = GetParent<Entity3D>();

        if (_parent != null) {
            SignalHelper.ConnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
            UpdateSprite();
        }
    }

    public override void _ExitTree() {
        if (_parent != null) {
            SignalHelper.DisconnectSignal(_parent, nameof(Entity3D.EntityUpdated), this, nameof(OnEntityUpdated));
        }
    }

    private void OnEntityUpdated() {
        UpdateSprite();
    }

    private void UpdateSprite() {
        if (_parent == null) return;

        var characterData = _parent.GetData<CharacterType>();
        if (characterData == null) return;

        if (characterData.CharacterSprite != null) {
            SpriteFrames = characterData.CharacterSprite;
        }

        PixelSize = characterData.PixelSize;

        Offset = new Vector2(
            characterData.SpritePositionX,
            characterData.SpritePositionY
        );

        Play("idle");

    }
}