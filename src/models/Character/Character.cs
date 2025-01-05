using Godot;
using System;
using System.Linq;
using DiceRoll.Models.Roles;
using DiceRoll.Models.Actions;
using DiceRoll.Models.Attributes;
using DiceRoll.Models.Characters.Locations;

namespace DiceRoll.Models.Characters;

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

    [ExportSubgroup("📊 Stats and Attributes")]
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

    [Export] public Godot.Collections.Array<CharacterAction> Actions { get; private set; } = [];

    [Export] public int DiceCapacity { get; set; } = 0;

    [ExportGroup("📍 Character Location")]
    [Export] public CharacterLocation? Location { get; set; }
    [Export] public int SlotIndex { get; set; } = -1;

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

    /// <summary>
    /// Initializes the character's attributes based on the assigned role.
    /// </summary>
    public void InitializeAttributes() {
        if (Role is null) {
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

    /// <summary>
    /// Initializes the character's actions based on the assigned role.
    /// </summary>
    public void InitializeActions() {
        if (Role?.RoleActionSource is null) {
            GD.PrintErr("RoleActionSource is null");
            return;
        }

        if (Actions.Count == 0) {
            foreach (var action in Role.RoleActionSource.Actions) {
                if (action.ActionType is not null) {
                    var characterAction = new CharacterAction(action.ActionType, action.RequiredMana, action.Effects) {
                        Name = action.Name,
                        Description = action.Description,
                        Icon = action.Icon
                    };
                    Actions.Add(characterAction);
                }
                else {
                    GD.PrintErr("ActionType is null for action: ", action.Name);
                }
            }
        }
    }

    public int GetAttributeCurrentValue(AttributeType type) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        return attribute is not null ? attribute.CurrentValue : 0;
    }

    public int GetAttributeMaxValue(AttributeType type) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        return attribute is not null ? attribute.MaxValue : 0;
    }

    public int GetAttributeBaseValue(AttributeType type) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        return attribute is not null ? attribute.BaseValue : 0;
    }

    public void UpdateAttributeCurrentValue(AttributeType type, int newValue) {
        var attribute = Attributes.FirstOrDefault(attr => attr.Type == type);
        if (attribute is not null) {
            attribute.CurrentValue = newValue;
            EmitSignal(nameof(AttributeChanged), this, type);
        }
    }
}