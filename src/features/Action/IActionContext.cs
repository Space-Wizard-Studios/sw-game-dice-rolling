using DiceRolling.Characters;

namespace DiceRolling.Actions;

/// <summary>
/// Define o contexto de uma ação.
/// </summary>
public interface IActionContext {
    CharacterType Target { get; }
    CharacterType Attacker { get; }
}