using Godot;

namespace DiceRolling.Controllers;

/// <summary>
/// Executa comandos de alto nível durante a batalha.
/// </summary>
/// <remarks>
/// O <c>BattleController</c> é responsável por gerenciar a execução de comandos de alto nível durante a batalha, como iniciar, pausar, continuar e finalizar a batalha.
///     <list type="table">
///         <listheader>
///             <term>Transições de estados</term>
///             <description>Principais transições de estado da batalha</description>
///         </listheader>
///         <item>- Início da batalha</item>
///         <item>- Pausa a batalha</item>
///         <item>- Continua a batalha</item>
///         <item>- Fim da batalha</item>
///     </list>
///     <list type="table">
///         <listheader>
///             <term>Phase 1: Preparação da batalha</term>
///             <description>Configuração inicial da batalha</description>
///         </listheader>
///         <item>- Geração de inimigos</item>
///         <item>- Posicionamento de personagens</item>
///         <item>- Inicialização da fila de iniciativa (<c>InitiativeController</c>)</item>
///         <item>- Transição para a fase de rounds (<c>RoundController</c>)</item>
///     </list>
/// </remarks>
public partial class BattleController : RefCounted {
    // Início da batalha
    public void StartBattle(Godot.Collections.Array playerTeam, Godot.Collections.Array enemyTeam) {
        // Configura as equipes e o estado inicial no BattleManager
        BattleManager.Instance.SetupBattle(playerTeam, enemyTeam);

        // Define o estado para Start
        BattleManager.Instance.SetBattleState(BattleState.Start);

        // Notifica que a batalha começou
        BattleEvents.Instance.EmitBattleStarted(playerTeam, enemyTeam);

        // Inicia a fase de preparação
        StartBattlePreparation();
    }

    // Pausa a batalha
    public static void PauseBattle() {
        BattleManager.Instance.SetBattleState(BattleState.Pause);
        BattleEvents.Instance.EmitBattlePaused();
    }

    // Continua a batalha
    public void ResumeBattle() {
        BattleManager.Instance.SetBattleState(BattleState.Resume);
        BattleEvents.Instance.EmitBattleResumed();
    }

    // Finaliza a batalha (vitória ou derrota)
    public static void EndBattle(bool victory) {
        BattleManager.Instance.SetBattleState(BattleState.End);
        BattleEvents.Instance.EmitBattleEnded(victory);
    }

    // Inicia a fase de preparação da batalha
    public void StartBattlePreparation() {
        GenerateEnemies();
    }

    // Geração de inimigos
    private void GenerateEnemies() {
        BattleManager.Instance.SetBattleState(BattleState.EnemiesGeneration);

        // TODO
        // Implementar a lógica de geração dos inimigos
        // Exemplo: baseado na dungeon atual, nível dos personagens, etc.

        // Notifica que os inimigos foram gerados
        // TODO
        // Adicionar inimigos gerados
        Godot.Collections.Array enemies = new Godot.Collections.Array();
        BattleEvents.Instance.EmitEnemiesGenerated(enemies);

        // Passa para a próxima etapa: posicionamento dos personagens
        PositionCharacters();
    }

    // Posiciona os personagens na grid
    private void PositionCharacters() {
        BattleManager.Instance.SetBattleState(BattleState.CharactersPosition);

        // TODO
        // Implementar a lógica de posicionamento dos personagens na grid

        // Notifica que os personagens foram posicionados
        Godot.Collections.Array characters = new Godot.Collections.Array(); // Personagens posicionados
        BattleEvents.Instance.EmitCharactersPositioned(characters);

        // Passa para a próxima etapa: configuração da fila de iniciativa
        SetupInitiativeQueue();
    }

    // Configura a fila de iniciativa
    private static void SetupInitiativeQueue() {
        BattleManager.Instance.SetBattleState(BattleState.InitiativeQueueSetup);

        // TODO
        // Delega a configuração da fila de iniciativa para o InitiativeController
        // A transição para a próxima fase será tratada pelo InitiativeController
    }

    // Transição para a fase de rounds
    public static void TransitionToRounds() {
        BattleManager.Instance.SetBattleState(BattleState.TransitionToRounds);
        BattleEvents.Instance.EmitTransitionedToRounds();
    }
}