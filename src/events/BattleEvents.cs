using Godot;
using DiceRolling.Characters;
using DiceRolling.Actions;

namespace DiceRolling.Controllers;

public partial class BattleEvents : Node {
    private static BattleEvents? _instance;

    public static BattleEvents Instance {
        get {
            if (_instance == null) {
                // Try to get from the scene tree first
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<BattleEvents>("/root/BattleEvents");
                }

                // If not found, create a new instance
                _instance ??= new BattleEvents();
            }
            return _instance;
        }
    }

    // Battle flow events
    [Signal] public delegate void BattleStartedEventHandler(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam);
    [Signal] public delegate void BattleEndedEventHandler(bool victory);
    [Signal] public delegate void BattlePausedEventHandler();
    [Signal] public delegate void BattleResumedEventHandler();
    [Signal] public delegate void RoundStartedEventHandler(int roundNumber);
    [Signal] public delegate void RoundEndedEventHandler(int roundNumber);

    // Phase events
    [Signal] public delegate void PreparationPhaseStartedEventHandler();
    [Signal] public delegate void ActionPhaseStartedEventHandler();
    [Signal] public delegate void ExecutionPhaseStartedEventHandler();

    // Turn events
    [Signal] public delegate void TurnStartedEventHandler(CharacterType character);
    [Signal] public delegate void TurnEndedEventHandler(CharacterType character);
    [Signal] public delegate void AllTurnsCompletedEventHandler();

    // Action events
    [Signal] public delegate void ActionDeclaredEventHandler(CharacterType character, ActionType action, CharacterType target);
    [Signal] public delegate void ActionExecutedEventHandler(CharacterType character, ActionType action, CharacterType target);
    [Signal] public delegate void ActionFailedEventHandler(CharacterType character, ActionType action, string reason);

    // Character events
    [Signal] public delegate void CharacterDefeatedEventHandler(CharacterType character);
    [Signal] public delegate void CharacterReviveEventHandler(CharacterType character);
    [Signal] public delegate void CharacterStatusChangedEventHandler(CharacterType character, string statusName, bool active);

    // Initiative events
    [Signal] public delegate void InitiativeQueueChangedEventHandler(Godot.Collections.Array queueAsArray);
    [Signal] public delegate void InitiativeValueChangedEventHandler(CharacterType character, int newValue);


    public override void _Ready() {
        if (_instance == null || _instance != this) {
            _instance = this;
        }
    }

    // Helper methods to emit common battle events
    public void EmitBattleStarted(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) =>
        EmitSignal(nameof(BattleStarted), playerTeam, enemyTeam);
    public void EmitBattleEnded(bool victory) => EmitSignal(nameof(BattleEnded), victory);
    public void EmitBattlePaused() => EmitSignal(nameof(BattlePaused));
    public void EmitBattleResumed() => EmitSignal(nameof(BattleResumed));
    public void EmitPreparationPhaseStarted() => EmitSignal(nameof(PreparationPhaseStarted));
    public void EmitActionPhaseStarted() => EmitSignal(nameof(ActionPhaseStarted));
    public void EmitExecutionPhaseStarted() => EmitSignal(nameof(ExecutionPhaseStarted));
    public void EmitRoundStarted(int roundNumber) => EmitSignal(nameof(RoundStarted), roundNumber);
    public void EmitRoundEnded(int roundNumber) => EmitSignal(nameof(RoundEnded), roundNumber);
    public void EmitTurnStarted(CharacterType character) => EmitSignal(nameof(TurnStarted), character);
    public void EmitTurnEnded(CharacterType character) => EmitSignal(nameof(TurnEnded), character);
    public void EmitAllTurnsCompleted() => EmitSignal(nameof(AllTurnsCompleted));
    public void EmitActionDeclared(CharacterType character, ActionType action, CharacterType target) =>
        EmitSignal(nameof(ActionDeclared), character, action, target);
    public void EmitActionExecuted(CharacterType character, ActionType action, CharacterType target) =>
        EmitSignal(nameof(ActionExecuted), character, action, target);
    public void EmitActionFailed(CharacterType character, ActionType action, string reason) =>
        EmitSignal(nameof(ActionFailed), character, action, reason);
    public void EmitCharacterDefeated(CharacterType character) => EmitSignal(nameof(CharacterDefeated), character);
    public void EmitCharacterRevive(CharacterType character) => EmitSignal(nameof(CharacterRevive), character);
    public void EmitCharacterStatusChanged(CharacterType character, string statusName, bool active) =>
        EmitSignal(nameof(CharacterStatusChanged), character, statusName, active);
    public void EmitInitiativeQueueChanged(Godot.Collections.Array queueAsArray) =>
        EmitSignal(nameof(InitiativeQueueChanged), queueAsArray);
    public void EmitInitiativeValueChanged(CharacterType character, int newValue) =>
        EmitSignal(nameof(InitiativeValueChanged), character, newValue);
}