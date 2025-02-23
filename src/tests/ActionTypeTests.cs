using System;
using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using DiceRolling.Actions;
using DiceRolling.Dice;
using DiceRolling.Effects;
using DiceRolling.Targets;

namespace DiceRolling.Tests.Actions;

[TestSuite]
public class ActionTypeTests {
    [TestCase]
    public static void Constructor_ShouldInitializeProperties() {
        // Arrange
        var category = new ActionCategory();
        var RequiredEnergy = new Godot.Collections.Array<DiceEnergy> { new DiceEnergy("EnergyName", "EnergyDescription", new Color(1, 1, 1), new Color(0, 0, 0), new Texture2D()) };
        var effects = new Godot.Collections.Array<EffectType> { new DamageEffect() };
        var name = "Fireball";
        var description = "A powerful fire attack.";
        var icon = new Texture2D();
        var targetConfiguration = new TargetConfiguration();

        // Act
        var action = new ActionType(category, RequiredEnergy, effects, name, description, icon, targetConfiguration);

        // Assert
        AssertObject(action.Category).IsEqual(category);
        AssertObject(action.RequiredEnergy).IsEqual(RequiredEnergy);
        AssertObject(action.Effects).IsEqual(effects);
        AssertString(action.Name).IsEqual(name);
        AssertString(action.Description).IsEqual(description);
        AssertObject(action.Icon).IsEqual(icon);
        AssertObject(action.TargetConfiguration).IsEqual(targetConfiguration);
    }

    [TestCase]
    public static void IsValid_ShouldReturnTrue_WhenAllPropertiesAreValid() {
        // Arrange
        var category = new ActionCategory();
        var RequiredEnergy = new Godot.Collections.Array<DiceEnergy> { new DiceEnergy("EnergyName", "EnergyDescription", new Color(1, 1, 1), new Color(0, 0, 0), new Texture2D()) };
        var effects = new Godot.Collections.Array<EffectType> { new DamageEffect() };
        var targetConfiguration = new TargetConfiguration();
        var action = new ActionType(category, RequiredEnergy, effects, "Fireball", "A powerful fire attack.", new Texture2D(), targetConfiguration);

        // Act
        var isValid = action.IsValid();

        // Assert
        AssertBool(isValid).IsTrue();
    }

}