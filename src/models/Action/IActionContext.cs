using DiceRolling.Models.Characters;

namespace DiceRolling.Models.Actions;

public interface IActionContext
{
    Character Target { get; }
    Character Attacker { get; }
}