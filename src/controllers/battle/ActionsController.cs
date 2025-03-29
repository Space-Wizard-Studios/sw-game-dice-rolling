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

    public ActionsController() {
        // Connect to action-related events
        BattleEvents.Instance.PlayerActionDeclared += OnPlayerActionDeclared;
        BattleEvents.Instance.PlayerTargetSelected += OnPlayerTargetSelected;
        BattleEvents.Instance.PlayerActionCancelled += OnPlayerActionCancelled;
        BattleEvents.Instance.EnemyActionDeclared += OnEnemyActionDeclared;
    }
    // Starts the action declaration phase
    public void StartActionsDeclaration(List<CharacterType> playerTeam, List<CharacterType> enemyTeam) {
        GD.Print("ActionsController: Starting actions declaration phase...");

        // Use the teams provided directly
        _playerTeam = playerTeam;
        _enemyTeam = enemyTeam;
        _charactersDeclaredActions.Clear();

        GD.Print($"ActionsController: Using teams - Players: {_playerTeam.Count}, Enemies: {_enemyTeam.Count}");

        // Declare enemy actions first
        DeclareEnemyActions();

        // For testing, declaring player actions automatically:
        DeclarePlayerActionsForTesting();
    }


    // Handles enemy action declaration using AI
    private void DeclareEnemyActions() {
        GD.Print("ActionsController: Declaring enemy actions...");

        // Declare actions for each enemy
        foreach (var enemy in _enemyTeam) {
            if (enemy.Actions.Count > 0 && _playerTeam.Count > 0) {
                // Select random action and target
                var actionIndex = GD.RandRange(0, enemy.Actions.Count - 1);
                var targetIndex = GD.RandRange(0, _playerTeam.Count - 1);

                var action = enemy.Actions[actionIndex];
                var target = _playerTeam[targetIndex];

                GD.Print($"Enemy {enemy.Name} selected action {action.Type?.Name} targeting {target.Name}");

                // Emit event
                BattleEvents.Instance.EmitEnemyActionDeclared(enemy);
            }
            else {
                GD.Print($"Enemy {enemy.Name} has no actions or no valid targets.");
            }
        }
    }


    /// For testing purposes, declare actions for player characters
    private void DeclarePlayerActionsForTesting() {
        GD.Print("ActionsController: Declaring player actions for testing...");

        // Declare actions for each player
        foreach (var player in _playerTeam) {
            if (player.Actions.Count > 0 && _enemyTeam.Count > 0) {
                // Select random action and target
                var actionIndex = GD.RandRange(0, player.Actions.Count - 1);
                var targetIndex = GD.RandRange(0, _enemyTeam.Count - 1);

                var action = player.Actions[actionIndex];
                var target = _enemyTeam[targetIndex];

                GD.Print($"Player {player.Name} selected action {action.Type?.Name} targeting {target.Name}");

                // Emit events
                BattleEvents.Instance.EmitPlayerActionDeclared(player);
                BattleEvents.Instance.EmitPlayerTargetSelected(player, target);
            }
            else {
                GD.Print($"Player {player.Name} has no actions or no valid targets.");
            }
        }
    }

    // Checks if all characters have declared their actions
    private bool AllActionsAreDeclared() {
        GD.Print("ActionsController: Checking if all actions are declared...");

        // Calculate total characters from both teams
        int totalCharacters = _playerTeam.Count + _enemyTeam.Count;

        GD.Print($"ActionsController: {_charactersDeclaredActions.Count}/{totalCharacters} actions declared");

        return _charactersDeclaredActions.Count >= totalCharacters;
    }

    // Completes the action declaration phase
    private static void CompleteActionsDeclaration() {
        GD.Print("ActionsController: Completing actions declaration phase...");
        // Notify that all actions have been declared
        BattleEvents.Instance.EmitActionsDeclared();

        // Turn resolution will be initiated by the TurnManager's event handler
    }

    // Event handlers

    private void OnEnemyActionDeclared(CharacterType character) {
        GD.Print($"Enemy {character.Name} declared an action");
        _charactersDeclaredActions.Add(character);
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionDeclared(CharacterType character) {
        GD.Print("Event PlayerActionDeclared fired on ActionsController");
        _charactersDeclaredActions.Add(character);
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerTargetSelected(CharacterType character, CharacterType target) {
        GD.Print("Event PlayerTargetSelected fired on ActionsController");
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionCancelled(CharacterType character) {
        GD.Print("Event PlayerActionCancelled fired on ActionsController");
        // TODO: Handle action cancellation
    }

    private void CheckIfAllActionsDeclared() {
        if (AllActionsAreDeclared()) {
            CompleteActionsDeclaration();
        }
    }
}