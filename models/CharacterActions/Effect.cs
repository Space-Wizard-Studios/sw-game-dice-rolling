using Godot;

namespace DiceRoll.Models.CharacterActions.Effects;

[Tool]
public abstract partial class Effect : Resource {
    [Export] public TargetType? TargetType { get; set; }
    [Export] public QuantityType? QuantityType { get; set; }

    [Export(PropertyHint.Range, "0,100,1")] public int NumberQuantity { get; set; }

    public abstract void Apply(IActionContext context);

    public override void _ValidateProperty(Godot.Collections.Dictionary property) {
        if (property["name"].AsStringName() == "NumberQuantity" && QuantityType?.Name != "Number") {
            var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
            property["usage"] = (int)usage;
        }
    }
}