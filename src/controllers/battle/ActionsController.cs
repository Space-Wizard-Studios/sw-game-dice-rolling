using Godot;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia a declaração de ações dos personagens durante a batalha.
/// </summary>
/// <remarks>
/// O <c>ActionsController</c> é responsável por coordenar o momento em que personagens e inimigos escolhem suas ações antes da execução dos turnos.
///     <list type="table">
///         <listheader>
///             <term>Declaração de ações</term>
///             <description>Processo de escolha e preparação das ações</description>
///         </listheader>
///         <item>- Gerencia a declaração das ações dos inimigos</item>
///         <item>- Gerencia a rolagem de dados para coleta de energia dos personagens</item>
///         <item>- Recebe comandos de declaração de ações dos personagens dos jogadores</item>
///     </list>
/// </remarks>
public partial class ActionsController : RefCounted {
    public ActionsController() {
        // Conecta-se aos eventos necessários
        BattleEvents.Instance.PlayerActionDeclared += OnPlayerActionDeclared;
        BattleEvents.Instance.PlayerTargetSelected += OnPlayerTargetSelected;
        BattleEvents.Instance.PlayerActionCancelled += OnPlayerActionCancelled;
    }

    // Inicia a fase de declaração de ações
    public static void StartActionsDeclaration() {
        // Primeiro, declara as ações dos inimigos (IA)
        DeclareEnemyActions();

        // TODO
        // Em seguida, permite que os jogadores declarem suas ações
        // (Este é um processo assíncrono que será controlado pela UI)
        // O método será concluído quando todos os jogadores declararem suas ações
    }

    // Declara ações para inimigos usando IA
    private static void DeclareEnemyActions() {
        // TODO
        // Implementar a lógica de IA para determinar ações dos inimigos
        // Para cada inimigo:
        //   - Escolher a melhor ação baseada na situação atual
        //   - Escolher o melhor alvo
        //   - Emitir o evento EnemyActionDeclared
    }

    // Verifica se todos os personagens declararam suas ações
    private static bool AllActionsAreDeclared() {
        // TODO
        // Implementar lógica para verificar se todos os personagens declararam suas ações
        return false; // Placeholder
    }

    // Finaliza a declaração de ações e avança para a resolução de turnos
    private static void CompleteActionsDeclaration() {
        BattleEvents.Instance.EmitActionsDeclared();

        // Avança para a próxima fase
        RoundController roundController = new();
        roundController.StartTurnsResolutionPhase();
    }

    // Eventos
    private void OnPlayerActionDeclared(CharacterType character) {
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerTargetSelected(CharacterType character, CharacterType target) {
        CheckIfAllActionsDeclared();
    }

    private void OnPlayerActionCancelled(CharacterType character) {
        // TODO
        // Lógica para lidar com o cancelamento de ação
    }

    private static void CheckIfAllActionsDeclared() {
        if (AllActionsAreDeclared()) {
            CompleteActionsDeclaration();
        }
    }
}