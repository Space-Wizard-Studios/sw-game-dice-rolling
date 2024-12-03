using Godot;
namespace DiceRoll.Models;

public partial class DiceIcon : Resource {
	[Export]
	public int Sides { get; set; }

	private Texture2D? _icon;

	[Export]
	public Texture2D? Icon {
		get => _icon;
		set {
			_icon = value;
			if (_icon != null) {
				Path = _icon.ResourcePath;
			}
		}
	}

	public string? Path { get; private set; }
}