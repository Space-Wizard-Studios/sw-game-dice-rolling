using Godot;
namespace DiceRoll.Models;

[Tool]
public partial class DiceMana : Resource {
	[Export]
	public string Name { get; set; }
	[Export]
	public string Abbreviation { get; set; }
	[Export]
	public string Description { get; set; }
	[Export]
	public Color BackgroundColor { get; set; } = new Color(0, 0, 0);
	[Export]
	public Color TextColor { get; set; } = new Color(1, 1, 1);

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

	public DiceMana(string name, string abbreviation, string description, Color backgroundColor, Color textColor) {
		Name = name;
		Abbreviation = abbreviation;
		Description = description;
		BackgroundColor = backgroundColor;
		TextColor = textColor;
	}
}