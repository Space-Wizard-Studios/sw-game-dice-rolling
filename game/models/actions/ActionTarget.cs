using Godot;

public enum TargetCategory
{
    Enemy,
    Ally,
    Self,
    Any,
    Nothing
}

public enum TargetQuantity
{
    None,
    All,
    One
}

public partial class ActionTarget : Resource
{
    [Export]
    public string Name { get; set; }

    [Export]
    public string Description { get; set; }

    [Export]
    public TargetCategory Category { get; set; }

    [Export]
    public TargetQuantity Quantity { get; set; }

    public ActionTarget() { }

    public ActionTarget(string name, string description, TargetCategory category, TargetQuantity quantity)
    {
        Name = name;
        Description = description;
        Category = category;
        Quantity = quantity;
    }
}