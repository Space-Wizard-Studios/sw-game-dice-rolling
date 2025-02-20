using Godot;
using System;
using System.Linq;
using DiceRolling.Roles;
using DiceRolling.Attributes;
using DiceRolling.Locations;

namespace DiceRolling.Characters;

[Tool]
[GlobalClass]
public partial class CharacterType : Resource, ICharacter {
    [Signal] public delegate void AttributeChangedEventHandler(CharacterType character, AttributeType attributeType);

    [ExportGroup("🦸 Character")]
    [Export] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Export] public string? Name { get; set; }
    [Export] public CharacterCategory? Category { get; set; }
    private RoleType? _role;
    [Export]
    public RoleType? Role {
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
    [Export] public LocationType? Location { get; set; }
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

    public void InitializeAttributes() {
        if (Role is null) {
            // GD.PrintErr("Role is null");
            return;
        }

        if (Role.RoleAttributes.Count == 0) {
            // GD.PrintErr("RoleAttributes is empty");
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
        if (Role is null) {
            // GD.PrintErr("Role is null");
            return;
        }

        if (Role.RoleActions.Count == 0) {
            // GD.PrintErr("RoleActions is empty");
            return;
        }

        if (Actions.Count == 0) {
            foreach (var roleAction in Role.RoleActions) {
                var characterAction = new CharacterAction(roleAction);
                Actions.Add(characterAction);
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
            // EmitSignal(nameof(AttributeChanged), this, type);
        }
    }

    public void AddAction(CharacterAction action) {
        // Implementação para adicionar uma ação
    }

    public void RemoveAction(CharacterAction action) {
        // Implementação para remover uma ação
    }
}