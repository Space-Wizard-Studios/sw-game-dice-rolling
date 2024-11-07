using Godot;
using System.Collections.Generic;

public partial class ActionColor : Resource {
	[Export]
	public string Background { get; set; }
	[Export]
	public string Text { get; set; }

	public ActionColor() { }

	public ActionColor(string background, string text) {
		Background = background;
		Text = text;
	}
}

public partial class ActionTarget : Resource {
	[Export]
	public string Name { get; set; }
	[Export]
	public string Description { get; set; }
	[Export]
	public string Category { get; set; }
	[Export]
	public string Quantity { get; set; }

	public ActionTarget() { }

	public ActionTarget(string name, string description, string category, string quantity) {
		Name = name;
		Description = description;
		Category = category;
		Quantity = quantity;
	}
}

public partial class DiceAction : Resource {
	[Export]
	public string Name { get; set; }
	[Export]
	public string Abbreviation { get; set; }
	[Export]
	public string Description { get; set; }
	[Export]
	public Godot.Collections.Array<ActionTarget> Targets { get; set; } = new Godot.Collections.Array<ActionTarget>();
	[Export]
	public ActionColor Colors { get; set; }

	public DiceAction() { }

	public DiceAction(string name, string abbreviation, string description, Godot.Collections.Array<ActionTarget> targets, ActionColor colors) {
		Name = name;
		Abbreviation = abbreviation;
		Description = description;
		Targets = targets;
		Colors = colors;
	}
}

public static class Targets {
	public static readonly ActionTarget Nothing = new ActionTarget("Nothing", "Do nothing.", "nothing", "none");
	public static readonly ActionTarget EnemySingle = new ActionTarget("Enemy Single", "Target a single enemy.", "enemy", "1");
	public static readonly ActionTarget EnemyAll = new ActionTarget("Enemy All", "Target all enemies.", "enemy", "all");
	public static readonly ActionTarget Self = new ActionTarget("Self", "Target yourself.", "self", "1");
	public static readonly ActionTarget Any = new ActionTarget("Any", "Target any entity.", "any", "1");
}