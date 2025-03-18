using Godot;
using System.Collections.Generic;

using DiceRolling.Characters;
using DiceRolling.Helpers;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia o fluxo da batalha e coordena os diferentes controladores relacionados.
/// </summary>
public partial class BattleManager : Node3D {
    private BattleController? _battleController;
    private InitiativeController? _initiativeController;
    private TurnController? _turnController;

    public override void _Ready() {
        // Inicializar controladores
        _initiativeController = new InitiativeController();
        _battleController = new BattleController();
        _turnController = new TurnController(_initiativeController);

        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.ActionPhaseStarted), this, nameof(OnActionPhaseStarted));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.ExecutionPhaseStarted), this, nameof(OnExecutionPhaseStarted));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.AllTurnsCompleted), this, nameof(OnAllTurnsCompleted));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.BattleEnded), this, nameof(OnBattleEnded));
    }

    public override void _ExitTree() {
        base._ExitTree();

        SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.ActionPhaseStarted), this, nameof(OnActionPhaseStarted));
        SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.ExecutionPhaseStarted), this, nameof(OnExecutionPhaseStarted));
        SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.AllTurnsCompleted), this, nameof(OnAllTurnsCompleted));
        SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.BattleEnded), this, nameof(OnBattleEnded));
    }


    public InitiativeController? GetInitiativeController() {
        return _initiativeController;
    }

    public void StartBattle(List<CharacterType> playerTeam, List<CharacterType> enemyTeam) {
        if (_battleController == null || _initiativeController == null) return;

        GD.Print("Battle has begun!");

        // Inicializar a batalha através do controlador
        _battleController.StartBattle(playerTeam, enemyTeam, _initiativeController);

        var playerArray = new Godot.Collections.Array();
        var enemyArray = new Godot.Collections.Array();

        foreach (var player in playerTeam) playerArray.Add(player);
        foreach (var enemy in enemyTeam) enemyArray.Add(enemy);

        BattleEvents.Instance.EmitBattleStarted(playerArray, enemyArray);
    }

    public void PauseBattle() {
        if (_battleController == null || _turnController == null) return;

        _battleController.PauseBattle();
        _turnController.PauseTurns();

        BattleEvents.Instance.EmitBattlePaused();

        GD.Print("Battle paused.");
    }

    public void ResumeBattle() {
        if (_battleController == null || _turnController == null) return;

        _battleController.ResumeBattle();
        _turnController.ResumeTurns();

        BattleEvents.Instance.EmitBattleResumed();

        GD.Print("Battle resumed.");
    }

    public void EndBattle(bool isPlayerVictory) {
        if (_battleController == null) return;

        _battleController.EndBattle(isPlayerVictory);

        BattleEvents.Instance.EmitBattleEnded(isPlayerVictory);

        GD.Print($"Battle ended with {(isPlayerVictory ? "Victory" : "Defeat")}!");
    }

    // Event handlers

    private static void OnActionPhaseStarted() {
        GD.Print("Action Declaration phase has started.");
    }

    private void OnExecutionPhaseStarted() {
        if (_turnController == null) return;

        GD.Print("Turn Execution phase has started.");
        _turnController.StartTurns();
    }

    private void OnAllTurnsCompleted() {
        if (_battleController == null) return;

        _battleController.EndRound();

        GD.Print("Turn Execution phase has ended.");
    }

    private static void OnBattleEnded(bool isVictory) {
        GD.Print($"Battle ended with {(isVictory ? "Victory" : "Defeat")}!");
    }
}