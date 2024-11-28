using Godot;
using System;

namespace DiceRoll.Components;

public enum ForwardDirection {
	Right,
	Left,
}

[Tool]
public partial class CharacterRow : HBoxContainer {

	[Export]
	public Control Character1Node { get; set; }

	[Export]
	public Control Character2Node { get; set; }

	[Export]
	public Control Character3Node { get; set; }

	[Export]
	public HBoxContainer RowContainer { get; set; }

	private ForwardDirection _direction;

	[Export]
	public ForwardDirection ForwardDirection {
		get => _direction;
		set {
			_direction = value;
			if (Character1Node != null && Character2Node != null && Character3Node != null && RowContainer != null) {
				OnDirectionSet();
				FlipCharacters();
			}
		}
	}

	private void FlipCharacters() {
		var CharacterNodesArray = new CharacterComponent[] {
		Character1Node as CharacterComponent,
		Character2Node as CharacterComponent,
		Character3Node as CharacterComponent
	};

		foreach (var characterNode in CharacterNodesArray) {
			if (characterNode != null && characterNode.AnimatedSpriteNode != null) {
				characterNode.AnimatedSpriteNode.FlipH = ForwardDirection == ForwardDirection.Left;
			}
		}
	}

	private void OnDirectionSet() {
		GD.Print("Forward Direction was set as " + ForwardDirection.ToString());

		if (ForwardDirection == ForwardDirection.Left) {
			RowContainer.LayoutDirection = LayoutDirectionEnum.Rtl;
		}
		else {
			RowContainer.LayoutDirection = LayoutDirectionEnum.Ltr;
		}

	}

	public override void _Ready() {
		OnDirectionSet();
		FlipCharacters();
	}
}
