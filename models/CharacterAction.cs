using Godot;
namespace DiceRoll.Models;

public enum TargetCategory {
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

[Tool]
public partial class CharacterAction : Resource {
	[Export]
	public string Name { get; set; }

	[Export]
	public string Description { get; set; }

	private Texture2D _icon;

	[Export]
	public Texture2D Icon {
		get => _icon;
		set {
			_icon = value;
			if (_icon != null) {
				IconPath = _icon.ResourcePath;
			}
		}
	}

	public string IconPath { get; private set; }

	[Export]
	public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } =
		new Godot.Collections.Array<DiceMana>();

	[ExportCategory("Target Options")]

	[Export]
	public TargetCategory TargetCategory { get; set; }

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

	public CharacterAction() { }

	public CharacterAction(
		string name,
		string description,
		Godot.Collections.Array<DiceMana> requiredMana
	) {
		Name = name;
		Description = description;
		RequiredMana = requiredMana;
	}

	public override void _ValidateProperty(Godot.Collections.Dictionary property) {
		if (property["name"].AsStringName() == "NumberQuantity" && TypeOfQuantity != QuantityType.Number) {
			var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
			property["usage"] = (int)usage;
		}
	}
}