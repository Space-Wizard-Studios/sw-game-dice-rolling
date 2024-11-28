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

		// Additional validation for each attribute
		foreach (var attribute in Attributes) {
			if (attribute is Attribute attr) {
				// Perform validation based on AttributeType
				switch (attr.Type) {
					case AttributeType.Health:
						// Validate Health attribute
						break;
					case AttributeType.Armor:
						// Validate Armor attribute
						break;
					case AttributeType.Speed:
						// Validate Speed attribute
						break;
					// Add cases for other AttributeTypes as needed
					default:
						GD.PrintErr($"Unknown attribute type: {attr.Type}");
						break;
				}
			}
			else {
				GD.PrintErr($"Invalid attribute in Attributes array: {attribute.GetType().Name}");
			}
		}
	}
}