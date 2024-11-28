using Godot;
namespace DiceRoll.Models;

public enum AttributeType {
	Health,
	Armor,
	Speed,
	CriticalChance,
	LifeSteal,
	AttackDamage,
	AbilityPower
}

[Tool]
public partial class Attribute : Resource {
	[Export]
	public string Name { get; set; }

	[Export]
	public string Description { get; set; }

	[Export]
	public Color Color { get; set; }

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
	public int MaxValue { get; set; }

	private int _currentValue;
	[Export]
	public int CurrentValue {
		get => _currentValue;
		set {
			_currentValue = Mathf.Clamp(value, 0, MaxValue);
		}
	}

	public Attribute() { }

	public Attribute(string name, string description, Color color, Texture2D icon, int maxValue, int currentValue) {
		Name = name;
		Description = description;
		Color = color;
		Icon = icon;
		MaxValue = maxValue;
		CurrentValue = currentValue;
	}
}