namespace DiceRoll.Models;

public struct AttackContext : IActionContext {
    public Character Attacker { get; set; }
    public Character Target { get; set; }

    public AttackContext(Character attacker, Character target) {
        Attacker = attacker;
        Target = target;
    }
}