namespace DiceRolling.Interfaces.Action;

/// <summary>
/// Interface que define uma ação completa no jogo.
/// </summary>
public interface IAction<TContext, TResult> :
    IActionInformation,
    IActionAssets,
    IActionBehavior<TContext, TResult> { }