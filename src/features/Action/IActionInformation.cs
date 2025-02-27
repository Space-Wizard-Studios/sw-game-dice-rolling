namespace DiceRolling.Actions;

/// <summary>
/// Interface que informações gerais de uma ação.
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