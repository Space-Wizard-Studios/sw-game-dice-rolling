// TargetType.cs
using Godot;

namespace DiceRoll.Models.Actions;

[Tool]
[GlobalClass]
public partial class TargetType : Resource {
    [Export] public string? Name { get; set; }

    public TargetType() { }

    public TargetType(string name) {
        Name = name;
    }
}