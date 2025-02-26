namespace DiceRolling.Actions;

/// <summary>
/// Interface que define as informações básicas de uma ação no jogo.
/// </summary>
public interface IActionInformation {
    /// <summary>
    /// Nome da ação.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Categoria da ação.
    /// </summary>
    ActionCategory? Category { get; set; }

    /// <summary>
    /// Descrição da ação.
    /// </summary>
    string? Description { get; set; }
}