namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define as informações básicas de um arquétipo de personagem no jogo.
/// </summary>
public interface IRoleInformation {
    /// <summary>
    /// Identificador único do arquétipo de personagem.
    /// </summary>
    string Id { get; set; }
    /// <summary>
    /// Nome do arquétipo de personagem.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    /// Descrição do arquétipo de personagem.
    /// </summary>
    string? Description { get; set; }
}