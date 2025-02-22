using DiceRolling.Roles;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define as informações básicas de um personagem no jogo.
/// </summary>
public interface ICharacterInformation {
    /// <summary>
    /// Nome do personagem.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Categoria do personagem.
    /// </summary>
    CharacterCategory? Category { get; set; }
}