namespace DiceRoll.Models;

public class Attack : IAction<AttackContext, AttackResult> {
    public AttackResult Do(AttackContext context) {
        // Example logic for dealing damage, spending mana, and breaking weapon
        int damage = CalculateDamage(context);
        bool manaSpent = SpendMana(context);

        return new AttackResult(damage, manaSpent);
    }

    private int CalculateDamage(AttackContext context) {
        // Implement damage calculation logic here
        return 10; // Example damage value
    }

    private bool SpendMana(AttackContext context) {
        // Implement mana spending logic here
        return true; // Example mana spent
    }
}