using Godot;
using DiceRolling.Characters;
using System.Collections.Generic;
using System.Linq;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia a resolução dos turnos dos personagens durante a batalha.
/// </summary>
/// <remarks>
/// O <c>TurnController</c> é responsável por controlar a execução das ações dos personagens e garantir a resolução ordenada dos turnos na batalha.
///     <list type="table">
///         <listheader>
///             <term>Gestão da iniciativa</term>
///             <description>Calcula, atualiza e mantém a ordem de ação dos personagens</description>
///         </listheader>
///         <item>- Calcula a ordem de iniciativa inicial com base nos atributos dos personagens</item>
///         <item>- Gerencia modificadores de iniciativa que podem alterar a ordem durante a batalha</item>
///         <item>- Atualiza a fila de iniciativa quando personagens entram ou saem da batalha</item>
///         <item>- Fornece informações sobre os próximos personagens a agir, permitindo a continuidade do combate</item>
///     </list>
///     <list type="table">
///         <listheader>
///             <term>Resolução de turnos</term>
///             <description>Controle do fluxo de ações dentro de um turno</description>
///         </listheader>
///         <item>- Inicia o turno de um personagem</item>
///         <item>- Gerencia a execução de ações do personagem</item>
///         <item>- Move o personagem para o fim da fila de iniciativa após a ação</item>
///         <item>- Finaliza o turno de um personagem</item>
///     </list>
/// </remarks>
public partial class TurnController : RefCounted {
    // The initiative queue (order of characters' turns)
    private List<CharacterType> _initiativeQueue = [];
    public List<CharacterType> InitiativeQueue => _initiativeQueue;

    public TurnController() {
        // Connect to relevant events
        ConnectEvents();
    }

    private void ConnectEvents() {
        BattleEvents.Instance.CharactersPositioned += OnCharactersPositioned;
        BattleEvents.Instance.ActionsDeclared += OnActionsDeclared;
        BattleEvents.Instance.ActionPerformed += OnActionPerformed;
        BattleEvents.Instance.CharacterAddedToQueue += OnCharacterAddedToQueue;
        BattleEvents.Instance.CharacterRemovedFromQueue += OnCharacterRemovedFromQueue;
        BattleEvents.Instance.CharacterInitiativeModified += OnCharacterInitiativeModified;
    }

    // Initiative queue management

    // Calculates the initial turn order based on characters' initiative
    private void CalculateInitialOrder(Godot.Collections.Array characters) {
        _initiativeQueue.Clear();

        // Add all characters to the queue
        foreach (CharacterType character in characters.Cast<Godot.Variant>().Select(v => v.As<CharacterType>())) {
            _initiativeQueue.Add(character);
        }

        // Sort by initiative (descending)
        SortQueue();

        // Notify that the queue has been created
        BattleEvents.Instance.EmitInitiativeQueueCreated(new Godot.Collections.Array(_initiativeQueue.ToArray()));

        // Transition to rounds phase
        BattleController.Instance.TransitionToRounds();
    }

    // Sort the initiative queue based on character initiative values
    private void SortQueue() {
        _initiativeQueue = [.. _initiativeQueue.OrderByDescending(c => GetCharacterInitiative(c))];

        // Print detailed queue information
        GD.Print("=== INITIATIVE QUEUE ===");
        for (int i = 0; i < _initiativeQueue.Count; i++) {
            var character = _initiativeQueue[i];
            int initiative = GetCharacterInitiative(character);

            // Determine team based on location
            string team = "Unknown";
            if (character.Location == BattleController.Instance.PlayerSquadLocation) {
                team = "Player";
            }
            else if (character.Location == BattleController.Instance.EnemySquadLocation) {
                team = "Enemy";
            }

            GD.Print($"{i + 1}. {character.Name} (Team: {team}) - Initiative: {initiative}");
        }
        GD.Print("======================");
    }

    // Gets the initiative value for a character (speed + modifiers)
    private static int GetCharacterInitiative(CharacterType character) {
        // Find the Speed attribute
        var speedAttribute = character.Attributes.Cast<CharacterAttribute>()
            .FirstOrDefault(attr => attr.Type?.Name == "Speed");

        int baseSpeed = speedAttribute != null ? speedAttribute.CurrentValue : 0;

        // If no Speed attribute found, log a warning
        if (speedAttribute == null) {
            GD.Print($"Character {character.Name} doesn't have a Speed attribute");
        }

        // TODO Consider any active initiative modifiers
        // int initiativeModifiers = 0;
        // if (character.ActiveEffects != null) {
        //     foreach (var effect in character.ActiveEffects) {
        //         if (effect.AffectsInitiative) {
        //             initiativeModifiers += effect.InitiativeModifierValue;
        //         }
        //     }
        // }

        return baseSpeed;
        // return baseSpeed + initiativeModifiers;
    }

