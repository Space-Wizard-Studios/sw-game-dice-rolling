namespace DiceRoll.Models.CharacterActions;

public interface IAction<TContext, TResult>
    where TContext : IActionContext {
    TResult Do(TContext context);
}