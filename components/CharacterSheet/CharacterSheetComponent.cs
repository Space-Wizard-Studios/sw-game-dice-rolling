using Godot;
using DiceRoll.Models;

namespace DiceRoll.Components;

public partial class CharacterSheetComponent : Node2D {
	[Export]
	public Character CharacterResource;

	[Export]
	public HealthComponent HealthComponentNode;

	[Export]
	public AnimatedSprite2D AnimatedSpriteNode;

	[Export]
	public AnimatedSprite2D ShadowNode;

	[Export]
	public bool ShowShadow {
		get => ShadowNode?.Visible ?? false;
		set {
			if (ShadowNode != null) {
				ShadowNode.Visible = value;
			}
			else {
				GD.PrintErr("ShadowNode is null");
			}
		}
	}

	[Export]
	public float AnimatedSpriteOffsetX {
		get => AnimatedSpriteNode.Position.X;
		set => AnimatedSpriteNode.Position = new Vector2(value, AnimatedSpriteNode.Position.Y);
	}

	[Export]
	public float AnimatedSpriteOffsetY {
		get => AnimatedSpriteNode.Position.Y;
		set => AnimatedSpriteNode.Position = new Vector2(AnimatedSpriteNode.Position.X, value);
	}

	private Character _currentCharacter;

	public override void _EnterTree() {
		if (CharacterResource != null) {
			SetCharacter(CharacterResource);
		}
		else {
			GD.PrintErr("CharacterResource is null");
		}
	}

	public override void _Ready() {
		if (CharacterResource != null) {
			SetCharacter(CharacterResource);
		}
		else {
			GD.PrintErr("CharacterResource is null");
		}
	}

	public override void _Process(double delta) {
		if (CharacterResource != _currentCharacter) {
			SetCharacter(CharacterResource);
		}
	}

	public void SetCharacter(Character character) {
		_currentCharacter = character;
		this.CharacterResource = character;
		if (AnimatedSpriteNode != null && character.CharacterSprite != null) {
			AnimatedSpriteNode.SpriteFrames = character.CharacterSprite;
			AnimatedSpriteNode.Play("idle");
			AnimatedSpriteNode.Position = new Vector2(character.SpriteOffsetX, character.SpriteOffsetY);
		}
		else {
			GD.PrintErr("AnimatedSprite or CharacterSprite is null");
		}

		if (ShadowNode != null) {
			if (character.ShadowSprite != null) {
				ShadowNode.SpriteFrames = character.ShadowSprite;
				ShowShadow = character.ShowShadow;
			}
			else {
				ShowShadow = false;
			}
		}
		else {
			GD.PrintErr("ShadowNode is null");
		}

		if (HealthComponentNode != null && character.Health != null) {
			HealthComponentNode.HealthResource = character.Health;
			HealthComponentNode.UpdateHealthLabel();
		}
		else {
			GD.PrintErr("HealthComponentNode or Character.Health is null");
		}
	}
}
