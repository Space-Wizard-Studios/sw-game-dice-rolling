using Godot;
using DiceRolling.Grids;

namespace DiceRolling.Entities;

[Tool]
[GlobalClass]
public partial class GridEntity : Entity3D {

    [Export]
    public GridType? GridData {
        get => GetData<GridType>();
        set => Data = value;
    }

    [ExportToolButton("Update Grid")]
    public Callable UpdateGridData => Callable.From(() => NotifyUpdate());
}