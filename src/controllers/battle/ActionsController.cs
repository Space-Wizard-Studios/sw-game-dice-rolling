using Godot;
using DiceRolling.Characters;
using System.Collections.Generic;
using System;
using DiceRolling.Helpers;

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
        ConnectEvents();
    }

    private void ConnectEvents() {
        DisconnectEvents();
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.PlayerActionDeclared), this, nameof(OnPlayerActionDeclared));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.PlayerTargetSelected), this, nameof(OnPlayerTargetSelected));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.PlayerActionCancelled), this, nameof(OnPlayerActionCancelled));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.EnemyActionDeclared), this, nameof(OnEnemyActionDeclared));
    }

    private void DisconnectEvents() {
        if (BattleEvents.Instance != null) {
            SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.PlayerActionDeclared), this, nameof(OnPlayerActionDeclared));
            SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.PlayerTargetSelected), this, nameof(OnPlayerTargetSelected));
            SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.PlayerActionCancelled), this, nameof(OnPlayerActionCancelled));
            SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.EnemyActionDeclared), this, nameof(OnEnemyActionDeclared));
        }
    }

    public void StartActionsDeclaration(List<CharacterType> playerTeam, List<CharacterType> enemyTeam) {
        GD.PrintRich("[color=cyan]ActionsController: Starting actions declaration phase...[/color]");

        _playerTeam = playerTeam;
        _enemyTeam = enemyTeam;
        _charactersDeclaredActions.Clear();

        GD.PrintRich($"[color=cyan]ActionsController: Using teams - Players: {_playerTeam.Count}, Enemies: {_enemyTeam.Count}.[/color]");

        DeclareEnemyActionsForTesting();
        DeclarePlayerActionsForTesting();
    }

    // TODO - for testing purposes, simple logic for declaring enemy actions
    private void DeclareEnemyActionsForTesting() {
        GD.PrintRich("[color=cyan]ActionsController: Declaring enemy actions for testing...[/color]");

        // Declare actions for each enemy
        foreach (var enemy in _enemyTeam) {
            if (enemy.Actions.Count > 0 && _playerTeam.Count > 0) {
                // Select random action and target
                var actionIndex = GD.RandRange(0, enemy.Actions.Count - 1);
                var targetIndex = GD.RandRange(0, _playerTeam.Count - 1);

                var action = enemy.Actions[actionIndex];
                var target = _playerTeam[targetIndex];

                BattleEvents.Instance.EmitEnemyActionDeclared(enemy);

                GD.PrintRich($"[color=cyan]Enemy {enemy.Name} selected action {action.Type?.Name} targeting {target.Name}.[/color]");
                GD.PrintRich("[color=cyan]======[/color]");
            }
            else {
                GD.PrintRich($"[color=cyan]Enemy {enemy.Name} has no actions or no valid targets.[/color]");
            }
        }
    }

    // TODO - for testing purposes, simple logic for declaring player actions
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

                // BattleEvents.Instance.EmitPlayerTargetSelected(player, target);
                // BattleEvents.Instance.EmitPlayerActionCancelled(player);
                BattleEvents.Instance.EmitPlayerActionDeclared(player);

                GD.PrintRich($"[color=cyan]Player {player.Name} selected action {action.Type?.Name} targeting {target.Name}.[/color]");
                GD.PrintRich("[color=cyan]======[/color]");
            }
            else {
                GD.PrintRich($"[color=cyan]Player {player.Name} has no actions or no valid targets.[/color]");
            }
        }
    }

    private bool AllActionsAreDeclared() {
        GD.PrintRich("[color=cyan]ActionsController: Checking if all actions are declared...[/color]");

        int totalCharacters = _playerTeam.Count + _enemyTeam.Count;

        GD.PrintRich($"[color=cyan]ActionsController: {_charactersDeclaredActions.Count}/{totalCharacters} actions declared.[/color]");

        return _charactersDeclaredActions.Count >= totalCharacters;
    }

    private static void CompleteActionsDeclaration() {
        GD.PrintRich("[color=cyan]ActionsController: Completing actions declaration phase...[/color]");
        BattleEvents.Instance.EmitActionsDeclared();
    }

    private void OnEnemyActionDeclared(CharacterType character) {
        GD.PrintRich($"[color=cyan]Enemy {character.Name} declared an action.[/color]");
        _charactersDeclaredActions.Add(character);
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionDeclared(CharacterType character) {
        GD.PrintRich("[color=cyan]Event PlayerActionDeclared fired on ActionsController.[/color]");
        _charactersDeclaredActions.Add(character);
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerTargetSelected(CharacterType character, CharacterType target) {
        GD.PrintRich("[color=cyan]Event PlayerTargetSelected fired on ActionsController.[/color]");
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionCancelled(CharacterType character) {
        GD.PrintRich("[color=cyan]Event PlayerActionCancelled fired on ActionsController.[/color]");
        _charactersDeclaredActions.Remove(character);
        CheckIfAllActionsDeclared();
    }

    private void CheckIfAllActionsDeclared() {
        if (AllActionsAreDeclared()) {
            CallDeferred(nameof(CompleteActionsDeclaration));
        }
    }
}