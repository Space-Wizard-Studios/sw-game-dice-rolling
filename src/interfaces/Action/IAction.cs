namespace DiceRolling.Interfaces.Action;
/// <summary>
/// Interface que define uma ação no jogo.
/// </summary>
/// <typeparam name="TContext">O tipo do contexto da ação.</typeparam>
/// <typeparam name="TResult">O tipo do resultado da ação.</typeparam>
public interface IAction<TContext, TResult>
    where TContext : IActionContext {
    /// <summary>
    /// Executa a ação com o contexto fornecido.
    /// </summary>
    /// <param name="context">O contexto da ação.</param>
    /// <returns>O resultado da ação.</returns>
    TResult Do(TContext context);
}
