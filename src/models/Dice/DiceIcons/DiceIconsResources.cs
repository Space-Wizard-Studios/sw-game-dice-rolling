using Godot;

namespace DiceRolling.Models;

[Tool]
public partial class DiceIconsResources : Resource
{
    [Export]
    public Godot.Collections.Array<DiceIcon> DiceIcons { get; set; } = [];

    public DiceIcon? GetIconForSides(int sides)
    {
        foreach (var entry in DiceIcons)
        {
            if (entry is DiceIcon diceIcon)
            {
                if (diceIcon.Sides == sides)
                {
                    return diceIcon;
                }
            }
            else
            {
                GD.PrintErr($"Invalid entry in DiceIcons array: {entry.GetType().Name}");
            }
        }
        GD.PrintErr($"No icon found for dice with {sides} sides");
        return null;
    }
}