using Godot.Collections;
using DiceRolling.Dice;
using DiceRolling.Targets;
using DiceRolling.Effects;

namespace DiceRolling.Actions;

/// <summary>
/// Interface que define o comportamento de uma ação no jogo.
/// </summary>
public interface IActionBehavior<TContext, TResult> {
    /// <summary>
    /// Energia necessária para executar a ação.
    /// </summary>
    Array<DiceEnergy> RequiredEnergy { get; set; }

    /// <summary>
    /// Efeitos da ação.
    /// </summary>
    Array<EffectType> Effects { get; set; }

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