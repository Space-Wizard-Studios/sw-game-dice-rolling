using Godot.Collections;
using DiceRolling.Models.Attributes;

namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define os atributos de um arquétipo de personagem no jogo.
/// </summary>
public interface IRoleAttributes {
    /// <summary>
    /// Lista de atributos do arquétipo de personagem.
    /// </summary>
    Godot.Collections.Array<RoleAttribute> RoleAttributes { get; set; }
}