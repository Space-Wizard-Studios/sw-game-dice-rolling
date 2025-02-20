using DiceRolling.Roles;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define as informações básicas de um personagem no jogo.
/// </summary>
public interface ICharacterInformation {
    /// <summary>
    /// Identificador único do personagem.
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Nome do personagem.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    /// Categoria do personagem.
    /// </summary>
    CharacterCategory? Category { get; set; }

    /// <summary>
    /// Papel do personagem no jogo.
    /// </summary>
    RoleType? Role { get; set; }

    /// <summary>
    /// Capacidade de dados do personagem.
    /// </summary>
    int DiceCapacity { get; set; }
}