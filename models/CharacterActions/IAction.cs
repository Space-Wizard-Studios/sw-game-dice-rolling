namespace DiceRoll.Models;

public interface IAction<TContext, TResult>
    where TContext : IActionContext {
    TResult Do(TContext context);
}