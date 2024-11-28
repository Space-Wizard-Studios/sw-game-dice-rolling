using Godot;
using System;
using System.Linq;

namespace DiceRoll.Models;

[Tool]
public partial class AttributesResources : Resource {
	[Export]
	public Godot.Collections.Array<Attribute> Attributes { get; set; } = new Godot.Collections.Array<Attribute>();

	public AttributesResources() { }

	public override void _ValidateProperty(Godot.Collections.Dictionary property) {
		if (property["name"].AsStringName() == "Attributes") {
			ValidateAttributes();
		}
	}

	private void ValidateAttributes() {
		// Check if all AttributeType values are represented in the Attributes array
		foreach (AttributeType type in Enum.GetValues(typeof(AttributeType))) {
			if (!Attributes.Any(attr => attr.Type == type)) {
				GD.PrintErr($"Missing attribute of type: {type}");
			}
		}
	}
}