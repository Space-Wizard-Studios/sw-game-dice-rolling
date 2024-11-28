using Godot;
namespace DiceRoll.Models;

[GlobalClass]
public partial class Health : Resource {
	[Export]
	public int Max { get; private set; }

	[Export]
	public int Current { get; set; } = -1;

	public Health() {
	}

	public Health(int max, int current = -1) {
		Max = max;
		Current = current;
	}

	public void SetMax(int max) {
		Max = max;
	}
}