namespace DiceRolling.Interfaces.Grids;

/// <summary>
/// Interface que define a configuração de uma grid.
/// </summary>
public interface IGridConfiguration {
    /// <summary>
    /// Número de linhas da grid.
    /// </summary>
    int Rows { get; set; }

    /// <summary>
    /// Número de colunas da grid.
    /// </summary>
    int Columns { get; set; }

    /// <summary>
    /// Prefixo da grid.
    /// </summary>
    string Prefix { get; set; }

    /// <summary>
    /// Offset da grid.
    /// </summary>
    int Offset { get; set; }

    /// <summary>
    /// Direção da grid.
    /// </summary>
    GridDirection Direction { get; set; }
}