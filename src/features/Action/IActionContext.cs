using DiceRolling.Characters;

namespace DiceRolling.Actions;

public interface IActionContext {
    CharacterType Target { get; }
    CharacterType Attacker { get; }
}