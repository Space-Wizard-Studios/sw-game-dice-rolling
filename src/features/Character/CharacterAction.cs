using Godot;
using System;
using DiceRolling.Models.Actions.Categories;
using DiceRolling.Models.Actions.Effects;
using DiceRolling.Interfaces.Action;

namespace DiceRolling.Models.Actions;

[Tool]
[GlobalClass]
public partial class CharacterAction : Resource {
    [Export] public ActionType? Type { get; set; }
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> Effects { get; set; } = [];

    public CharacterAction() { }

    public CharacterAction(RoleAction roleAction) {
        Type = roleAction.Type;
        if (Type is not null) {
            Name = Type.Name;
            Description = Type.Description;
            RequiredMana = Type.RequiredMana;
            Effects = Type.Effects;
        }
    }

    public void Resolve(IActionContext context) {
        foreach (var effect in Effects) {
            effect.Apply(context);
        }
    }
}