    // Adds a character to the initiative queue
    public void AddCharacterToQueue(CharacterType character) {
        GD.Print("TurnController: Adding character to initiative queue");
        if (!_initiativeQueue.Contains(character)) {
            _initiativeQueue.Add(character);
            SortQueue();
            BattleEvents.Instance.EmitCharacterAddedToQueue(character);
        }
    }

    // Removes a character from the initiative queue
    public void RemoveCharacterFromQueue(CharacterType character) {
        GD.Print("TurnController: Removing character from initiative queue");
        if (_initiativeQueue.Contains(character)) {
            _initiativeQueue.Remove(character);
            BattleEvents.Instance.EmitCharacterRemovedFromQueue(character);
        }
    }

    // Moves a character to the end of the initiative queue
    public void MoveCharacterToEndOfQueue(CharacterType character) {
        GD.Print("TurnController: Moving character to end of initiative queue");
        if (_initiativeQueue.Contains(character)) {
            _initiativeQueue.Remove(character);
            _initiativeQueue.Add(character);
            BattleEvents.Instance.EmitCharacterMovedToEndOfQueue(character);
        }
    }

    // Gets the next character to act
    public CharacterType? GetNextCharacter() {
        return _initiativeQueue.Count > 0 ? _initiativeQueue[0] : null;
    }

    // Turn resolution methods

    // Begins the process of resolving turns
    public void StartTurnsResolution() {
        GD.Print("TurnController: Starting turns resolution");
        ProcessNextCharacterTurn();
    }

    // Process the turn for the next character in the queue
    private void ProcessNextCharacterTurn() {
        GD.Print("TurnController: Processing next character turn");
        CharacterType? nextCharacter = GetNextCharacter();

        if (nextCharacter != null) {
            StartCharacterTurn(nextCharacter);
        }
        else {
            // If no more characters, the turn resolution is complete
            BattleEvents.Instance.EmitTurnsResolved();
        }
    }

    // Start a character's turn
    private static void StartCharacterTurn(CharacterType character) {
        GD.Print($"TurnController: Starting turn for {character.Name}");
        BattleEvents.Instance.EmitTurnStarted(character);
        ExecuteCharacterAction(character);
    }

    // Execute the action declared by the character
    private static void ExecuteCharacterAction(CharacterType character) {
        GD.Print($"TurnController: Executing action for {character.Name}");
        // TODO: Execute the character's action
        // This depends on the action system implementation

        // Notify that the action has been executed
        BattleEvents.Instance.EmitActionPerformed(character);
    }

    // End a character's turn and prepare for the next
    private void EndCharacterTurn(CharacterType character) {
        GD.Print($"TurnController: Ending turn for {character.Name}");
        // Move character to the end of queue
        MoveCharacterToEndOfQueue(character);

        // Emit turn ended event
        BattleEvents.Instance.EmitTurnEnded(character);

        // Check if we should continue to next turn
        if (ShouldContinueBattle()) {
            // Use CheckNextTurn event instead of direct call to break recursion
            BattleEvents.Instance.EmitCheckNextTurn();
        }
        else {
            // Battle round is complete
            BattleEvents.Instance.EmitTurnsResolved();
        }
    }

    // Check if the battle should continue
    private static bool ShouldContinueBattle() {
        // TODO: Implement logic to check if both teams still have characters alive
        return true; // Placeholder
    }

    // Event handlers

    private void OnCharactersPositioned(Godot.Collections.Array characters) {
        GD.Print("Event CharactersPositioned fired on TurnController, calculating initial order");
        CalculateInitialOrder(characters);
    }

    private void OnActionsDeclared() {
        GD.Print("Event ActionsDeclared fired on TurnController, starting turns resolution");
        StartTurnsResolution();
    }

    private void OnActionPerformed(CharacterType character) {
        GD.Print("Event ActionPerformed fired on TurnController, ending turn");
        EndCharacterTurn(character);
    }

    private void OnCharacterAddedToQueue(CharacterType character) {
        GD.Print("Event CharacterAddedToQueue fired on TurnController, re-sorting queue");
        SortQueue();
    }

    private void OnCharacterRemovedFromQueue(CharacterType character) {
        GD.Print("Event CharacterRemovedFromQueue fired on TurnController, re-sorting queue");
        // The character is already removed in RemoveCharacterFromQueue
        // Just resort the queue
        SortQueue();
    }

    private void OnCharacterInitiativeModified(CharacterType character) {
        GD.Print("Event CharacterInitiativeModified fired on TurnController, re-sorting queue");
        SortQueue();
    }

    private void OnCheckNextTurn() {
        // Call process with deferred execution to break the call stack
        CallDeferred(nameof(ProcessNextCharacterTurn));
    }
}