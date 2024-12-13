using Godot;
using System;
using System.Collections.Generic;
namespace DiceRoll.Components;

public partial class TurnOrderComponent : Control {
	[Export] public PanelContainer? PortraitTemplateNode;

	[Export] public TextureRect? PortraitTextureNode;

	[Export] public ColorRect? DamageProgressNode;

	[Export] public ColorPicker? DamageColor;

	[Export] public ColorPicker? FriendlyColor;

	[Export] public ColorPicker? EnemyColor;

	[Export] public ColorPicker? ActiveColor;

	[Export] public ColorPicker? InactiveColor;

}

