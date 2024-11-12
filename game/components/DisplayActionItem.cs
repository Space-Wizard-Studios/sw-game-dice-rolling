using Godot;

public partial class DisplayActionItem : Control {
	[Export] public ColorRect ActionItemBackground { get; private set; }
	[Export] public Label ActionItemLabel { get; private set; }

	public override void _Ready() { }
}