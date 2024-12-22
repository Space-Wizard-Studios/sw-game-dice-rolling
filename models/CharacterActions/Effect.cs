using Godot;

namespace DiceRoll.Models.CharacterActions.Effects;

[Tool]
public abstract partial class Effect : Resource {
    public abstract void Apply(IActionContext context);
}