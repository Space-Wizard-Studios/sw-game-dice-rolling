using DiceRolling.Actions;
using DiceRolling.Dice;
using DiceRolling.Effects;
using DiceRolling.Roles;
using Godot;

namespace DiceRolling.Characters;

[Tool]
public partial class CharacterAction : Resource {
    [Export] public ActionType? Type { get; set; }
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Godot.Collections.Array<DiceEnergy> RequiredEnergy { get; set; } = [];
    [Export] public Godot.Collections.Array<EffectType> Effects { get; set; } = [];

    public CharacterAction() { }

    public CharacterAction(RoleAction roleAction) {
        Type = roleAction.Type;
        if (Type is not null) {
            Name = Type.Name;
            Description = Type.Description;
            RequiredEnergy = Type.RequiredEnergy;
            Effects = Type.Effects;
        }
    }

    public void Resolve(IActionContext context) {
        foreach (var effect in Effects) {
            effect.Apply(context);
        }
    }
}