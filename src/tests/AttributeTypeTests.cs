using System;
using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using DiceRolling.Attributes;

namespace DiceRolling.Tests.Attributes;

[TestSuite]
public class AttributeTypeTests {
    [TestCase]
    public static void Constructor_ShouldInitializeProperties() {
        // Arrange
        var name = "Strength";
        var description = "Determines physical power.";
        var color = new Color(1, 0, 0);
        var icon = new Texture2D();
        var minValue = 1;
        var maxValue = 10;

        // Act
        var attribute = new AttributeType(name, description, color, icon, minValue, maxValue);

        // Assert
        AssertString(attribute.Name).IsEqual(name);
        AssertString(attribute.Description).IsEqual(description);
        AssertObject(attribute.Color).IsEqual(color);
        AssertObject(attribute.Icon).IsEqual(icon);
        AssertInt(attribute.MinValue).IsEqual(minValue);
        AssertInt(attribute.MaxValue).IsEqual(maxValue);
    }

    [TestCase]
    public static void ValidateValues_ShouldThrowException_WhenMinValueIsGreaterThanOrEqualToMaxValue() {
        // Act & Assert
        AssertThrown(() => new AttributeType(
            "Strength",
            "Determines physical power.",
            new Color(1, 0, 0),
            new Texture2D(),
            10, // minValue
            1   // maxValue
        )).IsInstanceOf<ArgumentException>();
    }

    [TestCase]
    public static void Name_ShouldThrowException_WhenSetToNullOrEmpty() {
        // Arrange
        var attribute = new AttributeType();

        // Act & Assert
        AssertThrown(() => attribute.Name = "").IsInstanceOf<ArgumentException>();
        AssertThrown(() => attribute.Name = null).IsInstanceOf<ArgumentException>();
    }
}