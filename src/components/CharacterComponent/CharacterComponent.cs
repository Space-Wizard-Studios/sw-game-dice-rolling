using Godot;
using System;
using DiceRoll.Models;
using DiceRoll.Events;

namespace DiceRoll.Components.Characters;

/// <summary>
/// Represents a character in the game, managing character-specific properties and behaviors.
/// </summary>
[Tool]
public partial class CharacterComponent : Node3D {
    private static CharacterComponent? _currentlySelectedCharacter;
    // private static CharacterComponent? _currentlySelectedEnemy;

    [ExportGroup("🪵 Resources")]
    private Character? _characterResource;

    [Export]
    public Character? Character {
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
    }

    private void ConnectSignals() {
        InputAreaNode?.Connect("input_event", new Callable(this, nameof(OnInputEvent)));
        InputAreaNode?.Connect("mouse_entered", Callable.From(OnMouseEntered));
        InputAreaNode?.Connect("mouse_exited", Callable.From(OnMouseExited));
    }

    private void OnInputEvent(Node camera, InputEvent @event, Vector3 click_position, Vector3 normal, int shape_idx) {
        if (@event is InputEventMouseButton { Pressed: true }) {
            if (!IsEnemy) {
                HandleInspection(ref _currentlySelectedCharacter, this, null);
            }
        }
    }

    /// <summary>
    /// Handles the inspection logic for the character.
    /// </summary>
    private static void HandleInspection(ref CharacterComponent? currentlySelected, CharacterComponent current, Action<CharacterComponent>? setSelectedAction) {
        if (currentlySelected is not null && currentlySelected != current) {
            currentlySelected.IsSelected = false;
        }
        current.IsSelected = !current.IsSelected;
        currentlySelected = current.IsSelected ? current : null;
        if (currentlySelected is not null) {
            setSelectedAction?.Invoke(currentlySelected);
        }
    }

    private void OnMouseEntered() {
        IsHovered = true;
    }

    private void OnMouseExited() {
        IsHovered = false;
    }

    /// <summary>
    /// Called when the <see cref="IsHovered"/> property is set.
    /// </summary>
    /// <param name="isHovered">The new value of the IsHovered property.</param>
    private void OnIsHoveredSet(bool isHovered) {
        if (HoverSpriteNode is not null) {
            HoverSpriteNode.Visible = isHovered;
        }
    }

    private void OnIsSelectedSet(bool isSelected) {
        if (SelectorSpriteNode is not null) {
            SelectorSpriteNode.Visible = isSelected;
        }

        if (Character is not null && !IsEnemy) {
            EventBus.Instance.OnCharacterInspected(Character);
        }

    }

    public void FlipSprite(bool flip) {
        if (AnimatedSpriteNode is not null) {
            AnimatedSpriteNode.FlipH = flip;
        }
    }

    /// <summary>
    /// Gets or sets the character resource.
    /// </summary>
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

        GD.Print($"Character set in OnCharacterResourceSet(): {Character.Name}");
    }
}