using Godot;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia o fluxo de rounds da batalha.
/// </summary>
/// <remarks>
/// O <c>RoundController</c> é responsável por coordenar a progressão da batalha, garantindo que cada round siga a sequência correta de fases.
///     <list type="table">
///         <listheader>
///             <term>Phase 2: Gestão dos rounds</term>
///             <description>Controle do início, progresso e término dos rounds</description>
///         </listheader>
///         <item>- Inicia um novo round</item>
///         <item>- Inicia a fase de declaração de ações (<c>ActionsController</c>)</item>
///         <item>- Inicia a fase de resolução de turnos (<c>TurnController</c>)</item>
///         <item>- Finaliza o round</item>
///         <item>- Verifica o estado da batalha para decidir se deve continuar ou terminar</item>
///     </list>
/// </remarks>
public partial class RoundController : RefCounted {
    private ActionsController? _actionsController;
    private TurnController? _turnController;
    private RoundState _currentRoundState = RoundState.RoundStart;
    private int _currentRound = 0;
    public RoundState CurrentRoundState => _currentRoundState;
    public int CurrentRound => _currentRound;

    public RoundController() {
        ConnectEvents();
    }

    public RoundController(ActionsController actionsController, TurnController turnController) {
        _actionsController = actionsController;
        _turnController = turnController;

        ConnectEvents();
    }

    private void ConnectEvents() {
        DisconnectEvents();
        BattleEvents.Instance.TransitionedToRounds += OnTransitionedToRounds;
        BattleEvents.Instance.TurnsResolved += OnTurnsResolved;
    }

    private void DisconnectEvents() {
        if (BattleEvents.Instance != null) {
            BattleEvents.Instance.TransitionedToRounds -= OnTransitionedToRounds;
            BattleEvents.Instance.TurnsResolved -= OnTurnsResolved;
        }
    }

    private void SetRoundState(RoundState newState) {
        GD.PrintRich($"[color=violet]Round state changing: {_currentRoundState} -> {newState}.[/color]");
        _currentRoundState = newState;
    }

    private void AdvanceRound() {
        _currentRound++;
        GD.PrintRich($"[color=violet]RoundController: Advanced to round {_currentRound}.[/color]");
    }

    public void StartRound() {
        if (_actionsController == null || _turnController == null) {
            GD.PrintErr("RoundController: Controllers not initialized!");
            return;
        }

        GD.Print("[color=violet]RoundController: Starting a new round...[/color]");

        SetRoundState(RoundState.RoundStart);

        AdvanceRound();

        BattleEvents.Instance.EmitRoundStarted(_currentRound);

        StartActionsDeclarationPhase();
    }

    private void StartActionsDeclarationPhase() {
        if (_actionsController == null) {
            GD.PrintErr("RoundController: ActionsController not initialized!");
            return;
        }

        GD.PrintRich("[color=violet]RoundController: Starting actions declaration phase...[/color]");

        SetRoundState(RoundState.ActionsDeclaration);

        var playerTeam = BattleController.Instance.GetPlayerTeam();
        var enemyTeam = BattleController.Instance.GetEnemyTeam();
        _actionsController.StartActionsDeclaration(playerTeam, enemyTeam);
    }

    public void StartTurnsResolutionPhase() {
        if (_turnController == null) {
            GD.PrintErr("RoundController: TurnController not initialized!");
            return;
        }

        GD.PrintRich("[color=violet]RoundController: Starting turns resolution phase...[/color].");

        SetRoundState(RoundState.TurnsResolution);

        _turnController.StartTurnsResolution();
    }

    // Finaliza o round atual
    public void EndRound() {
        GD.PrintRich("[color=violet]RoundController: Ending the current round...[/color]");

        SetRoundState(RoundState.RoundEnd);

        BattleEvents.Instance.EmitRoundEnded(_currentRound);

        CheckBattleState();
    }

    // ? Deve ser feito aqui, no TurnController ou em outro lugar?
    // Verifica o estado da batalha para decidir se deve continuar ou terminar
    // Verifica se um novo turno deve começar ou se a rodada deve terminar
    // Verifica se uma nova rodada deve começar ou se a batalha deve terminar
    private void CheckBattleState() {
        // TODO
        // Implementar a lógica para verificar o estado atual da batalha
        // Por exemplo, verificando se ambas equipes ainda têm personagens vivos

        // Se a batalha deve continuar, inicia um novo round
        StartRound();

        // TODO
        // Se a batalha deve terminar, delega para o BattleResultsController
    }

    // Eventos
    private void OnTransitionedToRounds(int number) {
        GD.PrintRich("[color=violet]Event TransitionedToRounds fired on RoundController.[/color]");
        StartRound();
    }

    private void OnTurnsResolved() {
        GD.PrintRich("[color=violet]Event TurnsResolved fired on RoundController.[/color]");
        EndRound();
    }
}