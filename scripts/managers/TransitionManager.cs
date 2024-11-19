using Godot;

public partial class TransitionManager : Node {
	[Export] public SceneEntriesList SceneEntriesList { get; set; }

	public void TransitionTo(string sceneName) {
		if (SceneEntriesList == null) {
			GD.PrintErr("SceneEntriesList is not set!");
			return;
		}

		GD.Print("Available scenes:");
		foreach (var sceneEntry in SceneEntriesList.Scenes) {
			GD.Print($"- {sceneEntry.SceneName}");
		}

		foreach (var sceneEntry in SceneEntriesList.Scenes) {
			if (sceneEntry.SceneName == sceneName) {
				GetTree().ChangeSceneToFile(sceneEntry.Scene.ResourcePath);
				return;
			}
		}
		GD.PrintErr($"Scene {sceneName} not found!");
	}
}