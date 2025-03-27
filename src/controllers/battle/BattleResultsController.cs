using Godot;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia as condições de vitória, derrota e recompensas da batalha.
/// </summary>
/// <remarks>
/// O <c>BattleResultsController</c> é responsável por determinar o desfecho da batalha, verificando se as condições de vitória ou derrota foram atendidas e iniciando a transição para a tela de resultados.
///     <list type="table">
///         <listheader>
///             <term>Avaliação do resultado da batalha</term>
///             <description>Determinação do fim da batalha e transição para os resultados</description>
///         </listheader>
///         <item>- Verifica condições de vitória</item>
///         <item>- Verifica condições de derrota</item>
///         <item>- Faz a transição para a tela de resultados (<c>PostBattleController</c>)</item>
///     </list>
/// </remarks>
public partial class BattleResultsController : RefCounted {
    public BattleResultsController() {
        // Conecta-se aos eventos relevantes
        BattleEvents.Instance.RoundEnded += OnRoundEnded;
    }

    // Verifica se houve vitória ou derrota
    public static void CheckBattleResult() {

        bool victory = CheckVictoryCondition();

        if (victory || CheckDefeatCondition()) {
            // Notifica o resultado da batalha
            BattleEvents.Instance.EmitBattleResultChecked(victory);

            // Transição para o pós-batalha
            TransitionToPostBattle(victory);
        }
    }

    // Verifica condições de vitória (todos inimigos derrotados)
    private static bool CheckVictoryCondition() {
        // TODO
        // Implementar lógica para verificar se todos os inimigos foram derrotados
        return false; // Placeholder
    }

    // Verifica condições de derrota (todos personagens do jogador derrotados)
    private static bool CheckDefeatCondition() {
        // TODO
        // Implementar lógica para verificar se todos os personagens do jogador foram derrotados
        return false; // Placeholder
    }

    // Transição para a fase de pós-batalha
    private static void TransitionToPostBattle(bool victory) {
        // Notifica o fim da batalha
        BattleEvents.Instance.EmitBattleEnded(victory);
    }

    // Eventos
    private void OnRoundEnded(int roundNumber) {
        CheckBattleResult();
    }
}