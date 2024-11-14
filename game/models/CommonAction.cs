using Godot;

[Tool]
public partial class CommonAction : Resource {
	[Export]
	public string Name { get; set; }
	[Export]
	public string Description { get; set; }

	public CommonAction() { }

	public CommonAction(string name, string description) {
		Name = name;
		Description = description;
	}
}