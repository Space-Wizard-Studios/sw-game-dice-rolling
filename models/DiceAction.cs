using Godot;

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
	[Export(PropertyHint.Enum, "Enemy,Ally,Self,Any,Nothing")]
	public TargetCategory Category { get; set; }

	private QuantityCategory _quantity = QuantityCategory.None;
	[Export(PropertyHint.Enum, "None,All,Number")]
	public QuantityCategory Quantity {
		get => _quantity;
		set {
			if (_quantity != value) {
				_quantity = value;
				NotifyPropertyListChanged();
			}
		}
	}

	public int NumberQuantity { get; set; } = 1;

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

	public override Godot.Collections.Array<Godot.Collections.Dictionary> _GetPropertyList() {
		var propertyList = base._GetPropertyList();
		bool isQuantityVisible = Quantity == QuantityCategory.Number;

		if (isQuantityVisible) {
			var numberQuantityProperty = new Godot.Collections.Dictionary {
				{ "name", "NumberQuantity" },
				{ "type", (int)Variant.Type.Int },
				{ "usage", (int)PropertyUsageFlags.Default }
			};
			propertyList.Add(numberQuantityProperty);
		}

		return propertyList;
	}
}