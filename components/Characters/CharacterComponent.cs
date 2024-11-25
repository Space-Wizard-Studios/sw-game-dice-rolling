using Godot;
using DiceRoll.Models;

namespace DiceRoll.Components;

[Tool]
public partial class CharacterComponent : Control {

	private Resource _characterResource;

	[Export]
	public Resource CharacterResource {
		get; set;
	}

	[Export]
	public AnimatedSprite2D AnimatedSpriteNode { get; set; }

	[Export]
	public AnimatedSprite2D ShadowNode { get; set; }

	private bool _showShadow;

	[Export]
	public bool ShowShadow {
		get => _showShadow;
		set {
			_showShadow = value;
			OnShowShadowSet();
		}
	}

	private float _animatedSpritePositionX;
	[Export]
	public float AnimatedSpritePositionX {
		get => _animatedSpritePositionX;
		set {
			_animatedSpritePositionX = value;
			OnAnimatedSpritePositionSet();
		}
	}

	private float _animatedSpritePositionY;
	[Export]
	public float AnimatedSpritePositionY {
		get => _animatedSpritePositionY;
		set {
			_animatedSpritePositionY = value;
			OnAnimatedSpritePositionSet();
		}
	}

	private void OnCharacterResourceSet() {
		if (CharacterResource == null) {
			GD.Print("CharacterResource is null");
			return;
		}

		// Character character = CharacterResource as Character;
		// if (character == null) {
		// 	GD.PrintErr("CharacterResource is not of type Character");
		// 	return;
		// }

		// if (character.CharacterSprite == null) {
		// 	GD.PrintErr("CharacterSprite is null");
		// 	return;
		// }

		// AnimatedSpriteNode.SpriteFrames = character.CharacterSprite;
		// AnimatedSpriteNode.Play("idle");
		// AnimatedSpriteNode.Position = new Godot.Vector2(character.SpritePositionX, character.SpritePositionY);
	}

	private void OnShowShadowSet() {
		if (ShadowNode == null) {
			GD.Print("ShadowNode is null");
			return;
		}

		if (ShowShadow == true) {
			ShadowNode.Visible = true;
		}
		else {
			ShadowNode.Visible = false;
		}
	}

	private void OnAnimatedSpritePositionSet() {
		if (AnimatedSpriteNode == null) {
			GD.Print("AnimatedSpriteNode is null");
			return;
		}

		AnimatedSpriteNode.Position = new Vector2(AnimatedSpritePositionX, AnimatedSpritePositionY);
	}

	public override void _Ready() {
		// Ensure that the nodes are properly initialized
		if (AnimatedSpriteNode == null) {
			GD.PrintErr("AnimatedSpriteNode is not set");
		}
		if (ShadowNode == null) {
			GD.PrintErr("ShadowNode is not set");
		}

		var character = CharacterResource as Character;
		AnimatedSpriteNode.SpriteFrames = character.CharacterSprite;
		AnimatedSpriteNode.Play("idle");
	}
}