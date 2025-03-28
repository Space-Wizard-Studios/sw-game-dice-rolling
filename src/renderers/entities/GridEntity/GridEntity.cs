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

    [ExportToolButton("Assign Characters")]
    public Callable AssignCharactersButton => Callable.From(() => {
        if (GridData != null) {
            GridData.AssignCharacters();
            NotifyUpdate();
        }
    });
}