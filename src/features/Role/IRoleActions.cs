using Godot.Collections;
using DiceRolling.Models.Actions;

namespace DiceRolling.Interfaces.Role;

/// <summary>
/// Interface que define as ações de um arquétipo de personagem no jogo.
/// </summary>
public interface IRoleActions {
    /// <summary>
    /// Lista de ações do arquétipo de personagem.
    /// </summary>
    Godot.Collections.Array<RoleAction> RoleActions { get; set; }
}