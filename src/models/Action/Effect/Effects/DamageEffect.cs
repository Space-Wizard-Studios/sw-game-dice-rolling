using System.Linq;
using DiceRolling.Models.Characters;

namespace DiceRolling.Models.Actions.Effects;

public partial class DamageEffect : EffectType
{
    private readonly int _damage;

    public DamageEffect()
    {
    }
    public override void Apply(IActionContext context)
    {
        var healthAttribute = context.Target.Attributes.FirstOrDefault(attr => attr.Type?.Name == "Health");
        if (healthAttribute is not null)
        {
            healthAttribute.CurrentValue -= _damage;
            // TODO: can i do this?
            context.Target.EmitSignal(nameof(Character.AttributeChanged), context.Target, healthAttribute.Type!);
        }
    }

}