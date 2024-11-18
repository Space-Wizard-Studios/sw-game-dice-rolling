using Godot;

namespace DiceRoll.Models;

public enum TargetCategory {
	Enemy,
	Ally,
	Self,
	Any,
	Nothing,
}

public enum QuantityCategory {
	None,
	All,
	Number
}

[Tool]
public partial class DiceAction : Resource {
	[Export]
	public string Name { get; set; }

	[Export]
	public string Description { get; set; }

	[Export]
	public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } =
		new Godot.Collections.Array<DiceMana>();

	[ExportCategory("Target Options")]

	[Export]
	public TargetCategory TargetCategory { get; set; }

	private QuantityCategory _quantityCategory = QuantityCategory.None;
	[Export]
	public QuantityCategory QuantityCategory {
		get => _quantityCategory;
		set {
			if (_quantityCategory != value) {
				_quantityCategory = value;
				NotifyPropertyListChanged();
			}
		}
	}

	[Export(PropertyHint.Range, "0,100,1")]
	public int NumberQuantity { get; set; }

	public DiceAction() { }

	public DiceAction(
		string name,
		string description,
		Godot.Collections.Array<DiceMana> requiredMana
	) {
		Name = name;
		Description = description;
		RequiredMana = requiredMana;
	}

	public override void _ValidateProperty(Godot.Collections.Dictionary property) {
		if (property["name"].AsStringName() == "NumberQuantity" && QuantityCategory != QuantityCategory.Number) {
			var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
			property["usage"] = (int)usage;
		}
	}
}