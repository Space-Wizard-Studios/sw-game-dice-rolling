using Godot.Collections;
using DiceRolling.Models.Actions.Effects;
using DiceRolling.Models.Actions.Targets;
using DiceRolling.Models;

namespace DiceRolling.Interfaces.Action;

/// <summary>
/// Interface que define o comportamento de uma ação no jogo.
/// </summary>
public interface IActionBehavior<TContext, TResult> {
    /// <summary>
    /// Efeitos da ação.
    /// </summary>
    Array<EffectType> Effects { get; set; }

    /// <summary>
    /// Mana necessária para executar a ação.
    /// </summary>
    Array<DiceMana> RequiredMana { get; set; }

    /// <summary>
    /// Configuração de alvo da ação.
    /// </summary>
    TargetConfiguration? TargetConfiguration { get; set; }

    /// <summary>
    /// Executa a ação com o contexto fornecido.
    /// </summary>
    /// <param name="context">O contexto da ação.</param>
    /// <returns>O resultado da ação.</returns>
    TResult Do(TContext context);
}