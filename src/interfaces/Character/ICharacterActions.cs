using System.Collections.Generic;
using DiceRolling.Models.Actions;

namespace DiceRolling.Interfaces.Character;
/// <summary>
/// Interface que define as ações de um personagem no jogo.
/// </summary>
public interface ICharacterActions {
    /// <summary>
    /// Lista de ações do personagem.
    /// </summary>
    List<CharacterAction> Actions { get; }

    /// <summary>
    /// Inicializa as ações do personagem.
    /// </summary>
    void InitializeActions();

    /// <summary>
    /// Adiciona uma nova ação ao personagem.
    /// </summary>
    /// <param name="action">Ação a ser adicionada.</param>
    void AddAction(CharacterAction action);

    /// <summary>
    /// Remove uma ação do personagem.
    /// </summary>
    /// <param name="action">Ação a ser removida.</param>
    void RemoveAction(CharacterAction action);
}
