using Godot;
using System;
using DiceRoll.Models.CharacterActions.Effects;

namespace DiceRoll.Models.CharacterActions;

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
            if (_icon != null) {
                IconPath = _icon.ResourcePath;
            }
        }
    }

    public string? IconPath { get; private set; }

    [Export] public ActionType? ActionType { get; set; }


    [Export] public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<Effect> Effects { get; set; } = [];

    public CharacterAction() { }

    public CharacterAction(
        ActionType actionType,
        Godot.Collections.Array<DiceMana> requiredMana,
        Godot.Collections.Array<Effect> effects
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