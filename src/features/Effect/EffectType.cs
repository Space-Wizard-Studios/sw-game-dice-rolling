using Godot;
using DiceRolling.Interfaces.Action;
using DiceRolling.Interfaces.Effects;

namespace DiceRolling.Models.Actions.Effects;

[Tool]
public abstract partial class EffectType : Resource, IEffect {
    public abstract void Apply(IActionContext context);
}