using Godot;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia a declaração de ações dos personagens durante a batalha.
/// </summary>
/// <remarks>
/// O <c>ActionsController</c> é responsável por coordenar o momento em que personagens e inimigos escolhem suas ações antes da execução dos turnos.
///     <list type="table">
///         <listheader>
///             <term>Declaração de ações</term>
///             <description>Processo de escolha e preparação das ações</description>
///         </listheader>
///         <item>- Gerencia a declaração das ações dos inimigos</item>
///         <item>- Gerencia a rolagem de dados para coleta de energia dos personagens</item>
///         <item>- Recebe comandos de declaração de ações dos personagens dos jogadores</item>
///     </list>
/// </remarks>
public partial class ActionsController : RefCounted {
    public ActionsController() {
        // Connect to events
        BattleEvents.Instance.PlayerActionDeclared += OnPlayerActionDeclared;
        BattleEvents.Instance.PlayerTargetSelected += OnPlayerTargetSelected;
        BattleEvents.Instance.PlayerActionCancelled += OnPlayerActionCancelled;
    }

    /// <summary>
    /// Starts the action declaration phase
    /// </summary>
    public static void StartActionsDeclaration() {
        // Declare enemy actions first
        DeclareEnemyActions();

        // Player actions will be declared asynchronously through the UI
        // The phase will complete when all characters have declared actions
    }

    /// <summary>
    /// Handles enemy action declaration using AI
    /// </summary>
    private static void DeclareEnemyActions() {
        // TODO: Implement AI logic to determine enemy actions
        // For each enemy:
        //   - Choose the best action based on the current situation
        //   - Choose the best target
        //   - Emit EnemyActionDeclared event
    }

    /// <summary>
    /// Checks if all characters have declared their actions
    /// </summary>
    private static bool AllActionsAreDeclared() {
        // TODO: Implement logic to check if all characters have declared actions
        return false; // Placeholder
    }

    /// <summary>
    /// Completes the action declaration phase
    /// </summary>
    private static void CompleteActionsDeclaration() {
        // Notify that all actions have been declared
        BattleEvents.Instance.EmitActionsDeclared();

        // Turn resolution will be initiated by the TurnManager's event handler
    }

    // Event handlers

    private void OnPlayerActionDeclared(CharacterType character) {
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerTargetSelected(CharacterType character, CharacterType target) {
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionCancelled(CharacterType character) {
        // TODO: Handle action cancellation
    }

    private static void CheckIfAllActionsDeclared() {
        if (AllActionsAreDeclared()) {
            CompleteActionsDeclaration();
        }
    }
}