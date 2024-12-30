using Godot;

namespace DiceRoll.Models.CharacterGrid;

[Tool]
[GlobalClass]
public partial class CharacterGridType : Resource {
    [Signal] public delegate void ChangedEventHandler();

    public CharacterGridType() { }

    public CharacterGridType(int columns, int rows, int offset, string prefix) {
        Columns = columns;
        Rows = rows;
        Offset = offset;
        Prefix = prefix;
    }
    [Export] public int Columns { get; set; } = 0;

    [Export] public int Rows { get; set; } = 0;

    [Export] public int Offset { get; set; } = 0;

    [Export] public string Prefix { get; set; } = "G";
}