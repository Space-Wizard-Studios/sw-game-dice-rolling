using System.Linq;

namespace DiceRoll.Models.CharacterActions.Effects;

public partial class DamageEffect(int damage) : Effect {
    private readonly int _damage = damage;

    public override void Apply(IActionContext context) {
        var healthAttribute = context.Target.Attributes.FirstOrDefault(attr => attr.Type?.Name == "Health");
        if (healthAttribute != null) {
            healthAttribute.CurrentValue -= _damage;
            // TODO: can i do this?
            context.Target.EmitSignal(nameof(Character.AttributeChanged), context.Target, healthAttribute.Type!);
        }
    }
}