using Godot;
using DiceRolling.Dice;
using DiceRolling.Effects;
using System;
using DiceRolling.Common;
using DiceRolling.Services;

namespace DiceRolling.Actions;

[Tool]
[GlobalClass]
public partial class ActionCategory : IdentifiableResource, IActionCategory {
    private string? _name = "Action Category";
    private Texture2D? _icon;

    [ExportGroup("📝 Information")]

    [Export]
    public string? Name {
        get => _name;
        set {
            if (ValidationService.ValidateName(value)) {
                _name = value;
            }
        }
    }

    [Export(PropertyHint.MultilineText)]
    public string? Description { get; set; }

    [ExportGroup("🪵 Assets")]

    [Export]
    public Texture2D? Icon {
        get => _icon;
        set {
            _icon = value;
            if (_icon is not null) {
                IconPath = _icon.ResourcePath;
            }
        }
    }
    public string? IconPath { get; private set; }

    [ExportGroup("🎭 Behavior")]

    [Export]
    public Godot.Collections.Array<DiceMana> DefaultRequiredMana { get; set; } = [];

    [Export]
    public Godot.Collections.Array<EffectType> DefaultEffects { get; set; } = [];

    public ActionCategory() {
    }

    public ActionCategory(string name, string description, Texture2D icon) {
        ValidateConstructor();

        Name = name;
        Description = description;
        Icon = icon;
    }

    public void ValidateConstructor() {
        if (!ValidationService.ValidateName(Name)) {
            throw new ArgumentException("Name cannot be null or whitespace");
        }
    }
}