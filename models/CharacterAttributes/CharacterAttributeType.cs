using Godot;
namespace DiceRoll.Models;

[Tool]
public partial class CharacterAttributeType : Resource {

	[Export]
	public string? Name { get; set; }

	[Export(PropertyHint.MultilineText)]
	public string? Description { get; set; }

	[Export]
	public Color Color { get; set; }

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

	[Export]
	public int MinValue { get; set; }

	[Export]
	public int MaxValue { get; set; }

	public string? IconPath { get; private set; }

	public CharacterAttributeType() { }

	public CharacterAttributeType(string name, string description, Color color, Texture2D icon) {
		Name = name;
		Description = description;
		Color = color;
		Icon = icon;
	}
}