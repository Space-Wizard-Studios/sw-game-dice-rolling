using System;
using Godot;

namespace DiceRolling.Dice;

public class Dice<[MustBeVariant] T> where T : DiceSide {
    public string Id { get; set; }
    public string Name { get; set; }
    public Godot.Collections.Array<T> Manas { get; set; }
    public int Sides => Manas.Count;
    public DiceLocation Location { get; set; }

    public Dice(string id, string name, Godot.Collections.Array<T> manas, DiceLocation location) {
        Id = id;
        Name = name;
        Manas = manas;
        Location = location;
    }
}

public enum DiceLocation {
    Inventory,
    Character,
    None
}

public static class DiceFactory {
    public static Dice<DiceSide> CreateD4(DiceManaResources diceManaResources) => CreateDice(4, diceManaResources);
    public static Dice<DiceSide> CreateD6(DiceManaResources diceManaResources) => CreateDice(6, diceManaResources);
    public static Dice<DiceSide> CreateD8(DiceManaResources diceManaResources) => CreateDice(8, diceManaResources);
    public static Dice<DiceSide> CreateD10(DiceManaResources diceManaResources) => CreateDice(10, diceManaResources);
    public static Dice<DiceSide> CreateD12(DiceManaResources diceManaResources) => CreateDice(12, diceManaResources);
    public static Dice<DiceSide> CreateD20(DiceManaResources diceManaResources) => CreateDice(20, diceManaResources);
    public static Dice<DiceSide> CreateD100(DiceManaResources diceManaResources) => CreateDice(100, diceManaResources);

    private static Dice<DiceSide> CreateDice(int sides, DiceManaResources diceManaResources) {
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
        return new Dice<DiceSide>(Guid.NewGuid().ToString(), $"D{sides}", manas, DiceLocation.None);
    }
}