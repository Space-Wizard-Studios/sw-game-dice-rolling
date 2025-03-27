using Godot;
using System.Collections.Generic;
using System.Linq;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia a ordem de iniciativa dos personagens durante a batalha.
/// </summary>
/// <remarks>
/// O <c>InitiativeController</c> é responsável por organizar e gerenciar a ordem de ação dos personagens em combate, garantindo que a sequência de turnos seja calculada e mantida
/// de forma eficiente.
/// <list type="table">
///     <listheader>
///         <term>Gestão da iniciativa</term>
///         <description>Calcula, atualiza e mantém a ordem de ação dos personagens</description>
///     </listheader>
///     <item>- Calcula a ordem de iniciativa inicial com base nos atributos dos personagens</item>
///     <item>- Gerencia modificadores de iniciativa que podem alterar a ordem durante a batalha</item>
///     <item>- Atualiza a fila de iniciativa quando personagens entram ou saem da batalha</item>
///     <item>- Fornece informações sobre os próximos personagens a agir, permitindo a continuidade do combate</item>
/// </list>
/// Além disso, o controlador se conecta a eventos relevantes para reagir dinamicamente a mudanças no estado da batalha,
/// como a adição ou remoção de personagens, ou alterações nos atributos que afetam a iniciativa.
/// </remarks>
public partial class InitiativeController : RefCounted {
    // Fila de iniciativa (ordem dos personagens)
    private List<CharacterType> _initiativeQueue = [];
    public List<CharacterType> InitiativeQueue => _initiativeQueue;

    public InitiativeController() {
        // Conecta-se aos eventos necessários
        BattleEvents.Instance.CharactersPositioned += OnCharactersPositioned;
        BattleEvents.Instance.CharacterAddedToQueue += OnCharacterAddedToQueue;
        BattleEvents.Instance.CharacterRemovedFromQueue += OnCharacterRemovedFromQueue;
        BattleEvents.Instance.CharacterInitiativeModified += OnCharacterInitiativeModified;
    }

    // Calcula a ordem de iniciativa inicial
    private void CalculateInitialOrder(Godot.Collections.Array characters) {
        _initiativeQueue.Clear();

        // Adiciona todos os personagens à fila
        foreach (CharacterType character in characters) {
            _initiativeQueue.Add(character);
        }

        // Ordena por iniciativa (descendente)
        SortQueue();

        // Notifica que a fila foi criada
        BattleEvents.Instance.EmitInitiativeQueueCreated(new Godot.Collections.Array(_initiativeQueue.ToArray()));

        // Transição para a fase de rounds
        BattleManager.Instance.SetBattleState(BattleState.TransitionToRounds);
        // TODO
        // ! RoundController.Instance.StartRound();
        // ? BattleController controller = new();
        // ? controller.TransitionToRounds();

    }

    // Ordena a fila de iniciativa
    private void SortQueue() {
        _initiativeQueue = _initiativeQueue.OrderByDescending(c => GetCharacterInitiative(c)).ToList();
    }

    // Obtém a iniciativa de um personagem (velocidade + modificadores)
    private static int GetCharacterInitiative(CharacterType character) {
        // TODO
        // Implementar a lógica para obter a iniciativa (velocidade + modificadores)
        // Por exemplo: character.Speed + character.InitiativeModifiers
        return 0; // Placeholder
    }

    private static void UpdateCharacterInitiative(CharacterType character) {
        // TODO
        // Implementar a lógica para atualizar a iniciativa de um personagem e reordenar a fila
    }

    // Adiciona um personagem à fila de iniciativa
    public void AddCharacterToQueue(CharacterType character) {
        if (!_initiativeQueue.Contains(character)) {
            _initiativeQueue.Add(character);
            SortQueue();
            BattleEvents.Instance.EmitCharacterAddedToQueue(character);
        }
    }

    // Remove um personagem da fila de iniciativa
    public void RemoveCharacterFromQueue(CharacterType character) {
        if (_initiativeQueue.Contains(character)) {
            _initiativeQueue.Remove(character);
            BattleEvents.Instance.EmitCharacterRemovedFromQueue(character);
        }
    }

    // Move um personagem para o final da fila
    public void MoveCharacterToEndOfQueue(CharacterType character) {
        if (_initiativeQueue.Contains(character)) {
            _initiativeQueue.Remove(character);
            _initiativeQueue.Add(character);
            BattleEvents.Instance.EmitCharacterMovedToEndOfQueue(character);
        }
    }

    // Obtém o próximo personagem a agir
    public CharacterType? GetNextCharacter() {
        if (_initiativeQueue.Count > 0) {
            return _initiativeQueue[0];
        }
        return null;
    }

    // Eventos
    private void OnCharactersPositioned(Godot.Collections.Array characters) {
        CalculateInitialOrder(characters);
    }

    private void OnCharacterAddedToQueue(CharacterType character) {
        SortQueue();
    }

    private void OnCharacterRemovedFromQueue(CharacterType character) {
        SortQueue();
    }

    private void OnCharacterInitiativeModified(CharacterType character) {
        SortQueue();
    }
}