namespace DiceRoll.Models;

public class AttackResult {
    public int DamageDealt { get; set; }
    public bool ManaSpent { get; set; }

    public AttackResult(int damageDealt, bool manaSpent) {
        DamageDealt = damageDealt;
        ManaSpent = manaSpent;
    }
}