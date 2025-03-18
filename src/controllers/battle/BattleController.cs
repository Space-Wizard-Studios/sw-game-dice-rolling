using Godot;
using System.Collections.Generic;
using System.Linq;

using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia o estado geral da batalha e as transições entre as diferentes fases.
/// </summary>
public partial class BattleController : RefCounted {
    public BattleState CurrentState { get; private set; } = BattleState.Preparation;
    private List<CharacterType> _playerTeam = [];
    private List<CharacterType> _enemyTeam = [];

    // Eventos
    [Signal] public delegate void PreparationPhaseStartedEventHandler();
    [Signal] public delegate void ActionPhaseStartedEventHandler();
    [Signal] public delegate void ExecutionPhaseStartedEventHandler();
    [Signal] public delegate void BattleEndedEventHandler(bool isVictory);
    [Signal] public delegate void RoundStartedEventHandler(int roundNumber);

    // Rastreamento da rodada atual
    private int _currentRound = 0;

    public void StartBattle(List<CharacterType> playerTeam, List<CharacterType> enemyTeam, InitiativeController initiativeController) {
        _playerTeam = [.. playerTeam];
        _enemyTeam = [.. enemyTeam];
        _currentRound = 0;

        CurrentState = BattleState.Preparation;

        BattleEvents.Instance.EmitPreparationPhaseStarted();

        var allCharacters = new List<CharacterType>();
        allCharacters.AddRange(playerTeam);
        allCharacters.AddRange(enemyTeam);
        initiativeController.SetupInitiative(allCharacters);

        StartNewRound();
    }

    public void StartNewRound() {
        if (CurrentState == BattleState.Paused)
            return;

        _currentRound++;

        BattleEvents.Instance.EmitRoundStarted(_currentRound);

        // Iniciar fase de declaração de ações
        StartActionDeclarationPhase();
    }

    public void StartActionDeclarationPhase() {
        if (CurrentState == BattleState.Paused)
            return;

        CurrentState = BattleState.ActionDeclaration;

        BattleEvents.Instance.EmitActionPhaseStarted();
    }

    public void StartTurnExecutionPhase() {
        if (CurrentState == BattleState.Paused)
            return;

        CurrentState = BattleState.TurnExecution;

        BattleEvents.Instance.EmitExecutionPhaseStarted();
    }

    public void EndRound() {
        if (IsTeamDefeated(_playerTeam)) {
            EndBattle(false);
            return;
        }

        if (IsTeamDefeated(_enemyTeam)) {
            EndBattle(true);
            return;
        }

        BattleEvents.Instance.EmitRoundEnded(_currentRound);

        StartNewRound();
    }

    public void PauseBattle() {
        CurrentState = BattleState.Paused;
    }

    public void ResumeBattle() {
        // Retomar o estado anterior
        switch (CurrentState) {
            case BattleState.ActionDeclaration:
                StartActionDeclarationPhase();
                break;
            case BattleState.TurnExecution:
                StartTurnExecutionPhase();
                break;
            default:
                // Caso esteja em outro estado, reiniciar rodada
                StartNewRound();
                break;
        }
    }

    public void EndBattle(bool isPlayerVictory) {
        CurrentState = BattleState.BattleEnd;

        BattleEvents.Instance.EmitBattleEnded(isPlayerVictory);
    }

    private static bool IsTeamDefeated(List<CharacterType> team) {
        // Uma equipe é derrotada quando todos os membros estão com HP igual a 0
        return team.All(character => IsCharacterDefeated(character));
    }

    private static bool IsCharacterDefeated(CharacterType character) {
        // Verificar se o personagem está com HP zerado
        var hpAttribute = character.Attributes.FirstOrDefault(attr => attr.Type?.Name == "HP");
        return hpAttribute != null && hpAttribute.CurrentValue <= 0;
    }
}