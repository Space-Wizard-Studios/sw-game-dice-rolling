using Godot;
using System.Linq;

using DiceRolling.Characters;
using DiceRolling.Stores;
using DiceRolling.Helpers;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia a resolução dos turnos dos personagens durante a batalha.
/// </summary>
/// <remarks>
/// O <c>TurnController</c> é responsável por controlar a execução das ações dos personagens durante a batalha.
///     <list type="table">
///         <listheader>
///             <term>Resolução de turnos</term>
///             <description>Controle do fluxo de ações dentro de um turno</description>
///         </listheader>
///         <item>- Inicia o turno de um personagem</item>
///         <item>- Gerencia a execução de ações do personagem</item>
///         <item>- Finaliza o turno de um personagem</item>
///     </list>
/// </remarks>
public partial class TurnController : RefCounted {
    private QueueController? _queueController;

    public TurnController() {
        ConnectEvents();
    }

    public TurnController(QueueController? queueController) {
        _queueController = queueController ?? new QueueController();
        ConnectEvents();
    }

    private void ConnectEvents() {
        DisconnectEvents();

        var events = BattleEvents.Instance;
        if (events != null) {
            events.ActionsDeclared += OnActionsDeclared;
            events.CheckNextTurn += OnCheckNextTurn;
        }
    }

    private void DisconnectEvents() {
        var events = BattleEvents.Instance;
        if (events != null) {
            events.ActionsDeclared -= OnActionsDeclared;
            events.CheckNextTurn -= OnCheckNextTurn;
        }
    }

    public void StartTurnsResolution() {
        GD.PrintRich("[color=pink]TurnController: Starting turns resolution.[/color]");
        ProcessNextCharacterTurn();
    }

    // Process the turn for the next character in the queue
    private void ProcessNextCharacterTurn() {
        if (_queueController == null) {
            GD.PrintRich("[color=pink]TurnController: No queue controller available, cannot process next turn.[/color]");
            return;
        }

        if (!ShouldContinueBattle()) {
            GD.PrintRich("[color=pink]TurnController: Battle ended, no more turns to process.[/color]");
            return;
        }

        var nextCharacter = _queueController.GetNextCharacter();
        if (nextCharacter == null) {
            GD.PrintRich("[color=pink]TurnController: No character found in queue.[/color]");
            return;
        }

        StartCharacterTurn(nextCharacter);

    }

    // Start a character's turn
    private void StartCharacterTurn(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Starting turn for {character.Name}.[/color]");
        BattleEvents.Instance.EmitTurnStarted(character);
        ExecuteCharacterAction(character);
    }

    // Execute the action declared by the character
    private void ExecuteCharacterAction(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Executing action for {character.Name}.[/color]");

        // TODO: Execute the character's action
        // For now, we will just simulate the action execution
        // Simulate action execution

        BattleEvents.Instance.EmitTurnEnded(character);

        _queueController?.RemoveCharacterFromQueue(character);

        GD.PrintRich($"[color=pink]TurnController: Action performed for {character.Name}.[/color]");

        BattleEvents.Instance.EmitActionPerformed(character);

        ProcessNextCharacterTurn();

    }

    private bool ShouldContinueBattle() {
        // Check if there are characters in the queue
        if (_queueController == null || _queueController.IsQueueEmpty()) {
            GD.PrintRich("[color=pink]TurnController: No characters left in queue, ending round.[/color]");
            return false;
        }

        // Check if both teams still have active characters
        var battleController = BattleController.Instance;

        // Get alive characters from each team
        var playerTeam = battleController.GetPlayerTeam();
        var enemyTeam = battleController.GetEnemyTeam();

        // Get attributes store for health check
        var attributesStore = GD.Load<AttributesStore>("res://resources/Attributes/AttributesStore.tres");
        var healthAttribute = AttributesHelper.GetAttributeType(attributesStore, "Health");

        if (healthAttribute == null) {
            GD.PrintRich("[color=pink]TurnController: Health attribute not found.[/color]");
            return true; // Continue battle if we can't check health
        }

        // Check if there are alive characters in both teams
        bool hasPlayerAlive = playerTeam.Any(p => p.GetAttributeCurrentValue(healthAttribute) > 0);
        bool hasEnemyAlive = enemyTeam.Any(e => e.GetAttributeCurrentValue(healthAttribute) > 0);

        // If either team has no living characters, battle should end
        if (!hasPlayerAlive || !hasEnemyAlive) {
            GD.PrintRich($"[color=pink]TurnController: Battle ending - Players alive: {hasPlayerAlive}, Enemies alive: {hasEnemyAlive}.[/color]");
            return false;
        }

        GD.PrintRich("[color=pink]TurnController: Battle continuing - both teams have active characters.[/color]");
        return true;
    }

    // Event handlers
    private void OnActionsDeclared() {
        GD.PrintRich("[color=pink]Event ActionsDeclared fired on TurnController, starting turns resolution.[/color]");
        StartTurnsResolution();
    }

    private void OnCheckNextTurn() {
        ProcessNextCharacterTurn();
    }
}