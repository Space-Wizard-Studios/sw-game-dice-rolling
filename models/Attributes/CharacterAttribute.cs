using Godot;
namespace DiceRoll.Models;

[Tool]
[GlobalClass]
public partial class CharacterAttribute : Resource {
    [Export]
    public AttributeType? Type { get; set; }

    public int MaxValue { get; set; }
    public int CurrentValue { get; set; }
    public int BaseValue { get; set; }

    public CharacterAttribute(RoleAttribute roleAttribute) {
        Type = roleAttribute.Type;
        BaseValue = roleAttribute.BaseValue;

        MaxValue = BaseValue;
        CurrentValue = BaseValue;
    }
}