using Godot;
using DiceRolling.Dice;
using DiceRolling.Effects;
using System;
using DiceRolling.Common;

namespace DiceRolling.Actions;

[Tool]
[GlobalClass]
public partial class ActionCategory : IdentifiableResource, IActionCategory {
    [ExportGroup("📝 Information")]
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }

    [ExportGroup("🪵 Assets")]
    private Texture2D? _icon;
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
    [Export] public Godot.Collections.Array<DiceMana> DefaultRequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> DefaultEffects { get; set; } = [];

    public ActionCategory() {
        EnsureValidId();
    }

    public ActionCategory(string name, string description, Texture2D icon) {
        Name = name;
        Description = description;
        Icon = icon;
        EnsureValidId();
    }
}