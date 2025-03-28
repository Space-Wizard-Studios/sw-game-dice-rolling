using Godot;
using DiceRolling.Attributes;
using DiceRolling.Stores;

namespace DiceRolling.Helpers;

public static class AttributesHelper {
    public static AttributeType? GetAttributeType(AttributesStore config, string attributeName) {
        if (config.Attributes.TryGetValue(attributeName, out AttributeType? value)) {
            return value;
        }
        GD.PrintErr($"Attribute '{attributeName}' not found in AttributesStore.");
        return null;
    }
}