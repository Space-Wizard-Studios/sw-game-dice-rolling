using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using DiceRolling.Characters;
using DiceRolling.Roles;
using DiceRolling.Attributes;
using DiceRolling.Helpers;
using DiceRolling.Actions;

namespace DiceRolling.Tests.Characters;

[TestSuite]
public class CharacterTypeTests {
    private AttributesConfig? _attributesConfig;

    [Before]
    public void SetUp() {
        _attributesConfig = GD.Load<AttributesConfig>("res://features/Attribute/AttributesConfig.tres");
    }

    [TestCase]
    public void Constructor_ShouldInitializeAttributesAndActions() {
        // Arrange
        if (_attributesConfig == null) {
            AssertThat(false).IsTrue();
            GD.PrintErr("AttributesConfig is null");
            return;
        }

        // Create a valid ActionType first
        var actionType = new ActionType {
            Name = "Attack",
            Description = "Basic attack",
        };

        // Create the role with complete initialization
        var role = new RoleType {
            Name = "Fighter", // Add name for the role
            RoleAttributes = [
                new() {
                    Type = AttributesHelper.GetAttributeType(_attributesConfig, "Health")!,
                    BaseValue = 10
                }
            ],
            RoleActions = [
                new(actionType)
            ]
        };

        // Initialize character service
        var characterService = new CharacterService();

        // Ensure all objects are not null
        if (role == null || characterService == null) {
            AssertThat(false).IsTrue();
            GD.PrintErr("Role or CharacterService is null");
            return;
        }

        // Act
        var character = new CharacterType("Hero", role, characterService);

        // Assert
        AssertThat(character.Name).IsEqual("Hero");
        AssertThat(character.Attributes.Count).IsEqual(1);
        AssertThat(character.Attributes[0].Type?.Name).IsEqual("Health");
        AssertThat(character.Attributes[0].BaseValue).IsEqual(10);
        AssertThat(character.Actions.Count).IsEqual(1);
        AssertThat(character.Actions[0].Type?.Name).IsEqual("Attack");
    }
}