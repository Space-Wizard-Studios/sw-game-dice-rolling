using DiceRolling.Categories;

namespace DiceRolling.Characters;

/// <summary>
/// Define informações gerais de um personagem.
/// </summary>
public interface ICharacterInformationSheet {
    string Name { get; set; }
    Category? Category { get; set; }
}