using Godot;

namespace DiceRolling.Services;

public static class ValidationService {
    public static bool ValidateMinMaxValues(int minValue, int maxValue) {
        var isValid = minValue <= maxValue;
        if (!isValid) {
            GD.PrintErr("MinValue must be less than or equal to MaxValue");
        }
        return isValid;
    }

    public static bool ValidateName(string? value) {
        var isValid = !string.IsNullOrWhiteSpace(value);
        if (!isValid) {
            GD.PrintErr("Value cannot be null or whitespace");
        }
        return isValid;
    }

    public static bool ValidateId(string? value) {
        var isValid = !string.IsNullOrEmpty(value);
        if (!isValid) {
            GD.PrintErr("Value cannot be null or empty");
        }
        return isValid;
    }
}