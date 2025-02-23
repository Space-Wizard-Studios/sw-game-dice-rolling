using Godot;
using System;
using System.Collections.Generic;

using DiceRolling.Roles;
using DiceRolling.Attributes;
using DiceRolling.Locations;
using DiceRolling.Common;
using DiceRolling.Services;

namespace DiceRolling.Characters;

[Tool]
[GlobalClass]
public partial class CharacterType : IdentifiableResource, ICharacter {
    private string _name = "Character_" + Guid.NewGuid().ToString("N");
    private float _spritePositionX;
    private float _spritePositionY;
    private readonly CharacterService _characterService;
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

    public CharacterType() : this(new CharacterService()) {
    }

    public CharacterType(CharacterService characterService) {
        _characterService = characterService ?? throw new ArgumentNullException(nameof(characterService));
    }

    public CharacterType(string name, RoleType role, CharacterService characterService) : this(characterService) {
        if (!ValidationService.ValidateName(name)) {
            throw new ArgumentException("Invalid name", nameof(name));
        }

        Name = name;
        Role = role;

        _role = role ?? throw new ArgumentNullException(nameof(role));
        InitializeAttributes();
        InitializeActions();
    }

    public void InitializeAttributes() {
        _characterService.InitializeAttributes(this);
    }

    public void InitializeActions() {
        _characterService.InitializeActions(this);
    }

    public int GetAttributeCurrentValue(AttributeType type) {
        if (!_attributeCurrentValueCache.TryGetValue(type, out var value)) {
            value = _characterService.GetAttributeCurrentValue(this, type);
            _attributeCurrentValueCache[type] = value;
        }
        return value;
    }

    public int GetAttributeMaxValue(AttributeType type) {
        if (!_attributeMaxValueCache.TryGetValue(type, out var value)) {
            value = _characterService.GetAttributeMaxValue(this, type);
            _attributeMaxValueCache[type] = value;
        }
        return value;
    }

    public int GetAttributeBaseValue(AttributeType type) {
        if (!_attributeBaseValueCache.TryGetValue(type, out var value)) {
            value = _characterService.GetAttributeBaseValue(this, type);
            _attributeBaseValueCache[type] = value;
        }
        return value;
    }

    public void UpdateAttributeCurrentValue(AttributeType type, int newValue) {
        _characterService.UpdateAttributeCurrentValue(this, type, newValue);
        _attributeCurrentValueCache[type] = newValue;
    }

    public void AddAction(CharacterAction action) {
        _characterService.AddAction(this, action);
    }

    public void RemoveAction(CharacterAction action) {
        _characterService.RemoveAction(this, action);
    }

    public void ValidateConstructor() {
        if (!ValidationService.ValidateName(Name)) {
            throw new ArgumentException("Invalid name", nameof(Name));
        }
    }
}