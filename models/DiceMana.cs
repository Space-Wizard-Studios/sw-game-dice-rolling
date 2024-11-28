using Godot;
namespace DiceRoll.Models;

public enum ManaType {
	Empty,
	Colorless,
	Red,
	Blue,
	Green,
	Yellow,
	Purple
}

[Tool]
public partial class DiceMana : Resource {
	[Export]
	public ManaType ManaType { get; set; }

	[Export]
	public string Name { get; set; }

	[Export(PropertyHint.MultilineText)]
	public string Description { get; set; }
	[Export]
	public Color BackgroundColor { get; set; } = new Color(0, 0, 0);
	[Export]
	public Color MainColor { get; set; } = new Color(1, 1, 1);

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

	public DiceMana() { }

	public DiceMana(ManaType manaType, string name, string description, Color backgroundColor, Color mainColor) {
		ManaType = manaType;
		Name = name;
		Description = description;
		BackgroundColor = backgroundColor;
		MainColor = mainColor;
	}
}