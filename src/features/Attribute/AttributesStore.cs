using Godot;

namespace DiceRolling.Attributes;

[Tool]
public partial class AttributesStore : Resource {
    [Export] public Godot.Collections.Dictionary<string, AttributeType> Attributes { get; set; } = [];
}