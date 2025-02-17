using DiceRolling.Models.Characters;

namespace DiceRolling.Models.Actions;

public interface IActionContext {
    CharacterType Target { get; }
    CharacterType Attacker { get; }
}