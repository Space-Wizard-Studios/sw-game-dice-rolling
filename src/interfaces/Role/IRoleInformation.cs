namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define as informações básicas de um papel no jogo.
/// </summary>
public interface IRoleInformation {
    /// <summary>
    /// Nome do papel.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    /// Descrição do papel.
    /// </summary>
    string? Description { get; set; }
}