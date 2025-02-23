using Godot;
using System;

using DiceRolling.Common;
using DiceRolling.Services;

namespace DiceRolling.Dice;

[Tool]
[GlobalClass]
public partial class DiceType : IdentifiableResource, IDice<DiceSide> {
    private string _name = "Dice_" + Guid.NewGuid().ToString("N");
    private Godot.Collections.Array<DiceSide> _sides = [];
    private int _sideCount;

    [Export]
    public string Name {
        get => _name;
        set {
            if (ValidationService.ValidateName(value)) {
                _name = value;
                EmitChanged();
            }
        }
    }

    [Export]
    public int SideCount {
        get => _sideCount;
        private set {
            _sideCount = value;
            EmitChanged();
        }
    }

    [Export]
    public Godot.Collections.Array<DiceSide> Sides {
        get => _sides;
        set {
            _sides = value;
            UpdateSideCount();
            EmitChanged();
        }
    }

    [Export]
    public DiceLocation Location { get; set; }

    public DiceType() {
        Location = new DiceLocation(DiceLocationCategory.None);
        UpdateSideCount();
    }

    public DiceType(string id, string name, Godot.Collections.Array<DiceSide> sides, DiceLocation location) : base(id) {
        Name = name;
        Sides = sides;
        Location = location;
        UpdateSideCount();
    }

    private void UpdateSideCount() {
        SideCount = Sides.Count;
    }

    public override void _ValidateProperty(Godot.Collections.Dictionary property) {
        if (property["name"].AsStringName() == "SideCount") {
            var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
            property["usage"] = (int)usage;
        }
        base._ValidateProperty(property);
    }
}