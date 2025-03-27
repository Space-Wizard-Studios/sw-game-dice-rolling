using Godot;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia a resolução dos turnos dos personagens durante a batalha.
/// </summary>
/// <remarks>
/// O <c>TurnController</c> é responsável por controlar a execução das ações dos personagens e garantir a resolução ordenada dos turnos na batalha.
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
    private InitiativeController _initiativeController;

    public TurnController() {
        // Inicializa dependências
        _initiativeController = new InitiativeController();

        // Conecta-se aos eventos necessários
        BattleEvents.Instance.ActionPerformed += OnActionPerformed;
    }

    // Inicia a fase de resolução de turnos
    public void StartTurnsResolution() {
        // Começa processando o primeiro personagem na fila de iniciativa
        ProcessNextCharacterTurn();
    }

    // Processa o turno do próximo personagem na fila
    private void ProcessNextCharacterTurn() {
        CharacterType? nextCharacter = _initiativeController.GetNextCharacter();

        if (nextCharacter != null) {
            // Inicia o turno do personagem
            StartCharacterTurn(nextCharacter);
        }
        else {
            // Se não há mais personagens, finaliza a fase de resolução
            BattleEvents.Instance.EmitTurnsResolved();
        }
    }

    // Inicia o turno de um personagem
    private static void StartCharacterTurn(CharacterType character) {
        BattleEvents.Instance.EmitTurnStarted(character);

        // Executa a ação do personagem
        ExecuteCharacterAction(character);
    }

    // Executa a ação declarada pelo personagem
    private static void ExecuteCharacterAction(CharacterType character) {

        // TODO
        // Implementar lógica para executar a ação do personagem
        // Esta parte depende do sistema de ações do jogo

        // Emite evento de ação executada
        BattleEvents.Instance.EmitActionPerformed(character);
    }

    // Finaliza o turno de um personagem
    private void EndCharacterTurn(CharacterType character) {
        // Move o personagem para o final da fila de iniciativa
        _initiativeController.MoveCharacterToEndOfQueue(character);

        // Emite evento de fim de turno
        BattleEvents.Instance.EmitTurnEnded(character);

        // Verifica se há condições para continuar
        if (CheckBattleContinue()) {
            // Processa o próximo personagem
            ProcessNextCharacterTurn();
        }
        else {
            // Finaliza a fase de resolução de turnos
            BattleEvents.Instance.EmitTurnsResolved();
        }
    }

    // ? Deve ser feito aqui, no RoundController ou em outro lugar?
    // Verifica se um novo turno deve começar ou se a rodada deve terminar
    // Verifica se uma nova rodada deve começar ou se a batalha deve terminar
    private static bool CheckBattleContinue() {
        // TODO
        // Implementar lógica para verificar se ambas equipes ainda têm personagens vivos
        return true; // Placeholder
    }

    // Eventos
    private void OnActionPerformed(CharacterType character) {
        EndCharacterTurn(character);
    }
}