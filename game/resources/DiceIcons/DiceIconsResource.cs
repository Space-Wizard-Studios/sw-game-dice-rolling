using Godot;
using System.Collections.Generic;

[Tool]
public partial class DiceIconsResource : Resource {
	[Export]
	public Godot.Collections.Array<DiceIconEntry> DiceIcons { get; set; } = new Godot.Collections.Array<DiceIconEntry>();

	public Texture2D GetIconForSides(int sides) {
		foreach (var entry in DiceIcons) {
			if (entry is DiceIconEntry diceIconEntry) {
				if (diceIconEntry.Sides == sides) {
					return diceIconEntry.Icon;
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