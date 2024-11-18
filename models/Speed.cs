using Godot;

namespace DiceRoll.Models;

[GlobalClass]
public partial class Speed : Resource {
	[Export]
	public int Max { get; set; }

	[Export]
	public int Current { get; set; } = -1;

	public Speed(int max, int current = -1) {
		Max = max;
		Current = current;
	}
}