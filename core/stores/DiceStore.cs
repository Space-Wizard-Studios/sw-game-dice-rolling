using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using DiceRoll.Models;

namespace DiceRoll.Stores;

public partial class DiceStore : Node {
    private static DiceStore? _instance;
    public static DiceStore Instance {
        get {
            _instance ??= new DiceStore();
            return _instance;
        }
    }

    public List<Dice<DiceSide>> DiceSet { get; private set; } = new List<Dice<DiceSide>>();

    private DiceStore() { }

    public void AddDice(Dice<DiceSide> dice) {
        DiceSet.Add(dice);
    }

    public Dice<DiceSide> GetDiceByID(string diceId) {
        var dice = DiceSet.FirstOrDefault(d => d.Id == diceId) ?? throw new Exception($"Dice with ID {diceId} not found");
        return dice;
    }

    public void UpdateDiceByID(string diceId, Action<Dice<DiceSide>> updateFn) {
        var dice = GetDiceByID(diceId);
        updateFn(dice);
    }

    public void UpdateDiceName(string diceId, string newName) {
        UpdateDiceByID(diceId, dice => dice.Name = newName);
    }

    public void UpdateDiceLocation(string diceId, DiceLocation newLocation) {
        UpdateDiceByID(diceId, dice => dice.Location = newLocation);
    }

    public void RemoveDice(string diceId) {
        DiceSet = DiceSet.Where(d => d.Id != diceId).ToList();
    }
}