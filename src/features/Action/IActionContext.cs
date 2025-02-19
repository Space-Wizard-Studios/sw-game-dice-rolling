using DiceRolling.Models.Characters;

namespace DiceRolling.Interfaces.Action;

public interface IActionContext {
    CharacterType Target { get; }
    CharacterType Attacker { get; }
}