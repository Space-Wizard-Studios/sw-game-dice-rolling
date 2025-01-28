using Godot;

namespace DiceRolling.Models.Attributes;

[Tool]
public partial class AttributesConfig : Resource
{
    [Export] public Godot.Collections.Dictionary<string, AttributeType> Attributes { get; set; } = [];
}