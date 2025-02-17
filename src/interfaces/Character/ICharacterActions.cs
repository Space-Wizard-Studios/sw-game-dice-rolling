using Godot;
using DiceRolling.Models.Actions;

namespace DiceRolling.Interfaces.Character;
/// <summary>
/// Interface que define as ações de um personagem no jogo.
/// </summary>
public interface ICharacterActions {
    /// <summary>
    /// Lista de ações da personagem.
    /// </summary>
    Godot.Collections.Array<CharacterAction> Actions { get; }

    /// <summary>
    /// Inicializa as ações da personagem.
    /// </summary>
    void InitializeActions();

    /// <summary>
    /// Adiciona uma nova ação à personagem.
    /// </summary>
    /// <param name="action">Ação a ser adicionada.</param>
    void AddAction(CharacterAction action);

    /// <summary>
    /// Remove uma ação da personagem.
    /// </summary>
    /// <param name="action">Ação a ser removida.</param>
    void RemoveAction(CharacterAction action);
}
