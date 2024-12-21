using Godot;
namespace DiceRoll.Models;

[Tool]
[GlobalClass]
public partial class RoleAttribute : Resource {
    [Export] public AttributeType? Type { get; set; }

    [Export] public int BaseValue { get; set; }
    public RoleAttribute() { }
}