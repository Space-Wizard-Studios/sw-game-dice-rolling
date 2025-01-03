namespace DiceRoll.Models.Actions;

public interface IActionContext {
    Character Target { get; }
    Character Attacker { get; }
}