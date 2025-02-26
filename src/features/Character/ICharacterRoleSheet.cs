using DiceRolling.Roles;

namespace DiceRolling.Characters;
/// <summary>
/// Interface que define a role de um personagem no jogo.
/// </summary>
public interface ICharacterRoleSheet {
    RoleType? Role { get; set; }
}