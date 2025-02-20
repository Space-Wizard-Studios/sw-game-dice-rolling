using System;
namespace DiceRolling.Dice;

public static class DiceFactory {
    public static Dice<DiceSide> CreateD4(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(4, diceManaResources, locationCategory, characterId);
    public static Dice<DiceSide> CreateD6(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(6, diceManaResources, locationCategory, characterId);
    public static Dice<DiceSide> CreateD8(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(8, diceManaResources, locationCategory, characterId);
    public static Dice<DiceSide> CreateD10(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(10, diceManaResources, locationCategory, characterId);
    public static Dice<DiceSide> CreateD12(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(12, diceManaResources, locationCategory, characterId);
    public static Dice<DiceSide> CreateD20(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(20, diceManaResources, locationCategory, characterId);
    public static Dice<DiceSide> CreateD100(DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) => CreateDice(100, diceManaResources, locationCategory, characterId);

    private static Dice<DiceSide> CreateDice(int sides, DiceManaResources diceManaResources, DiceLocationCategory locationCategory, string? characterId = null) {
        var manas = new Godot.Collections.Array<DiceSide>();
        var diceManas = diceManaResources.DiceManas;
        for (int i = 0; i < sides; i++) {
            var mana = diceManas[i % diceManas.Count];
            manas.Add(new DiceSide(
                mana.Name ?? "Unknown",
                mana.Description ?? "Unknown",
                mana.BackgroundColor,
                mana.MainColor
            ));
        }
        var location = new DiceLocation(locationCategory, characterId);
        return new Dice<DiceSide>(Guid.NewGuid().ToString(), $"D{sides}", manas, location);
    }
}