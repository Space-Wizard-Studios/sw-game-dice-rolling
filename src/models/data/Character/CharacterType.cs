using Godot;
using System;
using System.Collections.Generic;

using DiceRolling.Roles;
using DiceRolling.Attributes;
using DiceRolling.Locations;
using DiceRolling.Id;
using DiceRolling.Services;
using DiceRolling.Categories;

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
    private readonly Dictionary<AttributeType, int> _attributeCurrentValueCache = [];
    private readonly Dictionary<AttributeType, int> _attributeMaxValueCache = [];
    private readonly Dictionary<AttributeType, int> _attributeBaseValueCache = [];

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
    public Category? Category { get; set; }

    [ExportGroup("🪵 Assets")]

    [Export]
    public Texture2D? Portrait { get; set; }

    [Export]
    public SpriteFrames? CharacterSprite { get; set; }

    [Export]
    public float PixelSize { get; set; } = 0.01f;

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
            EmitChanged();
        }
    }


    [ExportGroup("📊 Attributes")]

    [Export]
    public Godot.Collections.Array<CharacterAttribute> Attributes { get; private set; } = [];

    [ExportToolButton("Initialize Attributes")]
    public Callable InitAttributesButton => Callable.From(() => {
        InitializeAttributes();
        GD.Print($"Attributes initialized for character: {Name}");
    });

    [ExportGroup("🔥 Actions")]

    [Export]
    public Godot.Collections.Array<CharacterAction> Actions { get; private set; } = [];

    [ExportToolButton("Initialize Actions")]
    public Callable InitActionsButton => Callable.From(() => {
        InitializeActions();
        GD.Print($"Actions initialized for character: {Name}");
    });

    [ExportGroup("📍 Placement")]

    [Export]
    public LocationType? Location { get; set; }

    [Export]
    public int SlotIndex { get; set; } = -1;

    public CharacterType() {
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
            value = CharacterService.GetAttributeCurrentValue(this, type);
            _attributeCurrentValueCache[type] = value;
        }
        return value;
    }

    public int GetAttributeMaxValue(AttributeType type) {
        if (!_attributeMaxValueCache.TryGetValue(type, out var value)) {
            value = CharacterService.GetAttributeMaxValue(this, type);
            _attributeMaxValueCache[type] = value;
        }
        return value;
    }

    public int GetAttributeBaseValue(AttributeType type) {
        if (!_attributeBaseValueCache.TryGetValue(type, out var value)) {
            value = CharacterService.GetAttributeBaseValue(this, type);
            _attributeBaseValueCache[type] = value;
        }
        return value;
    }

    public void UpdateAttributeCurrentValue(AttributeType type, int newValue) {
        CharacterService.UpdateAttributeCurrentValue(this, type, newValue);
        _attributeCurrentValueCache[type] = newValue;
    }

    public void AddAction(CharacterAction action) {
        CharacterService.AddAction(this, action);
    }

    public void RemoveAction(CharacterAction action) {
        CharacterService.RemoveAction(this, action);
    }

    public void ValidateConstructor() {
        if (!ValidationService.ValidateName(Name)) {
            throw new ArgumentException("Invalid name", nameof(Name));
        }
    }
}