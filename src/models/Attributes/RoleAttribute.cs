using Godot;

namespace DiceRoll.Models.Attributes;

[Tool]
[GlobalClass]
public partial class RoleAttribute : Resource {
    [Export] public AttributeType? Type { get; set; }
    [Export] public string? Name { get; set; }
    [Export] public int BaseValue { get; set; }

    public RoleAttribute() { }

    public RoleAttribute(AttributeType type, string name, int baseValue) {
        Type = type;
        Name = name;
        BaseValue = baseValue;
    }
}