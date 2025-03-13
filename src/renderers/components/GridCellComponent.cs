using Godot;
using DiceRolling.Entities;
using DiceRolling.Grids;
using DiceRolling.Characters;

namespace DiceRolling.Components.Grids;

[Tool]
[GlobalClass]
[Icon("res://assets/editor/component-3d.svg")]
public partial class GridCellComponent : Node3D {
    private Entity3D? _parent;

}