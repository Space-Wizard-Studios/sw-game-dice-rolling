using Godot;
using System;

namespace DiceRoll.Components;

public enum ForwardDirection {
	Left,
	Right
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

	private ForwardDirection _direction = ForwardDirection.Right;

	[Export]
	public ForwardDirection Direction {
		get => _direction;
		set {
			_direction = value;
			OnDirectionSet();
		}
	}

	public override void _Ready() {
		base._Ready();
		OnDirectionSet();
	}

	private void FlipCharacters() {
		var CharacterNodesArray = new CharacterComponent[] {
			Character1Node as CharacterComponent,
			Character2Node as CharacterComponent,
			Character3Node as CharacterComponent
		};

		foreach (var characterNode in CharacterNodesArray) {
			if (characterNode != null) {
				characterNode.AnimatedSpriteNode.FlipH = Direction == ForwardDirection.Left;
			}
		}
	}

	private void OnDirectionSet() {
		GD.Print("Forward Direction was set!");

		if (Direction == ForwardDirection.Left) {
			RowContainer.LayoutDirection = LayoutDirectionEnum.Rtl;
		}
		else {
			RowContainer.LayoutDirection = LayoutDirectionEnum.Ltr;
		}

		FlipCharacters();
	}
}
