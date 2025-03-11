using Godot;

using DiceRolling.Attributes;

namespace DiceRolling.Stores;

[Tool]
[GlobalClass]
public partial class AttributesStore : Resource {
    [Export] public Godot.Collections.Dictionary<string, AttributeType> Attributes { get; set; } = [];
}