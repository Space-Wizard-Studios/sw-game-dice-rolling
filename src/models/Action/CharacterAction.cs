using Godot;
using System;
using DiceRoll.Models.Actions.Effects;

namespace DiceRoll.Models.Actions;

[Tool]
public partial class CharacterAction : Resource {
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
    [Export] public ActionType? ActionType { get; set; }
    [Export] public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> Effects { get; set; } = [];

    public CharacterAction() { }

    public CharacterAction(
        ActionType actionType,
        Godot.Collections.Array<DiceMana> requiredMana,
        Godot.Collections.Array<EffectType> effects
    ) {
        ActionType = actionType;
        RequiredMana = requiredMana;
        Effects = effects;
    }

    public void Resolve(IActionContext context) {
        foreach (var effect in Effects) {
            effect.Apply(context);
        }
    }
}