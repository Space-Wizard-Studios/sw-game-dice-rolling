using Godot;
using DiceRolling.Attributes;
using DiceRolling.Stores;
using System.Linq; // Add this using directive for LINQ

namespace DiceRolling.Helpers;

public static class AttributesHelper {
    public static AttributeType? GetAttributeType(AttributesStore config, string attributeName) {
        var attribute = config.Attributes.FirstOrDefault(attr => attr.Name.Equals(attributeName, System.StringComparison.OrdinalIgnoreCase));

        if (attribute == null) {
            GD.PrintErr($"Attribute '{attributeName}' not found in AttributesStore.");
        }
        return attribute;
    }
}