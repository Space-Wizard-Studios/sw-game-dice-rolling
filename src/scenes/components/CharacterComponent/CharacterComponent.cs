using Godot;
using System;
using DiceRolling.Events;
using DiceRolling.Models.Characters;

namespace DiceRolling.Components.Characters;

[Tool]
public partial class CharacterComponent : Node3D {
    private static CharacterComponent? _currentlySelectedCharacter;

    [ExportGroup("🪵 Resources")]
    private CharacterType? _characterResource;

    [Export]
    public CharacterType? Character {
        get => _characterResource;
        set {
            _characterResource = value;
            OnCharacterResourceSet();
        }
    }

    [ExportGroup("🏳️ Flags")]
    [Export]
    public bool IsEnemy { get; set; }

    private bool _isHovered = false;
    [Export]
    public bool IsHovered {
        get => _isHovered;
        set {
            _isHovered = value;
            OnIsHoveredSet(value);
        }
    }

    private bool _isSelected = false;
    [Export]
    public bool IsSelected {
        get => _isSelected;
        set {
            if (_isSelected != value) {
                _isSelected = value;
                OnIsSelectedSet(value);
            }
        }
    }

    [ExportGroup("🔘 Nodes")]
    [Export] public AnimatedSprite3D? AnimatedSpriteNode { get; set; }
    [Export] public Sprite3D? HoverSpriteNode { get; set; }
    [Export] public Sprite3D? SelectorSpriteNode { get; set; }
    [Export] public Area3D? InputAreaNode { get; set; }

    public override void _Ready() {
        ConnectSignals();
        if (HoverSpriteNode is not null) {
            HoverSpriteNode.Visible = false;
        }
        if (SelectorSpriteNode is not null) {
            SelectorSpriteNode.Visible = false;
        }

        // Connect the CharacterUnselected signal from EventBus to the OnCharacterUnselected method
        EventBus.Instance.Connect(nameof(EventBus.CharacterUnselected), new Callable(this, nameof(OnCharacterUnselected)));
    }

    private void ConnectSignals() {
        InputAreaNode?.Connect("input_event", new Callable(this, nameof(OnInputEvent)));
        InputAreaNode?.Connect("mouse_entered", Callable.From(OnMouseEntered));
        InputAreaNode?.Connect("mouse_exited", Callable.From(OnMouseExited));
    }

    private void OnInputEvent(Node camera, InputEvent @event, Vector3 click_position, Vector3 normal, int shape_idx) {
        if (@event is InputEventMouseButton { Pressed: true }) {
            if (!IsEnemy) {
                HandleSelection(this);
            }
        }
    }

    private static void HandleSelection(CharacterComponent current) {
        if (_currentlySelectedCharacter == current) {
            current.IsSelected = false;
            _currentlySelectedCharacter = null;
            EventBus.Instance.EmitSignal(nameof(EventBus.CharacterUnselected));
        }
        else {
            if (_currentlySelectedCharacter is not null) {
                _currentlySelectedCharacter.IsSelected = false;
            }
            current.IsSelected = true;
            _currentlySelectedCharacter = current;
            EventBus.Instance.EmitSignal(nameof(EventBus.CharacterSelected), current);
        }
    }

    private void OnCharacterUnselected() {
        IsSelected = false;
    }

    private void OnMouseEntered() {
        IsHovered = true;
    }

    private void OnMouseExited() {
        IsHovered = false;
    }

    private void OnIsHoveredSet(bool isHovered) {
        if (HoverSpriteNode is not null) {
            HoverSpriteNode.Visible = isHovered;
        }
    }

    private void OnIsSelectedSet(bool isSelected) {
        if (SelectorSpriteNode is not null) {
            SelectorSpriteNode.Visible = isSelected;
        }
    }

    public void FlipSprite(bool flip) {
        if (AnimatedSpriteNode is not null) {
            AnimatedSpriteNode.FlipH = flip;
        }
    }

    private void OnCharacterResourceSet() {
        if (Character is null) {
            return;
        }

        if (AnimatedSpriteNode is null) {
            return;
        }

        if (Character.CharacterSprite is not null) {
            AnimatedSpriteNode.SpriteFrames = Character.CharacterSprite;
            AnimatedSpriteNode.Transform = new Transform3D(Basis.Identity, new Vector3(Character.SpritePositionX, 0.5f + Character.SpritePositionY, 0));
            AnimatedSpriteNode.Play("idle");
        }

    }
}