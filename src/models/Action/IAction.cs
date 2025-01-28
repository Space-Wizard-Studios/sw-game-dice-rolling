namespace DiceRolling.Models.Actions;

public interface IAction<TContext, TResult>
    where TContext : IActionContext
{
    TResult Do(TContext context);
}