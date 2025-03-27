using Godot;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia as ações realizadas após o término da batalha.
/// </summary>
/// <remarks>
/// O <c>PostBattleController</c> é responsável por coordenar o fluxo pós-batalha, exibindo os resultados e direcionando o jogador para a próxima etapa conforme o desfecho da batalha.
///     <list type="table">
///         <listheader>
///             <term>Fluxo pós-batalha</term>
///             <description>Exibição de resultados e transições adequadas</description>
///         </listheader>
///         <item>- Exibe tela de resultados</item>
///         <item>- Gerencia a transição para tela de recompensas</item>
///         <item>- Gerencia a transição para tela de game over</item>
///     </list>
/// </remarks>

public partial class PostBattleController : RefCounted {
    public PostBattleController() {
        // Conecta-se aos eventos relevantes
        BattleEvents.Instance.BattleEnded += OnBattleEnded;
    }

    // Exibe a tela de vitória
    public static void ShowVictoryScreen() {
        BattleManager.Instance.SetBattleState(BattleState.RewardsDistribution);

        // TODO
        // Implementar lógica para mostrar a tela de vitória
        // Calcular experiência, itens, etc.

        // Notifica a distribuição de recompensas
        BattleEvents.Instance.EmitRewardsDistributed();
    }

    // Exibe a tela de derrota
    public static void ShowGameOverScreen() {
        BattleManager.Instance.SetBattleState(BattleState.GameOver);

        // TODO
        // Implementar lógica para mostrar a tela de game over

        // Notifica o game over
        BattleEvents.Instance.EmitGameOver();
    }

    // Transição para a cena apropriada após a batalha
    private static void TransitionToNextScene(bool victory) {
        // TODO
        // Implementar lógica para transição de cena
        // Por exemplo, voltar para a cidade, mostrar tela de recompensas, etc.

        BattleEvents.Instance.EmitSceneTransitioned();
    }

    // Eventos
    private void OnBattleEnded(bool victory) {
        if (victory) {
            ShowVictoryScreen();
        }
        else {
            ShowGameOverScreen();
        }
    }
}