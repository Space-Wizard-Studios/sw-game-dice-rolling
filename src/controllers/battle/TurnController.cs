using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DiceRolling.Characters;
using DiceRolling.Actions;
using DiceRolling.Logs;
using DiceRolling.Stores;
using DiceRolling.Events;  // Adicionar esse namespace

namespace DiceRolling.Controllers;

public partial class TurnController : RefCounted {
    private InitiativeController _initiativeController;
    private bool _isExecutingTurns = false;
    private bool _isPaused = false;
    private Dictionary<string, ActionType> _declaredActions = [];
    private Dictionary<string, CharacterType> _declaredTargets = [];
    private float _actionDelay = 0.5f;

    public TurnController(InitiativeController initiativeController) {
        _initiativeController = initiativeController;
    }

    public void DeclareAction(CharacterType character, ActionType action, CharacterType? target = null) {
        if (character == null || action == null) return;

        _declaredActions[character.Id] = action;
        if (target != null) {
            _declaredTargets[character.Id] = target;
        }

        GameLogStore.Instance.AddGameLogLine(
            new GameLogLine(GameLogLineType.Info,
                $"{character.Name} preparou {action.Name}" +
                (target != null ? $" contra {target.Name}." : ".")
            )
        );

        BattleEvents.Instance.EmitActionDeclared(character, action, target ?? character);
    }

    public void StartTurns() {
        if (_isExecutingTurns) return;

        _isExecutingTurns = true;
        _isPaused = false;

        // Iniciar o primeiro turno de forma assíncrona
        ExecuteNextTurnAsync();
    }

    public void PauseTurns() {
        _isPaused = true;
    }

    public void ResumeTurns() {
        if (!_isPaused) return;

        _isPaused = false;

        // Se estava executando turnos quando foi pausado, retomar
        if (_isExecutingTurns) {
            ExecuteNextTurnAsync();
        }
    }

    private async void ExecuteNextTurnAsync() {
        if (_isPaused) return;

        if (_initiativeController.IsQueueEmpty()) {
            FinishAllTurns();
            return;
        }

        var character = _initiativeController.DequeueCharacter();

        if (character == null) {
            FinishAllTurns();
            return;
        }

        if (IsCharacterDefeated(character)) {
            ExecuteNextTurnAsync();
            return;
        }

        BattleEvents.Instance.EmitTurnStarted(character);

        GameLogStore.Instance.AddGameLogLine(
            new GameLogLine(GameLogLineType.Info, $"Turno de {character.Name} iniciado.")
        );

        await Task.Delay((int)(_actionDelay * 1000));

        if (_isPaused) return;

        ExecuteCharacterAction(character);

        if (!IsCharacterDefeated(character)) {
            _initiativeController.MoveToEnd(character);
        }

        BattleEvents.Instance.EmitTurnEnded(character);

        GameLogStore.Instance.AddGameLogLine(
            new GameLogLine(GameLogLineType.Info, $"Turno de {character.Name} finalizado.")
        );

        await Task.Delay((int)(_actionDelay * 1000));

        if (_isPaused) return;

        // Continuar para o próximo turno
        ExecuteNextTurnAsync();
    }

    private void ExecuteCharacterAction(CharacterType character) {
        if (!_declaredActions.TryGetValue(character.Id, out var action)) {
            GameLogStore.Instance.AddGameLogLine(
                new GameLogLine(GameLogLineType.Info, $"{character.Name} não executou nenhuma ação.")
            );
            return;
        }

        CharacterType? target = null;
        _declaredTargets.TryGetValue(character.Id, out target);

        bool actionSuccess = false;

        var context = new ActionContext(character, target);

        try {
            actionSuccess = action.Do(context);

            if (actionSuccess) {
                GameLogStore.Instance.AddGameLogLine(
                    new GameLogLine(GameLogLineType.Action,
                        $"{character.Name} executou {action.Name}" +
                        (target != null ? $" contra {target.Name}." : ".")
                    )
                );

                BattleEvents.Instance.EmitActionExecuted(character, action, target ?? character);

                if (target != null && IsCharacterDefeated(target)) {
                    // Registrar a derrota
                    GameLogStore.Instance.AddGameLogLine(
                        new GameLogLine(GameLogLineType.Combat, $"{target.Name} foi derrotado!")
                    );

                    _initiativeController.RemoveFromQueue(target);

                    BattleEvents.Instance.EmitCharacterDefeated(target);
                }
            }
            else {
                GameLogStore.Instance.AddGameLogLine(
                    new GameLogLine(GameLogLineType.Action, $"{character.Name} falhou ao executar {action.Name}.")
                );
            }
        }
        catch (Exception ex) {
            GameLogStore.Instance.AddGameLogLine(
                new GameLogLine(GameLogLineType.Error, $"Erro ao executar ação: {ex.Message}")
            );
        }
        finally {
            _declaredActions.Remove(character.Id);
            _declaredTargets.Remove(character.Id);
        }
    }

    private void FinishAllTurns() {
        _isExecutingTurns = false;

        GameLogStore.Instance.AddGameLogLine(
            new GameLogLine(GameLogLineType.Info, "Todos os turnos foram concluídos.")
        );

        BattleEvents.Instance.EmitAllTurnsCompleted();
    }

    private static bool IsCharacterDefeated(CharacterType character) {
        if (character == null) return true;

        CharacterAttribute? hpAttribute = null;
        foreach (CharacterAttribute attr in character.Attributes) {
            if (attr.Type?.Name == "HP") {
                hpAttribute = attr;
                break;
            }
        }

        return hpAttribute != null && hpAttribute.CurrentValue <= 0;
    }

    private class ActionContext : IActionContext {
        public CharacterType Target { get; }
        public CharacterType Attacker { get; }

        public ActionContext(CharacterType actor, CharacterType? target) {
            Attacker = actor;
            Target = target ?? actor; // Se não houver alvo, o ator é o alvo (ações reflexivas)
        }
    }
}