using System;
using Godot;
using DiceRoll.Managers;

namespace DiceRoll.UI;

public enum SceneTransitionType {
	None,
	Menu,
	Gameplay
}

[Tool]
public partial class SceneTransitionButton : Button {
	private SceneTransitionType _typeOfTransition = SceneTransitionType.None;
	[Export]
	public SceneTransitionType TypeOfTransition {
		get => _typeOfTransition;
		set {
			if (_typeOfTransition != value) {
				_typeOfTransition = value;
				NotifyPropertyListChanged();
			}
		}
	}

	[Export]
	public MenuScenes MenuScene { get; set; } = MenuScenes.MainMenu;

	[Export]
	public GameplayScenes GameplayScene { get; set; } = GameplayScenes.GameplayLobby;

	private readonly MenuTransitionManager _menuTransitionManager;
	private readonly GameplayTransitionManager _gameplayTransitionManager;

	public SceneTransitionButton(MenuTransitionManager menuTransitionManager, GameplayTransitionManager gameplayTransitionManager) {
		_menuTransitionManager = menuTransitionManager ?? throw new ArgumentNullException(nameof(menuTransitionManager));
		_gameplayTransitionManager = gameplayTransitionManager ?? throw new ArgumentNullException(nameof(gameplayTransitionManager));
	}

	public override void _Ready() {
		if (!Engine.IsEditorHint()) {
			this.Pressed += OnButtonPressed;
		}
	}

	private void OnButtonPressed() {
		switch (TypeOfTransition) {
			case SceneTransitionType.Menu:
				_menuTransitionManager?.TransitionTo(MenuScene);
				break;
			case SceneTransitionType.Gameplay:
				_gameplayTransitionManager?.TransitionTo(GameplayScene);
				break;
		}
	}

	public override void _ValidateProperty(Godot.Collections.Dictionary property) {
		if (property["name"].AsStringName() == "MenuScene" && TypeOfTransition != SceneTransitionType.Menu) {
			var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
			property["usage"] = (int)usage;
		}
		if (property["name"].AsStringName() == "GameplayScene" && TypeOfTransition != SceneTransitionType.Gameplay) {
			var usage = property["usage"].As<PropertyUsageFlags>() | PropertyUsageFlags.ReadOnly;
			property["usage"] = (int)usage;
		}
	}
}