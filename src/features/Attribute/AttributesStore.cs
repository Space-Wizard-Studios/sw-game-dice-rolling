using Godot;

namespace DiceRolling.Attributes;

[Tool]
[GlobalClass]
public partial class AttributesStore : Resource {
    [Export] public Godot.Collections.Dictionary<string, AttributeType> Attributes { get; set; } = [];
}