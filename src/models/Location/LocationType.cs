using Godot;
using DiceRolling.Interfaces.Location;

namespace DiceRolling.Models.Locations;

[Tool]
[GlobalClass]
public partial class LocationType : Resource, ILocation {
    [Export] public string Name { get; set; } = "";
    [Export] public string Description { get; set; } = "";
    [Export] public int TotalSlots { get; set; } = 6;
}