namespace DiceRoll.Models.CharacterActions.Attack;

public class AttackResult(int damageDealt, bool manaSpent) {
    public int DamageDealt { get; set; } = damageDealt;
    public bool ManaSpent { get; set; } = manaSpent;
}