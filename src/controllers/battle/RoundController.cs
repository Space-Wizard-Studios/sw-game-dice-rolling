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
    private ActionsController _actionsController;
    private TurnController _turnController;

    public RoundController(ActionsController actionsController, TurnController turnController) {
        // Conecta-se aos eventos necessários
        BattleEvents.Instance.TransitionedToRounds += OnTransitionedToRounds;
        BattleEvents.Instance.TurnsResolved += OnTurnsResolved;

        // Use the provided controllers instead of creating new ones
        _actionsController = actionsController;
        _turnController = turnController;
    }

    // Inicia um novo round
    public void StartRound() {
        // Incrementa o contador de rounds
        BattleController.Instance.AdvanceRound();

        // Atualiza o estado da batalha
        BattleController.Instance.SetRoundState(RoundState.RoundStart);

        // Notifica o início do round
        BattleEvents.Instance.EmitRoundStarted(BattleController.Instance.CurrentRound);

        // Passa para a fase de declaração de ações
        StartActionsDeclarationPhase();
    }

    // Inicia a fase de declaração de ações
    private void StartActionsDeclarationPhase() {
        BattleController.Instance.SetRoundState(RoundState.ActionsDeclaration);

        // Delega a declaração de ações para o ActionsController
        ActionsController.StartActionsDeclaration();
    }

    // Inicia a fase de resolução de turnos
    public void StartTurnsResolutionPhase() {
        BattleController.Instance.SetRoundState(RoundState.TurnsResolution);

        // Delega a resolução de turnos para o TurnController
        _turnController.StartTurnsResolution();
    }

    // Finaliza o round atual
    public void EndRound() {
        BattleController.Instance.SetRoundState(RoundState.RoundEnd);

        // Notifica o fim do round
        BattleEvents.Instance.EmitRoundEnded(BattleController.Instance.CurrentRound);

        // Verifica se deve iniciar um novo round ou terminar a batalha
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
        GD.Print("Event TransitionedToRounds fired on RoundController");
        StartRound();
    }

    private void OnTurnsResolved() {
        GD.Print("Event TurnsResolved fired on RoundController");
        EndRound();
    }
}