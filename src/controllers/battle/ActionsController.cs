using Godot;
using DiceRolling.Characters;
using System.Collections.Generic;

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
    private readonly HashSet<CharacterType> _charactersDeclaredActions = [];
    private List<CharacterType> _playerTeam = [];
    private List<CharacterType> _enemyTeam = [];
    private bool _isInActionDeclarationPhase = false;

    public ActionsController() {
        // Connect to action-related events
        BattleEvents.Instance.PlayerActionDeclared += OnPlayerActionDeclared;
        BattleEvents.Instance.PlayerTargetSelected += OnPlayerTargetSelected;
        BattleEvents.Instance.PlayerActionCancelled += OnPlayerActionCancelled;
        BattleEvents.Instance.EnemyActionDeclared += OnEnemyActionDeclared;
        BattleEvents.Instance.ActionsDeclared += OnActionsDeclared;
    }

    // Starts the action declaration phase
    public void StartActionsDeclaration(List<CharacterType> playerTeam, List<CharacterType> enemyTeam) {
        GD.PrintRich("[color=cyan]ActionsController: Starting actions declaration phase...[/color]");

        // Use the teams provided directly
        _playerTeam = playerTeam;
        _enemyTeam = enemyTeam;
        _charactersDeclaredActions.Clear();
        _isInActionDeclarationPhase = true;

        GD.PrintRich($"[color=cyan]ActionsController: Using teams - Players: {_playerTeam.Count}, Enemies: {_enemyTeam.Count}.[/color]");

        // Declare enemy actions first
        DeclareEnemyActions();

        // For testing, declaring player actions automatically:
        DeclarePlayerActionsForTesting();
    }

    // Event handler when all actions are declared
    private void OnActionsDeclared() {
        // When ActionsDeclared is emitted, we're no longer in action declaration phase
        _isInActionDeclarationPhase = false;
    }

    // Handles enemy action declaration using AI
    private void DeclareEnemyActions() {
        GD.PrintRich("[color=cyan]ActionsController: Declaring enemy actions...[/color]");

        // Declare actions for each enemy
        foreach (var enemy in _enemyTeam) {
            if (enemy.Actions.Count > 0 && _playerTeam.Count > 0) {
                // Select random action and target
                var actionIndex = GD.RandRange(0, enemy.Actions.Count - 1);
                var targetIndex = GD.RandRange(0, _playerTeam.Count - 1);

                var action = enemy.Actions[actionIndex];
                var target = _playerTeam[targetIndex];

                GD.PrintRich($"[color=cyan]Enemy {enemy.Name} selected action {action.Type?.Name} targeting {target.Name}.[/color]");

                // Emit event
                BattleEvents.Instance.EmitEnemyActionDeclared(enemy);
            }
            else {
                GD.PrintRich($"[color=cyan]Enemy {enemy.Name} has no actions or no valid targets.[/color]");
            }
        }
    }


    // For testing purposes, declare actions for player characters
    private void DeclarePlayerActionsForTesting() {
        GD.PrintRich("[color=cyan]ActionsController: Declaring player actions for testing...[/color]");

        // Declare actions for each player
        foreach (var player in _playerTeam) {
            if (player.Actions.Count > 0 && _enemyTeam.Count > 0) {
                // Select random action and target
                var actionIndex = GD.RandRange(0, player.Actions.Count - 1);
                var targetIndex = GD.RandRange(0, _enemyTeam.Count - 1);

                var action = player.Actions[actionIndex];
                var target = _enemyTeam[targetIndex];

                GD.PrintRich($"[color=cyan]Player {player.Name} selected action {action.Type?.Name} targeting {target.Name}.[/color]");

                // Emit events
                BattleEvents.Instance.EmitPlayerActionDeclared(player);
                BattleEvents.Instance.EmitPlayerTargetSelected(player, target);
            }
            else {
                GD.PrintRich($"[color=cyan]Player {player.Name} has no actions or no valid targets.[/color]");
            }
        }
    }

    // Checks if all characters have declared their actions
    private bool AllActionsAreDeclared() {
        GD.PrintRich("[color=cyan]ActionsController: Checking if all actions are declared...[/color]");

        // Calculate total characters from both teams
        int totalCharacters = _playerTeam.Count + _enemyTeam.Count;

        GD.PrintRich($"[color=cyan]ActionsController: {_charactersDeclaredActions.Count}/{totalCharacters} actions declared.[/color]");

        return _charactersDeclaredActions.Count >= totalCharacters;
    }

    // Completes the action declaration phase
    private static void CompleteActionsDeclaration() {
        GD.PrintRich("[color=cyan]ActionsController: Completing actions declaration phase...[/color]");
        // Notify that all actions have been declared
        BattleEvents.Instance.EmitActionsDeclared();

        // Turn resolution will be initiated by the TurnManager's event handler
    }

    // Event handlers
    private void OnEnemyActionDeclared(CharacterType character) {
        if (!_isInActionDeclarationPhase) return;

        GD.PrintRich($"[color=cyan]Enemy {character.Name} declared an action.[/color]");
        _charactersDeclaredActions.Add(character);
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionDeclared(CharacterType character) {
        if (!_isInActionDeclarationPhase) return;

        GD.PrintRich("[color=cyan]Event PlayerActionDeclared fired on ActionsController.[/color]");
        _charactersDeclaredActions.Add(character);
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerTargetSelected(CharacterType character, CharacterType target) {
        if (!_isInActionDeclarationPhase) return;

        GD.PrintRich("[color=cyan]Event PlayerTargetSelected fired on ActionsController.[/color]");
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionCancelled(CharacterType character) {
        if (!_isInActionDeclarationPhase) return;

        GD.PrintRich("[color=cyan]Event PlayerActionCancelled fired on ActionsController.[/color]");
        // TODO: Handle action cancellation
    }

    private void CheckIfAllActionsDeclared() {
        if (AllActionsAreDeclared()) {
            CompleteActionsDeclaration();
        }
    }
}