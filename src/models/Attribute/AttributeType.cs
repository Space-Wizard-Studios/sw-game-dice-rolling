using Godot;

namespace DiceRoll.Models.Attributes;

[Tool]
[GlobalClass]
public partial class AttributeType : Resource {

    [Export]
    public string? Name { get; set; }

    [Export(PropertyHint.MultilineText)]
    public string? Description { get; set; }

    [Export]
    public Color Color { get; set; }

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

    [Export]
    public int MinValue { get; set; }

    [Export]
    public int MaxValue { get; set; }

    public AttributeType() { }

    public AttributeType(string name, string description, Color color, Texture2D icon) {
        Name = name;
        Description = description;
        Color = color;
        Icon = icon;
    }
}