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

    public static bool IsNullOrEmpty(string? value) {
        return string.IsNullOrEmpty(value);
    }
}