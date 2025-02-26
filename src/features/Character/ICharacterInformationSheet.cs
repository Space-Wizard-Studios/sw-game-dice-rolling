using DiceRolling.Roles;

namespace DiceRolling.Characters;

/// <summary>
/// Interface que define informações gerais de um personagem.
/// </summary>
public interface ICharacterInformationSheet {
    string Name { get; set; }
    CharacterCategory? Category { get; set; }
}