namespace DiceRolling.Characters;
/// <summary>
/// Define a role de um personagem no jogo.
/// </summary>
public interface ICharacterRoleSheet {
    CharacterRole? Role { get; set; }
}