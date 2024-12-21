namespace DiceRoll.Models.CharacterActions.Attack;

public class AttackAction : IAction<AttackContext, AttackResult> {
    public AttackResult Do(AttackContext context) {
        int damage = CalculateDamage(context);
        bool manaSpent = SpendMana(context);

        return new AttackResult(damage, manaSpent);
    }

    private static int CalculateDamage(AttackContext context) {
        return 10;
    }

    private static bool SpendMana(AttackContext context) {
        return true;
    }
}