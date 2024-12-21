using Godot;
using System;
using DiceRoll.Models;
using DiceRoll.UI;
using DiceRoll.Events;

namespace DiceRoll.Components;

[Tool]
public partial class CharacterComponent : Control {
    private static ArcDrawer? _arcDrawer;

    [ExportGroup("🪵 Resources")]
    private Character? _characterResource;
    [Export]
    public Character? Character {
        get => _characterResource;
        set {
            if (value != null && AnimatedSpriteNode != null && ShadowNode != null) {
                OnCharacterResourceSet(value, AnimatedSpriteNode, ShadowNode);
            }
            _characterResource = value;
        }
    }

    [ExportGroup("🏳️ Flags")]
    [Export]
    public bool IsEnemy { get; set; }

    private bool _isHovered;
    [Export]
    public bool IsHovered {
        get => _isHovered;
        set {
            _isHovered = value;
            OnIsHoveredSet(value);
        }
    }

    private bool _isSelected;
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

    // Static fields to keep track of selected characters
    private static CharacterComponent? _currentlySelectedCharacter;
    private static CharacterComponent? _currentlySelectedEnemy;

    [ExportGroup("🔘 Nodes")]
    [Export] public AnimatedSprite2D? AnimatedSpriteNode { get; set; }
    [Export] public AnimatedSprite2D? ShadowNode { get; set; }
    [Export] public Sprite2D? HoverSpriteNode { get; set; }
    [Export] public Sprite2D? SelectorSpriteNode { get; set; }
    [Export] public Control? SelectionAreaNode { get; set; }

    private void OnMouseEntered() {
        IsHovered = true;
    }

    private void OnMouseExited() {
        IsHovered = false;
    }

    private void OnGuiInput(InputEvent @event) {
        if (@event is InputEventMouseButton { Pressed: true }) {
            if (!IsEnemy) {
                HandleInspection(ref _currentlySelectedCharacter, this, _arcDrawer != null ? _arcDrawer.SetSelectedCharacter : null);
            }
        }
    }

    private static void HandleInspection(ref CharacterComponent? currentlySelected, CharacterComponent current, Action<CharacterComponent>? setSelectedAction) {
        if (currentlySelected != null && currentlySelected != current) {
            currentlySelected.IsSelected = false;
        }
        current.IsSelected = !current.IsSelected;
        currentlySelected = current.IsSelected ? current : null;
        if (currentlySelected != null) {
            setSelectedAction?.Invoke(currentlySelected);
        }
    }

    private static void OnCharacterResourceSet(Character character, AnimatedSprite2D animatedSpriteNode, AnimatedSprite2D shadowNode) {
        if (character == null) {
            GD.PrintErr("CharacterComponent: Character resource is null");
            return;
        }

        if (animatedSpriteNode == null) {
            GD.PrintErr("CharacterComponent: Animated sprite node is null");
            return;
        }

        if (shadowNode == null) {
            GD.PrintErr("CharacterComponent: Shadow node is null");
            return;
        }

        if (character.CharacterSprite != null) {
            animatedSpriteNode.SpriteFrames = character.CharacterSprite;
            animatedSpriteNode.Play("idle");
        }

        if (character.ShadowSprite != null && character.ShowShadow == true) {
            shadowNode.Visible = character.ShowShadow;
            shadowNode.SpriteFrames = character.ShadowSprite;
            shadowNode.Play("idle");
        }
        else {
            shadowNode.Visible = false;
        }
        animatedSpriteNode.Position = new Vector2(character.SpritePositionX, character.SpritePositionY);
    }

    private void OnIsHoveredSet(bool isHovered) {
        if (HoverSpriteNode != null) {
            HoverSpriteNode.Visible = isHovered;
        }

        if (Character != null && !IsEnemy) {
            EventBus.Instance.OnCharacterInspected(Character);
        }
    }

    private void OnIsSelectedSet(bool isSelected) {
        if (SelectorSpriteNode != null) {
            SelectorSpriteNode.Visible = isSelected;
        }
    }

    public void FlipSprite(bool flip) {
        if (AnimatedSpriteNode != null) {
            AnimatedSpriteNode.FlipH = flip;
        }
    }

    public override void _Ready() {
        if (SelectionAreaNode != null) {
            SelectionAreaNode.Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
            SelectionAreaNode.Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
            SelectionAreaNode.Connect("gui_input", new Callable(this, nameof(OnGuiInput)));
        }

        if (Character != null && AnimatedSpriteNode != null && ShadowNode != null) {
            OnCharacterResourceSet(Character, AnimatedSpriteNode, ShadowNode);
        }

        if (Engine.IsEditorHint()) return;

        _arcDrawer ??= GetNode<ArcDrawer>("/root/Battle/ArcDrawer");

    }

}
