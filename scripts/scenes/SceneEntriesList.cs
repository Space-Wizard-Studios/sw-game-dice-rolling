using Godot;
using Godot.Collections;

[Tool]
public partial class SceneEntriesList : Resource {
    [Export] public Array<SceneEntry> Scenes { get; set; } = new Array<SceneEntry>();
}