using Godot;
using System.Collections.Generic;

using DiceRolling.Controllers;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia o fluxo da batalha, controlando as transições entre estados
/// e orquestrando os diferentes controladores.
/// </summary>
public partial class BattleManager : Node {
    private static BattleManager? _instance;

    public static BattleManager Instance {
        get {
            if (_instance == null) {
                // Try to get from the scene tree first
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<BattleManager>("/root/BattleManager");
                }

                // If not found, create a new instance
                _instance ??= new BattleManager();
            }
            return _instance;
        }
    }

    // Estado atual da batalha
    private BattleState _currentState = BattleState.Start;
    public BattleState CurrentState => _currentState;

    // Número do round atual
    private int _currentRound = 0;
    public int CurrentRound => _currentRound;

    // Equipes na batalha
    private Godot.Collections.Array _playerTeam = [];
    private Godot.Collections.Array _enemyTeam = [];

    // Controllers da batalha

    private BattleController? _battleController;
    private InitiativeController? _initiativeController;
    private RoundController? _roundController;
    private ActionsController? _actionsController;
    private TurnController? _turnController;
    private BattleResultsController? _battleResultsController;
    private PostBattleController? _postBattleController;

    public override void _Ready() {
        // Inicializa os controladores
        InitializeControllers();

        // Conecta aos eventos
        ConnectEvents();
    }

    private void InitializeControllers() {
        _battleController = new BattleController();
        _initiativeController = new InitiativeController();
        _roundController = new RoundController();
        _actionsController = new ActionsController();
        _turnController = new TurnController();
        _battleResultsController = new BattleResultsController();
        _postBattleController = new PostBattleController();
    }

    private void ConnectEvents() {
        // Conecta aos eventos do sistema de batalha
        BattleEvents.Instance.BattleStarted += OnBattleStarted;
        BattleEvents.Instance.BattleEnded += OnBattleEnded;
    }

    // Inicia a batalha com as equipes fornecidas
    public void SetupBattle(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) {
        _playerTeam = playerTeam;
        _enemyTeam = enemyTeam;
        _currentRound = 0;
    }

    // Atualiza o estado da batalha
    public void SetBattleState(BattleState newState) {
        _currentState = newState;
    }

    // Evento: Quando a batalha é iniciada
    private void OnBattleStarted(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) {
        // Inicia a fase de preparação
        SetBattleState(BattleState.EnemiesGeneration);
        _battleController?.StartBattlePreparation();
    }

    // Evento: Quando a batalha termina
    private void OnBattleEnded(bool victory) {
        SetBattleState(BattleState.End);
        // Transição para fase de pós-batalha
        if (victory) {
            SetBattleState(BattleState.RewardsDistribution);
            PostBattleController.ShowVictoryScreen();
        }
        else {
            SetBattleState(BattleState.GameOver);
            PostBattleController.ShowGameOverScreen();
        }
    }

    public void AdvanceRound() {
        _currentRound++;
    }
}