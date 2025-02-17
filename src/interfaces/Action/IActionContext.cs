using DiceRolling.Models.Characters;

namespace DiceRolling.Interfaces.Actions;

public interface IActionContext {
    CharacterType Target { get; }
    CharacterType Attacker { get; }
}