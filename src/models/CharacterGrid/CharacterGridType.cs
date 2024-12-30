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

    private void OnPropertyChanged() {
        EmitSignal(nameof(Changed));
        EmitChanged();
    }

    private int _columns;
    [Export]
    public int Columns {
        get => _columns;
        set {
            _columns = value;
            OnPropertyChanged();
        }
    }

    private int _rows;
    [Export]
    public int Rows {
        get => _rows;
        set {
            _rows = value;
            OnPropertyChanged();
        }
    }

    private int _offset;
    [Export]
    public int Offset {
        get => _offset;
        set {
            _offset = value;
            OnPropertyChanged();
        }
    }

    private string _prefix = "G";
    [Export]
    public string Prefix {
        get => _prefix;
        set {
            _prefix = value;
            OnPropertyChanged();
        }
    }
}