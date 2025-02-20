using Godot;
using System;
using DiceRolling.Dice;
using DiceRolling.Targets;
using DiceRolling.Effects;

namespace DiceRolling.Actions;

[Tool]
[GlobalClass]
public partial class ActionType : Resource, IAction<IActionContext, bool> {
    [Export] public string Id { get; private set; } = Guid.NewGuid().ToString();
    [Export] public ActionCategory? Category { get; set; }
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
    [Export] public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> Effects { get; set; } = [];
    [Export] public TargetConfiguration? TargetConfiguration { get; set; }

    public ActionType() { }

    public ActionType(
        ActionCategory category,
        Godot.Collections.Array<DiceMana> requiredMana,
        Godot.Collections.Array<EffectType> effects
    ) {
        Category = category;
        RequiredMana = requiredMana;
        Effects = effects;
    }

    public bool Do(IActionContext context) {
        foreach (var effect in Effects) {
            effect.Apply(context);
        }
        return true;
    }
}