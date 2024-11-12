using Godot;
using System.Collections.Generic;

public class DiceIcon {
	public Texture2D Icon { get; set; }
	public string Path { get; set; }

	public DiceIcon(Texture2D icon, string path) {
		Icon = icon;
		Path = path;
	}
}

[Tool]
public partial class DiceIconsResource : Resource {
	[Export]
	public Godot.Collections.Array<DiceIconEntry> DiceIcons { get; set; } = new Godot.Collections.Array<DiceIconEntry>();

	public DiceIcon GetIconForSides(int sides) {
		foreach (var entry in DiceIcons) {
			if (entry is DiceIconEntry diceIconEntry) {
				if (diceIconEntry.Sides == sides) {
					return new DiceIcon(diceIconEntry.Icon, diceIconEntry.Path);
				}
			}
			else {
				GD.PrintErr($"Invalid entry in DiceIcons array: {entry.GetType().Name}");
			}
		}
		GD.PrintErr($"No icon found for dice with {sides} sides");
		return null;
	}
}