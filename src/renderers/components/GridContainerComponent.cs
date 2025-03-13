using Godot;
using DiceRolling.Entities;
using DiceRolling.Grids;
using DiceRolling.Helpers;

namespace DiceRolling.Components.Grids;

[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class GridContainerComponent : Node3D {
    private GridEntity? _parent;

}