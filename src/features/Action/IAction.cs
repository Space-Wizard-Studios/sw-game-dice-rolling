using DiceRolling.Common;
using DiceRolling.Effects;

namespace DiceRolling.Actions;

/// <summary>
/// Interface que define uma ação completa no jogo.
/// </summary>
public interface IAction<TContext, TResult> :
    IIdentifiable,
    IActionInformation,
    IActionAssets,
    IActionBehavior<TContext, TResult> {

    bool IsValid();
    void AddEffect(EffectType effect);
    void RemoveEffect(EffectType effect);
}