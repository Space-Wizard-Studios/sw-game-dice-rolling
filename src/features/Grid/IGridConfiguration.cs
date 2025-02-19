namespace DiceRolling.Interfaces.Grid;

/// <summary>
/// Interface que define a configuração de uma grid.
/// </summary>
public interface IGridConfiguration {
    /// <summary>
    /// Número de linhas da grid.
    /// </summary>
    int Rows { get; }

    /// <summary>
    /// Número de colunas da grid.
    /// </summary>
    int Columns { get; }

    /// <summary>
    /// Prefixo da grid.
    /// </summary>
    string Prefix { get; }

    /// <summary>
    /// Offset da grid.
    /// </summary>
    int Offset { get; }

    /// <summary>
    /// Direção da grid.
    /// </summary>
    GridDirection Direction { get; }
}