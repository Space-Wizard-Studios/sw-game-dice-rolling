using Godot;
using DiceRolling.Components.Characters;

namespace DiceRolling.Components.Grids;

public partial class GridCell3D : Node3D
{
    public Marker3D CellMarker { get; private set; }
    public Label3D CellLabel { get; private set; }
    public CharacterComponent? Character { get; private set; }

    // Parameterless constructor
    public GridCell3D()
    {
        CellMarker = new Marker3D();
        AddChild(CellMarker);

        CellLabel = new Label3D
        {
            Billboard = BaseMaterial3D.BillboardModeEnum.Enabled,
        };
        AddChild(CellLabel);
    }

    // Constructor with parameters
    public GridCell3D(Vector3 position, string labelText) : this()
    {
        CellMarker.Transform = new Transform3D(Basis.Identity, position);
        CellLabel.Text = labelText;
        CellLabel.Transform = new Transform3D(Basis.Identity, new Vector3(position.X + 0.55f, 0.25f, position.Z + 1));
    }

    public void SetCharacter(CharacterComponent character)
    {
        Character = character;
        AddChild(character);
    }
}