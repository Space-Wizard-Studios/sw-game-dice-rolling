using Godot;

using Godot.Collections;

namespace DiceRolling.Grids;

/// <summary>
/// Interface que define as células de uma grid.
/// </summary>
public interface IGridCells {
    /// <summary>
    /// Células da grid.
    /// </summary>
    Array<int> Cells { get; }

    /// <summary>
    /// Obtém o índice de uma célula.
    /// </summary>
    /// <param name="row">Linha da célula.</param>
    /// <param name="column">Coluna da célula.</param>
    /// <returns>Índice da célula.</returns>
    int GetCellIndex(int row, int column);

    /// <summary>
    /// Obtém o valor de uma célula.
    /// </summary>
    /// <param name="row">Linha da célula.</param>
    /// <param name="column">Coluna da célula.</param>
    /// <returns>Valor da célula.</returns>
    int GetCell(int row, int column);

    /// <summary>
    /// Define o valor de uma célula.
    /// </summary>
    /// <param name="row">Linha da célula.</param>
    /// <param name="column">Coluna da célula.</param>
    /// <param name="value">Valor da célula.</param>
    void SetCell(int row, int column, int value);
}