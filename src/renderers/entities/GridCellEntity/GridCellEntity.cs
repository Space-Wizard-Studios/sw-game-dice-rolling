using Godot;
using DiceRolling.Grids;

namespace DiceRolling.Entities;

[Tool]
[GlobalClass]
public partial class GridCellEntity : Entity3D {

    [Export]
    public GridCellType? CellData {
        get => GetData<GridCellType>();
        set => Data = value;
    }

    [ExportToolButton("Update Cell")]
    public Callable UpdateCellData => Callable.From(() => NotifyUpdate());
}