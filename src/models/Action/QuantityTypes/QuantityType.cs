using Godot;

namespace DiceRoll.Models.Actions;

[Tool]
[GlobalClass]
public partial class QuantityType : Resource {
    [Export] public string? Name { get; set; }

    public QuantityType() { }

    public QuantityType(string name) {
        Name = name;
    }
}