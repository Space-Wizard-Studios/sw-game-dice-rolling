using Godot;
using System.Linq;
using System.Collections.Generic;

using DiceRolling.Characters;
using DiceRolling.Stores;
using DiceRolling.Helpers;

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
    private Queue<CharacterType> _initiativeQueue = new Queue<CharacterType>();
    public IEnumerable<CharacterType> InitiativeQueue => _initiativeQueue;


    public TurnController() {
        ConnectEvents();
    }

    private void ConnectEvents() {
        BattleEvents.Instance.CharactersPositioned += OnCharactersPositioned;
        BattleEvents.Instance.ActionsDeclared += OnActionsDeclared;
        // BattleEvents.Instance.ActionPerformed += OnActionPerformed;
        BattleEvents.Instance.CharacterAddedToQueue += OnCharacterAddedToQueue;
        BattleEvents.Instance.CharacterRemovedFromQueue += OnCharacterRemovedFromQueue;
        BattleEvents.Instance.CharacterInitiativeModified += OnCharacterInitiativeModified;
        BattleEvents.Instance.CheckNextTurn += OnCheckNextTurn;
    }

    // Initiative queue management

    // Calculates the initial turn order based on characters' initiative
    private void CalculateInitialOrder(Godot.Collections.Array characters) {
        _initiativeQueue.Clear();

        // Add all characters to the queue
        foreach (CharacterType character in characters.Cast<Godot.Variant>().Select(v => v.As<CharacterType>())) {
            _initiativeQueue.Enqueue(character);
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
        // Convert queue to list, sort it, then rebuild the queue
        var sortedCharacters = _initiativeQueue.OrderByDescending(c => GetCharacterInitiative(c)).ToList();
        _initiativeQueue = new Queue<CharacterType>(sortedCharacters);

        // Print queue information
        GD.PrintRich("[color=pink]=== INITIATIVE QUEUE ===[/color]");
        int i = 1;
        foreach (var character in _initiativeQueue) {
            int initiative = GetCharacterInitiative(character);

            // Determine team based on location
            string team = "Unknown";
            if (character.Location == BattleController.Instance.PlayerSquadLocation) {
                team = "Player";
            }
            else if (character.Location == BattleController.Instance.EnemySquadLocation) {
                team = "Enemy";
            }

            GD.PrintRich($"[color=pink]{i++}. {character.Name} (Team: {team}) - Initiative: {initiative}.[/color]");
        }
        GD.PrintRich("[color=pink]======================[/color]");
    }

    // Gets the initiative value for a character (speed + modifiers)
    private static int GetCharacterInitiative(CharacterType character) {
        // Find the Speed attribute
        var speedAttribute = character.Attributes.Cast<CharacterAttribute>()
            .FirstOrDefault(attr => attr.Type?.Name == "Speed");

        int baseSpeed = speedAttribute != null ? speedAttribute.CurrentValue : 0;

        // If no Speed attribute found, log a warning
        if (speedAttribute == null) {
            GD.PrintRich($"[color=pink]Character {character.Name} doesn't have a Speed attribute.[/color]");
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
        GD.PrintRich($"[color=pink]TurnController: Adding character {character.Name} to initiative queue.[/color]");
        if (!_initiativeQueue.Contains(character)) {
            _initiativeQueue.Enqueue(character);
            SortQueue();
            BattleEvents.Instance.EmitCharacterAddedToQueue(character);
        }
    }

    // Removes a character from the initiative queue
    public void RemoveCharacterFromQueue(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Removing character {character.Name} from initiative queue.[/color]");
        // Need to rebuild queue to remove a specific character
        var newQueue = new Queue<CharacterType>();
        foreach (var c in _initiativeQueue) {
            if (c != character) {
                newQueue.Enqueue(c);
            }
        }
        _initiativeQueue = newQueue;
        BattleEvents.Instance.EmitCharacterRemovedFromQueue(character);
    }

    // Moves a character to the end of the initiative queue
    public void MoveCharacterToEndOfQueue(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Moving character {character.Name} to end of initiative queue.[/color]");

        // TODO
        // For now, only removes the character from the queue and 
        RemoveCharacterFromQueue(character);
        ProcessNextCharacterTurn();
        BattleEvents.Instance.EmitCharacterMovedToEndOfQueue(character);
    }

    // Gets the next character to act
    public CharacterType? GetNextCharacter() {
        GD.PrintRich($"[color=pink]TurnController: Next character in queue: {(_initiativeQueue.Count > 0 ? _initiativeQueue.Peek()?.Name : "none")}.[/color]");
        return _initiativeQueue.Count > 0 ? _initiativeQueue.Peek() : null;
    }

    // Turn resolution methods

    // Begins the process of resolving turns
    public void StartTurnsResolution() {
        GD.PrintRich("[color=pink]TurnController: Starting turns resolution.[/color]");
        ProcessNextCharacterTurn();
    }

    // Process the turn for the next character in the queue
    private void ProcessNextCharacterTurn() {
        GD.PrintRich("[color=pink]TurnController: Processing next character turn.[/color]");
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
    private void StartCharacterTurn(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Starting turn for {character.Name}.[/color]");
        BattleEvents.Instance.EmitTurnStarted(character);
        ExecuteCharacterAction(character);
    }

    // Execute the action declared by the character
    private void ExecuteCharacterAction(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Executing action for {character.Name}.[/color]");
        // TODO: Execute the character's action
        // This depends on the action system implementation

        // For now, only remove the character from the queue
        MoveCharacterToEndOfQueue(character);
        BattleEvents.Instance.EmitActionPerformed(character);
    }

    // End a character's turn and prepare for the next
    private void EndCharacterTurn(CharacterType character) {
        GD.PrintRich($"[color=pink]TurnController: Ending turn for {character.Name}.[/color]");

        // Emit turn ended event
        BattleEvents.Instance.EmitTurnEnded(character);

        // Check if we should continue to next turn
        if (ShouldContinueBattle()) {
            GD.PrintRich($"[color=pink]TurnController: Next character in queue: {(_initiativeQueue.Count > 0 ? _initiativeQueue.Peek()?.Name : "none")}.[/color]");
            ProcessNextCharacterTurn();
            BattleEvents.Instance.EmitCheckNextTurn();
        }
        else {
            GD.PrintRich("[color=pink]TurnController: Battle conditions met to end round.[/color]");
            // Battle round is complete
            BattleEvents.Instance.EmitTurnsResolved();
        }
    }

    // Check if the battle should continue
    private bool ShouldContinueBattle() {
        // Check if there are characters in the queue
        if (_initiativeQueue.Count == 0) {
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
    private void OnCharactersPositioned(Godot.Collections.Array characters) {
        GD.PrintRich("[color=pink]Event CharactersPositioned fired on TurnController, calculating initial order.[/color]");
        CalculateInitialOrder(characters);
    }

    private void OnActionsDeclared() {
        GD.PrintRich("[color=pink]Event ActionsDeclared fired on TurnController, starting turns resolution.[/color]");
        StartTurnsResolution();
    }

    // private void OnActionPerformed(CharacterType character) {
    //     GD.PrintRich("[color=pink]Event ActionPerformed fired on TurnController, ending turn.[/color]");
    //     EndCharacterTurn(character);
    // }

    private void OnCharacterAddedToQueue(CharacterType character) {
        GD.PrintRich("[color=pink]Event CharacterAddedToQueue fired on TurnController, re-sorting queue.[/color]");
        SortQueue();
    }

    private void OnCharacterRemovedFromQueue(CharacterType character) {
        GD.PrintRich("[color=pink]Event CharacterRemovedFromQueue fired on TurnController, re-sorting queue.[/color]");
        SortQueue();
    }

    private void OnCharacterInitiativeModified(CharacterType character) {
        GD.PrintRich("[color=pink]Event CharacterInitiativeModified fired on TurnController, re-sorting queue.[/color]");
        SortQueue();
    }

    private void OnCheckNextTurn() {
        ProcessNextCharacterTurn();
    }
}