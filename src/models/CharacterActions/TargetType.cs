// TargetType.cs
using Godot;

namespace DiceRoll.Models.CharacterActions;

[Tool]
[GlobalClass]
public partial class TargetType : Resource {
    [Export] public string? Name { get; set; }

    public TargetType() { }

    public TargetType(string name) {
        Name = name;
    }
}