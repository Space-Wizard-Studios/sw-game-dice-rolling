using Godot;
using DiceRolling.Models.Grids;

namespace DiceRolling.Interfaces.Target;

/// <summary>
/// Interface que define a configuração de alvo no jogo.
/// </summary>
public interface ITarget {
    /// <summary>
    /// Emite um sinal quando a configuração é alterada.
    /// </summary>
    [Signal] delegate void ConfigurationChangedEventHandler();

    /// <summary>
    /// Indica se é um alvo único.
    /// </summary>
    bool IsSingleTarget { get; set; }

    /// <summary>
    /// Coleção de grids associadas ao alvo.
    /// </summary>
    Godot.Collections.Array<GridType> Grids { get; set; }

    /// <summary>
    /// Adiciona uma nova grid.
    /// </summary>
    /// <param name="rows">Número de linhas da grid.</param>
    /// <param name="columns">Número de colunas da grid.</param>
    void AddGrid(int rows, int columns);

    /// <summary>
    /// Atualiza uma grid existente.
    /// </summary>
    /// <param name="index">Índice da grid a ser atualizada.</param>
    void UpdateGrid(int index);
}