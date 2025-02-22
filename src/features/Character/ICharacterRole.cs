using DiceRolling.Roles;

namespace DiceRolling.Characters;
/// <summary>
/// Interface que define a role de um personagem no jogo.
/// </summary>
public interface ICharacterRole {
    /// <summary>
    /// Role do personagem no jogo.
    /// </summary>
    RoleType? Role { get; set; }
}