using Godot;

public partial class DiceIconEntry : Resource {
	[Export]
	public int Sides { get; set; }

	[Export]
	public Texture2D Icon { get; set; }
}