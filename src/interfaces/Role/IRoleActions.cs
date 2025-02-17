using Godot;
using DiceRolling.Models.Actions;

namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define as ações de um papel no jogo.
/// </summary>
public interface IRoleActions {
    /// <summary>
    /// Lista de ações do papel.
    /// </summary>
    Godot.Collections.Array<RoleAction> RoleActions { get; set; }
}