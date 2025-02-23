using GdUnit4;
using static GdUnit4.Assertions;
using DiceRolling.Services;

namespace DiceRolling.Tests.Services;

[TestSuite]
public class ValidationServiceTests {
    [TestCase]
    public static void ValidateValues_ShouldReturnFalse_WhenMinValueIsGreaterThanMaxValue() {
        // Arrange
        var minValue = 10;
        var maxValue = 1;

        // Act
        var isValid = ValidationService.Instance.ValidateMinMaxValues(minValue, maxValue);

        // Assert
        AssertBool(isValid).IsFalse();
    }

    [TestCase]
    public static void ValidateName_ShouldReturnFalse_WhenSetToNullOrEmpty() {
        // Act & Assert
        AssertBool(ValidationService.Instance.ValidateName("")).IsFalse();
        AssertBool(ValidationService.Instance.ValidateName(null)).IsFalse();
    }
}