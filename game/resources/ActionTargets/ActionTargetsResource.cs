using Godot;
using System.Collections.Generic;

[Tool]
public partial class TargetsResource : Resource
{
    [Export]
    public Godot.Collections.Dictionary<string, ActionTarget> Targets { get; set; } = new Godot.Collections.Dictionary<string, ActionTarget>
    {
        { "allySingle", new ActionTarget("Ally Single", "Target a single ally.", TargetCategory.Ally, TargetQuantity.One) },
        { "allyAll", new ActionTarget("Ally All", "Target all allies.", TargetCategory.Ally, TargetQuantity.All) },
        { "enemySingle", new ActionTarget("Enemy Single", "Target a single enemy.", TargetCategory.Enemy, TargetQuantity.One) },
        { "enemyAll", new ActionTarget("Enemy All", "Target all enemies.", TargetCategory.Enemy, TargetQuantity.All) },
        { "self", new ActionTarget("Self", "Target yourself.", TargetCategory.Self, TargetQuantity.One) },
        { "any", new ActionTarget("Any", "Target any character.", TargetCategory.Any, TargetQuantity.One) },
        { "nothing", new ActionTarget("Nothing", "Do not target anything.", TargetCategory.Nothing, TargetQuantity.None) }
    };
}