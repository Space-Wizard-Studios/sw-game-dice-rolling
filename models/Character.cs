using Godot;

namespace DiceRoll.Models;

public partial class Character : Resource {
	[Export]
	public string Id { get; set; }

	[Export]
	public string Name { get; set; }

	[Export]
	public Role Role { get; set; }

	[Export]
	public int DiceCapacity { get; set; }

	[Export]
	public Health Health { get; set; }

	// [Export]
	// public Speed Speed { get; set; }

	[Export]
	public Godot.Collections.Array<CommonAction> CommonActions { get; set; } = new Godot.Collections.Array<CommonAction>();

	[Export]
	public Texture Portrait { get; set; }

	[Export]
	public SpriteFrames CharacterSprite { get; set; }

	[Export]
	public float SpriteOffsetX { get; set; }

	[Export]
	public float SpriteOffsetY { get; set; }

	[Export]
	public bool ShowShadow { get; set; }

	[Export]
	public SpriteFrames ShadowSprite { get; set; }
}