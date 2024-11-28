using Godot;
namespace DiceRoll.Models;

[Tool]
[GlobalClass]
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
	public AttributesResources CharacterAttributes { get; set; }

	[Export]
	public Texture Portrait { get; set; }

	[Export]
	public SpriteFrames CharacterSprite { get; set; }

	private float _spritePositionX;
	[Export]
	public float SpritePositionX {
		get => _spritePositionX;
		set {
			_spritePositionX = value;
			EmitChanged();
		}
	}

	private float _spritePositionY;
	[Export]
	public float SpritePositionY {
		get => _spritePositionY;
		set {
			_spritePositionY = value;
			EmitChanged();
		}
	}

	[Export]
	public bool ShowShadow { get; set; }

	[Export]
	public SpriteFrames ShadowSprite { get; set; }

	public Character() {
	}
}