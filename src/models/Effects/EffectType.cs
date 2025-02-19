using Godot;
using DiceRolling.Interfaces.Action;
namespace DiceRolling.Models.Actions.Effects;

[Tool]
public abstract partial class EffectType : Resource {
    public abstract void Apply(IActionContext context);
}