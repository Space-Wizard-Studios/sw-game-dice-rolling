using Godot;
using System;
using System.Collections.Generic;

using DiceRolling.Roles;
using DiceRolling.Attributes;
using DiceRolling.Locations;
using DiceRolling.Common;
using DiceRolling.Services;

namespace DiceRolling.Characters;

/// <summary>
/// Representa um tipo de personagem no jogo e inclui suas informações, atributos, ações, recursos visuais, localização e papel.
/// Esta classe também fornece métodos para inicializar e gerenciar esses aspectos.
/// </summary>
[Tool]
[GlobalClass]
public partial class CharacterType : IdentifiableResource, ICharacter {
    private string _name = "Character_" + IdService.Instance.GenerateNewId();
    private float _spritePositionX;
    private float _spritePositionY;
    private RoleType? _role;
    private readonly Dictionary<AttributeType, int> _attributeCurrentValueCache = new Dictionary<AttributeType, int>();
    private readonly Dictionary<AttributeType, int> _attributeMaxValueCache = new Dictionary<AttributeType, int>();
    private readonly Dictionary<AttributeType, int> _attributeBaseValueCache = new Dictionary<AttributeType, int>();

    [Signal] public delegate void AttributeChangedEventHandler(CharacterType character, AttributeType attributeType);

    [ExportGroup("📝 Information")]

    [Export]
    public string Name {
        get => _name;
        set {
            if (ValidationService.ValidateName(value)) {
                _name = value;
                EmitChanged();
            }
        }
    }

    [Export]
    public CharacterCategory? Category { get; set; }

    [ExportGroup("🪵 Assets")]

    [Export]
    public Texture2D? Portrait { get; set; }

    [Export]
    public SpriteFrames? CharacterSprite { get; set; }

    [Export]
    public SpriteFrames? ShadowSprite { get; set; }

    [Export]
    public bool ShowShadow { get; set; }

    [Export]
    public float SpritePositionX {
        get => _spritePositionX;
        set {
            _spritePositionX = value;
            EmitChanged();
        }
    }

    [Export]
    public float SpritePositionY {
        get => _spritePositionY;
        set {
            _spritePositionY = value;
            EmitChanged();
        }
    }

    [ExportGroup("🦸‍♂ Role")]

    [Export]
    public RoleType? Role {
        get => _role;
        set {
            _role = value;
            InitializeAttributes();
            InitializeActions();
            EmitChanged();
        }
    }

    [ExportGroup("📊 Attributes")]

    [Export]
    public Godot.Collections.Array<CharacterAttribute> Attributes { get; private set; } = new();

    [ExportGroup("🔥 Actions")]

    [Export]
    public Godot.Collections.Array<CharacterAction> Actions { get; private set; } = new();

    [ExportGroup("📍 Placement")]

    [Export]
    public LocationType? Location { get; set; }

    [Export]
    public int SlotIndex { get; set; } = -1;

    public CharacterType() {
        InitializeAttributes();
        InitializeActions();
    }

    public CharacterType(string name, RoleType role) {
        Name = name;
        Role = role;
        ValidateConstructor();
        InitializeAttributes();
        InitializeActions();
    }

    public void InitializeAttributes() {
        CharacterService.Instance.InitializeAttributes(this);
    }

    public void InitializeActions() {
        CharacterService.Instance.InitializeActions(this);
    }

    public int GetAttributeCurrentValue(AttributeType type) {
        if (!_attributeCurrentValueCache.TryGetValue(type, out var value)) {
            value = CharacterService.Instance.GetAttributeCurrentValue(this, type);
            _attributeCurrentValueCache[type] = value;
        }
        return value;
    }

    public int GetAttributeMaxValue(AttributeType type) {
        if (!_attributeMaxValueCache.TryGetValue(type, out var value)) {
            value = CharacterService.Instance.GetAttributeMaxValue(this, type);
            _attributeMaxValueCache[type] = value;
        }
        return value;
    }

    public int GetAttributeBaseValue(AttributeType type) {
        if (!_attributeBaseValueCache.TryGetValue(type, out var value)) {
            value = CharacterService.Instance.GetAttributeBaseValue(this, type);
            _attributeBaseValueCache[type] = value;
        }
        return value;
    }

    public void UpdateAttributeCurrentValue(AttributeType type, int newValue) {
        CharacterService.Instance.UpdateAttributeCurrentValue(this, type, newValue);
        _attributeCurrentValueCache[type] = newValue;
    }

    public void AddAction(CharacterAction action) {
        CharacterService.Instance.AddAction(this, action);
    }

    public void RemoveAction(CharacterAction action) {
        CharacterService.Instance.RemoveAction(this, action);
    }

    public void ValidateConstructor() {
        if (!ValidationService.ValidateName(Name)) {
            throw new ArgumentException("Invalid name", nameof(Name));
        }
    }
}