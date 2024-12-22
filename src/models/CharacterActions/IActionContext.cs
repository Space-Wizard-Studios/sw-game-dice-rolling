namespace DiceRoll.Models.CharacterActions;

public interface IActionContext {
    Character Target { get; }
    Character Attacker { get; }
}