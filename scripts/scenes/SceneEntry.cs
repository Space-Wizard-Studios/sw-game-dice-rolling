using Godot;

[Tool]
public partial class SceneEntry : Resource {
	[Export] public string SceneName { get; set; }
	[Export] public PackedScene Scene { get; set; }
}