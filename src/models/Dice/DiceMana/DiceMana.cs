using Godot;
namespace DiceRoll.Models;

[Tool]
[GlobalClass]
public partial class DiceMana : Resource {
    [Export]
    public string? Name { get; set; }

    [Export(PropertyHint.MultilineText)]
    public string? Description { get; set; }
    [Export]
    public Color BackgroundColor { get; set; } = new Color(0, 0, 0);
    [Export]
    public Color MainColor { get; set; } = new Color(1, 1, 1);

    private Texture2D? _icon;

    [Export]
    public Texture2D? Icon {
        get => _icon;
        set {
            _icon = value;
            if (_icon is not null) {
                IconPath = _icon.ResourcePath;
            }
        }
    }

    public string? IconPath { get; private set; }

    public DiceMana() { }

    public DiceMana(string name, string description, Color backgroundColor, Color mainColor) {
        Name = name;
        Description = description;
        BackgroundColor = backgroundColor;
        MainColor = mainColor;
    }
}