using DiceRolling.Roles;

namespace DiceRolling.Characters;
/// <summary>
/// Define a role de um personagem no jogo.
/// </summary>
public interface ICharacterRoleSheet {
    RoleType? Role { get; set; }
}