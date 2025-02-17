using Godot;
using DiceRolling.Models.Attributes;

namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define os atributos de um papel no jogo.
/// </summary>
public interface IRoleAttributes {
    /// <summary>
    /// Lista de atributos do papel.
    /// </summary>
    Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; }
}