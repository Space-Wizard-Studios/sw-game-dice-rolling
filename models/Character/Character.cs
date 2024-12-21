using Godot;
using System;
using System.Linq;

namespace DiceRoll.Models;

[Tool]
[GlobalClass]
public partial class Character : Resource {
    [ExportGroup("🧝 Character")]
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
        }
    }

    [Export] public Godot.Collections.Array<CharacterAttribute> Attributes { get; private set; } = new Godot.Collections.Array<CharacterAttribute>();

    [Export] public int DiceCapacity { get; set; } = 0;

    [ExportGroup("🪵 Resources")]
    [Export] public Texture2D? Portrait { get; set; }
    [Export] public SpriteFrames? CharacterSprite { get; set; }
    [Export] public SpriteFrames? ShadowSprite { get; set; }

    [ExportGroup("⚙️ Config")]
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

        // Initialize attributes only if they are not already set
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

    public AttackResult PerformAction(CharacterAction characterAction, Character target) {
        var context = new AttackContext(this, target);
        var action = ActionFactory.CreateAction(characterAction.ActionType);
        return action.Do(context);
    }
}