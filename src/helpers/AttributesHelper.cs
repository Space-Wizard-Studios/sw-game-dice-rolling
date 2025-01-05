using Godot;
using DiceRoll.Models.Attributes;

namespace DiceRoll.Helpers;

public static class AttributesHelper {
    public static AttributeType? GetAttributeType(AttributesConfig config, string attributeName) {
        if (config.Attributes.TryGetValue(attributeName, out AttributeType? value)) {
            return value;
        }
        GD.PrintErr($"Attribute '{attributeName}' not found in AttributesConfig.");
        return null;
    }
}