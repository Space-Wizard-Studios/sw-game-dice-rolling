using Godot;
using System;
using DiceRoll.Models.Actions.Categories;
using DiceRoll.Models.Actions.Effects;

namespace DiceRoll.Models.Actions;

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
            GD.Print("Initializing CharacterAction with Name: ", Name);
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