using Godot;
using DiceRoll.Models;

namespace DiceRoll.Components;

[Tool]
public partial class CharacterComponent : Control {

    private static CharacterComponent? _currentlySelectedCharacter;

    private bool _isHovered;
    [Export]
    public bool IsHovered {
        get => _isHovered;
        set {
            _isHovered = value;
            OnIsHoveredSet(value);
        }
    }

    [Export]
    public Sprite2D? HoverSpriteNode { get; set; }

    private bool _isSelected;
    [Export]
    public bool IsSelected {
        get => _isSelected;
        set {
            _isSelected = value;
            OnIsSelectedSet(value);
        }
    }

    [Export]
    public Sprite2D? SelectorSpriteNode { get; set; }

    [Export]
    public Control? SelectionAreaNode { get; set; }

    [Export]
    public AnimatedSprite2D? AnimatedSpriteNode { get; set; }

    private bool _showShadow;

    [Export]
    public AnimatedSprite2D? ShadowNode { get; set; }

    private Character? _characterResource;

    [Export]
    public Character? CharacterResource {
        get => _characterResource;
        set {
            if (_characterResource != null && value != null && AnimatedSpriteNode != null && ShadowNode != null) {
                OnCharacterResourceSet(value, AnimatedSpriteNode, ShadowNode);
            }
            _characterResource = value;
        }
    }

    private void OnMouseEntered() {
        IsHovered = true;
    }

    private void OnMouseExited() {
        IsHovered = false;
    }

    private void OnGuiInput(InputEvent @event) {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
            if (_currentlySelectedCharacter != null && _currentlySelectedCharacter != this) {
                _currentlySelectedCharacter.IsSelected = false;
            }
            IsSelected = !IsSelected;
            _currentlySelectedCharacter = IsSelected ? this : null;
        }
    }

    private static void OnCharacterResourceSet(Character characterResource, AnimatedSprite2D animatedSpriteNode, AnimatedSprite2D shadowNode) {
        if (characterResource == null) {
            GD.PrintErr("Character resource is null");
            return;
        }

        if (animatedSpriteNode == null) {
            GD.PrintErr("Animated sprite node is null");
            return;
        }

        if (shadowNode == null) {
            GD.PrintErr("Shadow node is null");
            return;
        }

        if (characterResource.CharacterSprite != null) {
            animatedSpriteNode.SpriteFrames = characterResource.CharacterSprite;
            animatedSpriteNode.Play("idle");
        }

        if (characterResource.ShadowSprite != null || characterResource.ShowShadow == true) {
            shadowNode.Visible = characterResource.ShowShadow;
            shadowNode.SpriteFrames = characterResource.ShadowSprite;
            shadowNode.Play("idle");
        }
        else {
            shadowNode.Visible = false;
        }
        animatedSpriteNode.Position = new Vector2(characterResource.SpritePositionX, characterResource.SpritePositionY);
    }

    private void OnIsHoveredSet(bool isHovered) {
        if (HoverSpriteNode != null) {
            HoverSpriteNode.Visible = isHovered;
        }
    }

    private void OnIsSelectedSet(bool isSelected) {
        if (SelectorSpriteNode != null) {
            SelectorSpriteNode.Visible = isSelected;
        }
    }

    public override void _Ready() {
        if (SelectionAreaNode != null) {
            SelectionAreaNode.Connect("mouse_entered", new Callable(this, nameof(OnMouseEntered)));
            SelectionAreaNode.Connect("mouse_exited", new Callable(this, nameof(OnMouseExited)));
            SelectionAreaNode.Connect("gui_input", new Callable(this, nameof(OnGuiInput)));
        }

        if (CharacterResource != null && AnimatedSpriteNode != null && ShadowNode != null) {
            OnCharacterResourceSet(CharacterResource, AnimatedSpriteNode, ShadowNode);
        }
    }

    public void FlipCharacter(bool flip) {
        if (AnimatedSpriteNode != null) {
            AnimatedSpriteNode.FlipH = flip;
        }
    }
}