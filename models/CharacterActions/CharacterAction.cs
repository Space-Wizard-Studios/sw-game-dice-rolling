using Godot;
using System;
using DiceRoll.Models.CharacterActions.Effects;

namespace DiceRoll.Models.CharacterActions;

[Tool]
public partial class CharacterAction : Resource {

    [Export] public string? Name { get; set; }

    [Export(PropertyHint.MultilineText)] public string? Description { get; set; }

    private Texture2D? _icon;

    [Export]
    public Texture2D? Icon {
        get => _icon;
        set {
            _icon = value;
            if (_icon != null) {
                IconPath = _icon.ResourcePath;
            }
        }
    }

    public string? IconPath { get; private set; }

    [Export] public ActionType? ActionType { get; set; }
    [Export] public TargetType? TargetType { get; set; }

    private QuantityType? _quantityType;
    [Export]
    public QuantityType? QuantityType {
        get => _quantityType;
        set {
            if (_quantityType != value) {
                _quantityType = value;
                NotifyPropertyListChanged();
            }
        }
    }

    [Export(PropertyHint.Range, "0,100,1")] public int NumberQuantity { get; set; }
    [Export] public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = [];
    [Export] public Godot.Collections.Array<Effect> Effects { get; set; } = [];

    public CharacterAction() { }

    public CharacterAction(
        ActionType actionType,
        TargetType targetType,
        QuantityType typeOfQuantity,
        int numberQuantity,
        Godot.Collections.Array<DiceMana> requiredMana,
        Godot.Collections.Array<Effect> effects
    ) {
        ActionType = actionType;
        TargetType = targetType;
        QuantityType = typeOfQuantity;
        NumberQuantity = numberQuantity;
        RequiredMana = requiredMana;
        Effects = effects;
    }

    public void Resolve(IActionContext context) {
        foreach (var effect in Effects) {
            effect.Apply(context);
        }
    }

    public override void _ValidateProperty(Godot.Collections.Dictionary property) {
        if (property["name"].AsStringName() == "NumberQuantity" && QuantityType?.Name != "Number") {
            var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
            property["usage"] = (int)usage;
        }
    }
}