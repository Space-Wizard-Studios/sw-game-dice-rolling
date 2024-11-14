using Godot;
using System.Collections.Generic;

public enum TargetCategory {
	Enemy,
	Ally,
	Self,
	Any,
	Nothing
}

[Tool]
public partial class DiceAction : Resource {
	[Export]
	public string Name { get; set; }
	[Export]
	public string Description { get; set; }
	[Export]
	public Godot.Collections.Array<DiceMana> RequiredMana { get; set; } = new Godot.Collections.Array<DiceMana>();

	[Export(PropertyHint.Enum, "Enemy,Ally,Self,Any,Nothing")]
	public TargetCategory Category { get; set; }

	private int targetQuantity;
	[Export(PropertyHint.Range, "-1,100,1")]
	public int TargetQuantity {
		get => targetQuantity;
		set {
			if (value >= -1) {
				targetQuantity = value;
			}
			else {
				GD.PrintErr("Invalid TargetQuantity value. Use -1 for all, 0 for nothing, or a positive number.");
			}
		}
	}

	public DiceAction() { }

	public DiceAction(string name, string description, Godot.Collections.Array<DiceMana> requiredMana) {
		Name = name;
		Description = description;
		RequiredMana = requiredMana;
	}
}