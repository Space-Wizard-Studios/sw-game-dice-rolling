using Godot;
using System.Collections.Generic;
using System.Linq;

using DiceRolling.Characters;

namespace DiceRolling.Controllers;

public partial class InitiativeController : RefCounted {
    private readonly Queue<CharacterType> _initiativeQueue = new();

    private List<CharacterType> _allCharacters = [];

    public List<CharacterType> GetInitiativeQueue() {
        return GetQueueAsList();
    }

    public void SetupInitiative(List<CharacterType> characters) {
        _allCharacters = [.. characters];

        // Ordenar personagens por iniciativa/velocidade
        var sortedCharacters = characters
            .OrderByDescending(c => GetInitiativeValue(c))
            .ToList();

        _initiativeQueue.Clear();
        foreach (var character in sortedCharacters) {
            _initiativeQueue.Enqueue(character);
        }

        var queueArray = new Godot.Collections.Array();
        foreach (var character in _initiativeQueue)
            queueArray.Add(character);

        BattleEvents.Instance.EmitInitiativeQueueChanged(queueArray);

        GD.Print("Iniciativa definida: " +
            string.Join(", ", _initiativeQueue.Select(c => $"{c.Name} ({GetInitiativeValue(c)})"))
        );
    }

    public CharacterType? PeekCurrentCharacter() {
        if (_initiativeQueue.Count == 0) return null;
        return _initiativeQueue.Peek();
    }

    public CharacterType? DequeueCharacter() {
        if (_initiativeQueue.Count == 0) return null;

        var character = _initiativeQueue.Dequeue();

        var queueArray = new Godot.Collections.Array();
        foreach (var c in _initiativeQueue)
            queueArray.Add(c);

        BattleEvents.Instance.EmitInitiativeQueueChanged(queueArray);
        BattleEvents.Instance.EmitTurnStarted(character);

        return character;
    }

    public void MoveToEnd(CharacterType character) {
        if (character == null) return;

        _initiativeQueue.Enqueue(character);

        var queueArray = new Godot.Collections.Array();
        foreach (var c in _initiativeQueue)
            queueArray.Add(c);

        BattleEvents.Instance.EmitInitiativeQueueChanged(queueArray);

        GD.Print($"{character.Name} movido para o final da fila.");
    }

    public void RemoveFromQueue(CharacterType character) {
        if (character == null) return;

        var tempList = _initiativeQueue.Where(c => !c.Id.Equals(character.Id)).ToList();

        _initiativeQueue.Clear();
        foreach (var c in tempList) {
            _initiativeQueue.Enqueue(c);
        }

        var queueArray = new Godot.Collections.Array();
        foreach (var c in _initiativeQueue)
            queueArray.Add(c);

        BattleEvents.Instance.EmitInitiativeQueueChanged(queueArray);

        GD.Print($"{character.Name} removido da fila de iniciativa.");
    }


    public bool IsQueueEmpty() {
        return _initiativeQueue.Count == 0;
    }


    public int GetQueueCount() {
        return _initiativeQueue.Count;
    }


    public void ResetQueueWithAliveCharacters() {
        var aliveCharacters = _allCharacters.Where(c => !IsCharacterDefeated(c)).ToList();
        SetupInitiative(aliveCharacters);
    }


    public List<CharacterType> GetQueueAsList() {
        return [.. _initiativeQueue];
    }


    private static int GetInitiativeValue(CharacterType character) {
        var speedAttribute = character.Attributes.FirstOrDefault(attr => attr.Type?.Name == "Speed");
        return speedAttribute?.CurrentValue ?? 0;
    }

    private static bool IsCharacterDefeated(CharacterType character) {
        var hpAttribute = character.Attributes.FirstOrDefault(attr => attr.Type?.Name == "Health");
        return hpAttribute != null && hpAttribute.CurrentValue <= 0;
    }
}