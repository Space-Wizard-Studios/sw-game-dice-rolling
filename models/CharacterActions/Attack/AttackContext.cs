namespace DiceRoll.Models.CharacterActions.Attack;

public struct AttackContext(Character attacker, Character target) : IActionContext {
    public Character Attacker { get; set; } = attacker;
    public Character Target { get; set; } = target;
}