using Godot;
using System;
using System.Linq;
using DiceRoll.Models.CharacterActions;

namespace DiceRoll.Models;

/// <summary>
/// Represents a character in the game with attributes, actions, and other properties.
/// </summary>
[Tool]
[GlobalClass]
public partial class Character : Resource {
    [Signal] public delegate void AttributeChangedEventHandler(Character character, AttributeType attributeType);

    [ExportGroup("🦸 Character")]
    [Export] public string Id { get; set; } = Guid.NewGuid().ToString();

    [Export] public string? Name { get; set; }

    [Export] public bool IsEnemy { get; set; } = false;

    private Role? _role;

    [Export]
    public Role? Role {
        get => _role;
        set {
            _role = value;
            EmitChanged();
            InitializeAttributes();
            InitializeActions();
        }
    }

    [Export] public Godot.Collections.Array<CharacterAttribute> Attributes { get; private set; } = [];

    [Export] public Godot.Collections.Array<CharacterAction> CharacterActions { get; private set; } = [];

    [Export] public int DiceCapacity { get; set; } = 0;

    [ExportGroup("🪵 Resources")]
    [Export] public Texture2D? Portrait { get; set; }

    [Export] public SpriteFrames? CharacterSprite { get; set; }

    [Export] public SpriteFrames? ShadowSprite { get; set; }

    [Export] public bool ShowShadow { get; set; }

    private float _spritePositionX;

    [Export]
    public float SpritePositionX {
        get => _spritePositionX;
        set {
            _spritePositionX = value;
            EmitChanged();
        }
    }

    private float _spritePositionY;

    [Export]
    public float SpritePositionY {
        get => _spritePositionY;
        set {
            _spritePositionY = value;
            EmitChanged();
        }
    }

    public Character() { }

    public void InitializeAttributes() {
        if (Role == null) {
            GD.PrintErr("Role is null");
            return;
        }

        if (Attributes.Count == 0) {
            foreach (var roleAttribute in Role.RoleAttributes) {
                var characterAttribute = new CharacterAttribute(roleAttribute) {
                    MaxValue = roleAttribute.BaseValue,
                    CurrentValue = roleAttribute.BaseValue
                };
                Attributes.Add(characterAttribute);
            }
        }
    }

    public void InitializeActions() {
        if (Role == null) {
            GD.PrintErr("Role is null");
            return;
        }

        CharacterActions = new Godot.Collections.Array<CharacterAction>(Role.RoleActions);
    }

    public int GetAttributeCurrentValue(AttributeType type) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        return attribute != null ? attribute.CurrentValue : 0;
    }

    public int GetAttributeMaxValue(AttributeType type) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        return attribute != null ? attribute.MaxValue : 0;
    }

    public int GetAttributeBaseValue(AttributeType type) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        return attribute != null ? attribute.BaseValue : 0;
    }

    public void UpdateAttributeCurrentValue(AttributeType type, int newValue) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        if (attribute != null) {
            attribute.CurrentValue = newValue;
            EmitSignal(nameof(AttributeChanged), this, type);
        }
    }
}