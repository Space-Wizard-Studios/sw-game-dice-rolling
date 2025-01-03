using Godot;
using System;

namespace DiceRoll.Models.Actions;

[Tool]
[GlobalClass]
public partial class ActionSource : Resource {
    [Export] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Export] public string? Name { get; set; }
    public ActionSource() { }

}