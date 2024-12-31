using System.Linq;

namespace DiceRoll.Models.CharacterActions.Effects;

public partial class DamageEffect : Effect {
    private readonly int _damage;

    public DamageEffect() {
    }

    public DamageEffect(TargetType targetType, QuantityType quantityType, int numberQuantity) {
        TargetType = targetType;
        QuantityType = quantityType;
        NumberQuantity = numberQuantity;
    }

    public override void Apply(IActionContext context) {
        var healthAttribute = context.Target.Attributes.FirstOrDefault(attr => attr.Type?.Name == "Health");
        if (healthAttribute is not null) {
            healthAttribute.CurrentValue -= _damage;
            // TODO: can i do this?
            context.Target.EmitSignal(nameof(Character.AttributeChanged), context.Target, healthAttribute.Type!);
        }
    }

}