using Godot;
using DiceRolling.Characters;
using DiceRolling.Entities;
using DiceRolling.Grids;
using System.Linq;
using DiceRolling.Stores;
using DiceRolling.Locations;
using System;
using DiceRolling.Helpers;

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
[Tool]
[GlobalClass]
[Icon("res://assets/editor/controller.svg")]
public partial class BattleController : Node {
    private static BattleController? _instance;

    // Singleton pattern
    public static BattleController Instance {
        get {
            if (_instance == null) {
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<BattleController>("/root/BattleController");
                }
                _instance ??= new BattleController();
            }
            return _instance;
        }
    }

    [Export] public CharacterStore? PlayerCharacterStore { get; set; }
    [Export] public CharacterStore? EnemyCharacterStore { get; set; }
    [Export] public LocationType? PlayerSquadLocation { get; set; }
    [Export] public LocationType? EnemySquadLocation { get; set; }
    [Export] public PackedScene? GridEntityScene { get; set; }
    [Export(PropertyHint.Range, "-10,10,1")] public Vector3 PlayerGridPosition { get; set; } = new Vector3(-3, 0, 0);
    [Export(PropertyHint.Range, "-10,10,1")] public Vector3 EnemyGridPosition { get; set; } = new Vector3(3, 0, 0);
    private GridEntity? _playerGridEntity;
    private GridEntity? _enemyGridEntity;
    [ExportToolButton("Recreate Grids")]
    public Callable RecreateGrids => Callable.From(() => {
        // Clean up existing grids
        if (_playerGridEntity != null) {
            _playerGridEntity.QueueFree();
            _playerGridEntity = null;
        }

        if (_enemyGridEntity != null) {
            _enemyGridEntity.QueueFree();
            _enemyGridEntity = null;
        }

        // Create new grids
        CreateBattleGrids();
        GD.Print("Battle grids recreated");
    });

    // State management
    private BattleState _currentState = BattleState.Start;
    public BattleState CurrentState => _currentState;
    private RoundState _currentRoundState = RoundState.RoundStart;
    public RoundState CurrentRoundState => _currentRoundState;

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

        // Initialize with characters from stores if available
        if (PlayerCharacterStore?.Characters != null && PlayerSquadLocation != null) {
            var playerChars = PlayerCharacterStore.Characters.Where(c =>
                c != null && c.Location == PlayerSquadLocation).ToArray();
            _playerTeam = new Godot.Collections.Array(playerChars);
        }

        if (EnemyCharacterStore?.Characters != null && EnemySquadLocation != null) {
            var enemyChars = EnemyCharacterStore.Characters.Where(c =>
                c != null && c.Location == EnemySquadLocation).ToArray();
            _enemyTeam = new Godot.Collections.Array(enemyChars);
        }


        // TESTING
        StartBattle();

    }

    public override void _ExitTree() {
        base._ExitTree();
        DisconnectEvents();
    }

    public override void _Process(double delta) {
        base._Process(delta);
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
        // SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.BattleStarted), this, nameof(OnBattleStarted));
        SignalHelper.ConnectSignal(BattleEvents.Instance, nameof(BattleEvents.BattleEnded), this, nameof(OnBattleEnded));
    }

    private void DisconnectEvents() {
        // SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.BattleStarted), this, nameof(OnBattleStarted));
        SignalHelper.DisconnectSignal(BattleEvents.Instance, nameof(BattleEvents.BattleEnded), this, nameof(OnBattleEnded));
    }

    // Battle lifecycle methods

    // Starts a new battle with the specified teams
    public void StartBattle(Godot.Collections.Array? playerTeam = null, Godot.Collections.Array? enemyTeam = null) {
        GD.Print("Starting battle...");
        // Setup battle data using provided teams or fall back to exported characters
        _playerTeam = playerTeam ?? _playerTeam;
        _enemyTeam = enemyTeam ?? _enemyTeam;
        _currentRound = 0;

        BattleEvents.Instance.EmitBattleStarted(_playerTeam, _enemyTeam);

        // Begin battle preparation phase
        StartBattlePreparation();
    }

    // Pauses the current battle
    public static void PauseBattle() {
        BattleEvents.Instance.EmitBattlePaused();
    }

    // Resumes a paused battle
    public static void ResumeBattle() {
        BattleEvents.Instance.EmitBattleResumed();
    }

    // Updates the battle state
    public void SetBattleState(BattleState newState) {
        GD.Print($"Battle state changing: {_currentState} -> {newState}");
        _currentState = newState;
    }

    // Updates the round state
    public void SetRoundState(RoundState newState) {
        GD.Print($"Round state changing: {_currentRoundState} -> {newState}");
        _currentRoundState = newState;
    }

    // Advances to the next round
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

        GD.Print("Positioning characters...");
        CreateBattleGrids();

        // Utilizar o método AssignCharacters diretamente
        _playerGridEntity?.GridData?.AssignCharacters();
        _enemyGridEntity?.GridData?.AssignCharacters();

        // Combine both teams for positioning
        var allCharacters = new Godot.Collections.Array();
        allCharacters.AddRange(_playerTeam);
        allCharacters.AddRange(_enemyTeam);

        // Notify that characters have been positioned
        BattleEvents.Instance.EmitCharactersPositioned(allCharacters);

        // Proceed to initiative queue setup
        SetupInitiativeQueue();
    }

    private void CreateBattleGrids() {
        if (GridEntityScene == null) return;

        // Criar grids usando método auxiliar
        _playerGridEntity = CreateGrid(
            "P",
            PlayerGridPosition,
            PlayerCharacterStore
        );

        _enemyGridEntity = CreateGrid(
            "E",
            EnemyGridPosition,
            EnemyCharacterStore
        );
    }

    private GridEntity CreateGrid(string prefix, Vector3 position, CharacterStore? characterStore) {
        if (GridEntityScene == null)
            throw new InvalidOperationException("GridEntityScene is not assigned.");

        var gridEntity = GridEntityScene.Instantiate<GridEntity>();
        AddChild(gridEntity);
        gridEntity.Position = position;

        gridEntity.GridData = new GridType {
            Rows = 2,
            Columns = 3,
            Prefix = prefix,
            CharacterStore = characterStore
        };

        return gridEntity;
    }

    private static void SetupInitiativeQueue() {
        GD.Print("Setting up initiative queue...");
        // TurnManager will handle initiative setup through the CharactersPositioned event
    }

    // Transitions from battle preparation to rounds phase
    public static void TransitionToRounds() {
        Instance.SetBattleState(BattleState.InProgress);
        BattleEvents.Instance.EmitTransitionedToRounds();
    }

    // Event handlers

    private void OnBattleStarted(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) {
        SetBattleState(BattleState.InProgress);
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