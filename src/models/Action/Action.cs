using Godot;
using System;
using DiceRoll.Models.Actions.Effects;
using DiceRoll.Models.Actions.Targets;

namespace DiceRoll.Models.Actions;

[Tool]
[GlobalClass]
public partial class Action : Resource, IAction<IActionContext, bool> {
    [Export] public string Id { get; private set; } = Guid.NewGuid().ToString();
    [Export] public ActionType? ActionType { get; set; }
    [Export] public ActionSource? Source { get; set; }
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
    [Export] TargetConfiguration? TargetConfiguration { get; set; }

    public Action() { }

    public Action(
        ActionType actionType,
        ActionSource source,
        Godot.Collections.Array<DiceMana> requiredMana,
        Godot.Collections.Array<EffectType> effects
    ) {
        ActionType = actionType;
        Source = source;
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