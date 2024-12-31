using Godot;
using DiceRoll.Stores;

namespace DiceRoll.Models.CharacterGrid;

[Tool]
[GlobalClass]
public partial class CharacterGridType : Resource {
    [Export] public CharacterStore? CharacterStore { get; set; }
    [Signal] public delegate void ChangedEventHandler();
    [Export] public int Columns { get; set; } = 0;
    [Export] public int Rows { get; set; } = 0;
    [Export] public int Offset { get; set; } = 0;
    [Export] public string Prefix { get; set; } = "G";

    public CharacterGridType() { }

    public CharacterGridType(int columns, int rows, int offset, string prefix) {
        Columns = columns;
        Rows = rows;
        Offset = offset;
        Prefix = prefix;
    }
}