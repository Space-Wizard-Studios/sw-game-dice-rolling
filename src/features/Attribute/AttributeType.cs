using Godot;
using System;

namespace DiceRolling.Attributes;

[Tool]
[GlobalClass]
public partial class AttributeType : Resource, IAttribute {
    [Export] public string Id { get; private set; } = Guid.NewGuid().ToString();
    [Export] public string? Name { get; set; }
    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }
    [Export] public Color Color { get; set; }
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
    [Export] public int MinValue { get; private set; }
    [Export] public int MaxValue { get; private set; }

    public AttributeType() { }

    public AttributeType(string name, string description, Color color, Texture2D icon, int minValue, int maxValue) {
        if (minValue >= maxValue) {
            throw new ArgumentException("MinValue must be less than MaxValue");
        }

        Name = name;
        Description = description;
        Color = color;
        Icon = icon;
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public void ValidateValues() {
        if (MinValue >= MaxValue) {
            throw new ArgumentException("MinValue must be less than MaxValue");
        }
    }
}