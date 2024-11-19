using Godot;

public partial class SceneTransitionButton : Button {
	[Export] public SceneEntriesList SceneList { get; set; }
	[Export] public string TargetScene { get; set; }

	public override void _Ready() {
		this.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed() {
		var transitionManager = GetNode<TransitionManager>("/root/GameplayTransitionManager");
		if (SceneList != null) {
			foreach (var sceneEntry in SceneList.Scenes) {
				if (sceneEntry.SceneName == TargetScene) {
					transitionManager.TransitionTo(sceneEntry.SceneName);
					return;
				}
			}
			GD.PrintErr($"Scene {TargetScene} not found!");
		}
		else {
			GD.PrintErr("SceneList is not set!");
		}
	}
}