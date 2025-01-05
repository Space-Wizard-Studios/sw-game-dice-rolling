using Godot;
namespace DiceRoll.Models.Actions.Effects;

[Tool]
public abstract partial class EffectType : Resource {
    public abstract void Apply(IActionContext context);
}