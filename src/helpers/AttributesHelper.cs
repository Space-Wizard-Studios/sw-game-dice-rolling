using Godot;
using DiceRoll.Models;

namespace DiceRoll.Helpers;

public static class AttributesHelper {
    public static AttributeType? GetAttributeType(AttributesConfig config, string attributeName) {
        if (config.Attributes.ContainsKey(attributeName)) {
            return config.Attributes[attributeName];
        }
        GD.PrintErr($"Attribute '{attributeName}' not found in AttributesConfig.");
        return null;
    }
}