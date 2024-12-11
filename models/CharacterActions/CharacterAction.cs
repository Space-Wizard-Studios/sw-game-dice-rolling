using Godot;
using System;
namespace DiceRoll.Models;

public enum TargetType {
    Enemy,
    Ally,
    Self,
    Any,
    Nothing,
}

public enum QuantityType {
    None,
    All,
    Number
}

public enum ActionType {
    Attack,
    Heal,
}

[Tool]
public partial class CharacterAction : Resource {
    [Export]
    public string? Name { get; set; }

    [Export]
    public string? Description { get; set; }

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

    [Export]
    public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = new Godot.Collections.Array<DiceMana>();

    [ExportCategory("Target Options")]

    [Export]
    public TargetType TargetType { get; set; }

    private QuantityType _typeOfQuantity = QuantityType.None;
    [Export]
    public QuantityType TypeOfQuantity {
        get => _typeOfQuantity;
        set {
            if (_typeOfQuantity != value) {
                _typeOfQuantity = value;
                NotifyPropertyListChanged();
            }
        }
    }

    [Export(PropertyHint.Range, "0,100,1")]
    public int NumberQuantity { get; set; }

    [Export]
    public ActionType ActionType { get; set; }

    public CharacterAction() { }

    public CharacterAction(
        string name,
        string description,
        Godot.Collections.Array<DiceMana> requiredMana,
        ActionType actionType
    ) {
        Name = name;
        Description = description;
        RequiredMana = requiredMana;
        ActionType = actionType;
    }

    public override void _ValidateProperty(Godot.Collections.Dictionary property) {
        if (property["name"].AsStringName() == "NumberQuantity" && TypeOfQuantity != QuantityType.Number) {
            var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
            property["usage"] = (int)usage;
        }
    }
}

public static class ActionFactory {
    public static IAction<IActionContext, AttackResult> CreateAction(ActionType actionType) {
        return actionType switch {
            ActionType.Attack => (IAction<IActionContext, AttackResult>)new Attack(),
            // Add other cases for different action types
            _ => throw new ArgumentException($"Invalid action type: {actionType}")
        };
    }
}