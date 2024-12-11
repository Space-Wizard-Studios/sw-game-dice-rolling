using System;
using Godot;
using DiceRoll.Managers;

namespace DiceRoll.UI;

[Tool]
public partial class PlaygroundTransitionMenu : MenuButton {
	private PlaygroundTransitionManager? _playgroundTransitionManager;

	public override void _Ready() {
		if (!Engine.IsEditorHint()) {
			_playgroundTransitionManager = (PlaygroundTransitionManager)GetNode("/root/PlaygroundTransitionManager");

			if (_playgroundTransitionManager == null) {
				GD.PrintErr("PlaygroundTransitionManager not found!");
				return;
			}

			// Add items to the MenuButton's popup for each PlaygroundScene
			var popup = GetPopup();
			foreach (PlaygroundScenes scene in Enum.GetValues(typeof(PlaygroundScenes))) {
				popup.AddItem(scene.ToString(), (int)scene);
			}

			// Connect the item_pressed signal to handle the transitions
			popup.Connect("id_pressed", new Callable(this, nameof(OnItemPressed)));
		}
	}

	private void OnItemPressed(int id) {
		var scene = (PlaygroundScenes)id;
		_playgroundTransitionManager?.TransitionTo(scene);
	}
}
