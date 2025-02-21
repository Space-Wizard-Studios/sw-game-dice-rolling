using Godot;
using DiceRolling.Dice;
using DiceRolling.Effects;
using System;

namespace DiceRolling.Actions;

[Tool]
[GlobalClass]
public partial class ActionCategory : Resource, IActionCategory {
    [Export] public string Id { get; private set; } = Guid.NewGuid().ToString();
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
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
    [Export] public Godot.Collections.Array<DiceMana> DefaultRequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> DefaultEffects { get; set; } = [];

    public ActionCategory() { }

    public ActionCategory(string name, string description, Texture2D icon) {
        Name = name;
        Description = description;
        Icon = icon;
    }
}