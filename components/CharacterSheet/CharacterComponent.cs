using Godot;
using DiceRoll.Models;

public partial class CharacterComponent : Node2D {
	[Export]
	public Character CharacterResource;

	[Export]
	public AnimatedSprite2D AnimatedSpriteNode;

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
		}
		else {
			GD.PrintErr("AnimatedSprite or CharacterSprite is null");
		}
	}
}
