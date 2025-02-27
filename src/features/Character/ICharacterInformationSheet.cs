namespace DiceRolling.Characters;

/// <summary>
/// Define informações gerais de um personagem.
/// </summary>
public interface ICharacterInformationSheet {
    string Name { get; set; }
    CharacterCategory? Category { get; set; }
}