using Godot;
using System.Collections.Generic;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Executa comandos de alto nível durante a batalha.
/// </summary>
/// <remarks>
/// O <c>BattleController</c> é responsável por gerenciar a execução de comandos de alto nível durante a batalha, como iniciar, pausar, continuar e finalizar a batalha.
///     <list type="table">
///         <listheader>
///             <term>Transições de estados</term>
///             <description>Principais transições de estado da batalha</description>
///         </listheader>
///         <item>- Início da batalha</item>
///         <item>- Pausa a batalha</item>
///         <item>- Continua a batalha</item>
///         <item>- Fim da batalha</item>
///     </list>
///     <list type="table">
///         <listheader>
///             <term>Phase 1: Preparação da batalha</term>
///             <description>Configuração inicial da batalha</description>
///         </listheader>
///         <item>- Geração de inimigos</item>
///         <item>- Posicionamento de personagens</item>
///         <item>- Inicialização da fila de iniciativa (<c>InitiativeController</c>)</item>
///         <item>- Transição para a fase de rounds (<c>RoundController</c>)</item>
///     </list>
/// </remarks>
public partial class BattleController : Node {
    private static BattleController? _instance;

    // Padrão Singleton
    public static BattleController Instance {
        get {
            if (_instance == null) {
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<BattleController>("/root/BattleManager");
                }
                _instance ??= new BattleController();
            }
            return _instance;
        }
    }

    // State management
    private BattleState _currentState = BattleState.Start;
    public BattleState CurrentState => _currentState;

    // Battle data
    private int _currentRound = 0;
    public int CurrentRound => _currentRound;
    private Godot.Collections.Array _playerTeam = [];
    private Godot.Collections.Array _enemyTeam = [];

    // Controllers
    private TurnController? _turnManager;
    private RoundController? _roundController;
    private ActionsController? _actionsController;
    private BattleResultsController? _battleResultsController;
    private PostBattleController? _postBattleController;

    public override void _Ready() {
        InitializeControllers();
        ConnectEvents();
    }

    private void InitializeControllers() {
        _turnManager = new TurnController();
        _roundController = new RoundController();
        _actionsController = new ActionsController();
        _battleResultsController = new BattleResultsController();
        _postBattleController = new PostBattleController();
    }

    private void ConnectEvents() {
        // Connect to battle system events
        BattleEvents.Instance.BattleStarted += OnBattleStarted;
        BattleEvents.Instance.BattleEnded += OnBattleEnded;
    }

    // Battle lifecycle methods

    /// Starts a new battle with the specified teams
    public void StartBattle(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) {
        // Setup battle data
        _playerTeam = playerTeam;
        _enemyTeam = enemyTeam;
        _currentRound = 0;

        // Set initial state and notify listeners
        SetBattleState(BattleState.Start);
        BattleEvents.Instance.EmitBattleStarted(playerTeam, enemyTeam);

        // Begin battle preparation phase
        StartBattlePreparation();
    }

    /// Pauses the current battle
    public void PauseBattle() {
        BattleEvents.Instance.EmitBattlePaused();
    }

    /// Resumes a paused battle
    public void ResumeBattle() {
        BattleEvents.Instance.EmitBattleResumed();
    }

    /// Updates the battle state
    public void SetBattleState(BattleState newState) {
        _currentState = newState;
    }

    /// Advances to the next round
    public void AdvanceRound() {
        _currentRound++;
    }

    // Battle preparation phase methods

    private void StartBattlePreparation() {
        GenerateEnemies();
    }

    private void GenerateEnemies() {

        // TODO: Implement enemy generation logic
        // This would be based on dungeon level, player team strength, etc.

        // Notify that enemies have been generated
        BattleEvents.Instance.EmitEnemiesGenerated(_enemyTeam);

        // Proceed to character positioning
        PositionCharacters();
    }

    private void PositionCharacters() {

        // TODO: Implement character positioning logic

        // Combine both teams for positioning
        var allCharacters = new Godot.Collections.Array();
        allCharacters.AddRange(_playerTeam);
        allCharacters.AddRange(_enemyTeam);

        // Notify that characters have been positioned
        BattleEvents.Instance.EmitCharactersPositioned(allCharacters);

        // Proceed to initiative queue setup
        SetupInitiativeQueue();
    }

    private void SetupInitiativeQueue() {

        // TurnManager will handle initiative setup through the CharactersPositioned event
    }

    /// Transitions from battle preparation to rounds phase
    public void TransitionToRounds() {
        BattleEvents.Instance.EmitTransitionedToRounds();
    }

    // Event handlers

    private void OnBattleStarted(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) {
        // Inicia a fase de preparação
        StartBattlePreparation();
    }

    private void OnBattleEnded(bool victory) {
        SetBattleState(BattleState.End);

        // Transition to post-battle phase
        if (victory) {
            PostBattleController.ShowVictoryScreen();
        }
        else {
            PostBattleController.ShowGameOverScreen();
        }
    }
}