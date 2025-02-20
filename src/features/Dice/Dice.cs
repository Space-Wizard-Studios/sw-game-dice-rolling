using Godot;

namespace DiceRolling.Dice;

public class Dice<[MustBeVariant] T>(string id, string name, Godot.Collections.Array<T> manas, DiceLocation location) where T : DiceSide {
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public Godot.Collections.Array<T> Manas { get; set; } = manas;
    public int Sides => Manas.Count;
    public DiceLocation Location { get; set; } = location;
}