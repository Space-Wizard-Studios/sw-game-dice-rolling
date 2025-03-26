using Godot;
using System.Collections.Generic;

using DiceRolling.Controllers;
using DiceRolling.Characters;

namespace DiceRolling.Controllers;

/// <summary>
/// Gerencia o fluxo da batalha, controlando as transições entre estados
/// e orquestrando os diferentes controladores.
/// </summary>
public partial class BattleManager : Node {
    private static BattleManager? _instance;

    public static BattleManager Instance {
        get {
            if (_instance == null) {
                // Try to get from the scene tree first
                if (Engine.GetMainLoop() is SceneTree tree) {
                    _instance = tree.Root.GetNodeOrNull<BattleManager>("/root/BattleManager");
                }

                // If not found, create a new instance
                _instance ??= new BattleManager();
            }
            return _instance;
        }
    }

    // Estado atual da batalha
    private BattleState _currentState = BattleState.Start;
    public BattleState CurrentState => _currentState;

    // Número do round atual
    private int _currentRound = 0;
    public int CurrentRound => _currentRound;

    // Equipes na batalha
    private Godot.Collections.Array _playerTeam = [];
    private Godot.Collections.Array _enemyTeam = [];

    // Controllers da batalha

    // TODO
    // BattleController - executa comandos de alto nível:
    // - Transições de estados
    //      - Início da batalha
    //      - Pausa/continuação de batalha
    //      - Fim da batalha
    // - Phase 1: Preparação da batalha   
    //      - Geração de inimigos
    //      - Posicionamento de personagens
    //      - Inicialização de fila de iniciativa (InitiativeController)
    //      - Transição para a fase de rounds (RoundController)
    private BattleController? _battleController;

    // TODO
    // InitiativeController - gerencia a ordem de iniciativa dos personagens
    // - Calcula a ordem de iniciativa inicial
    // - Gerencia modificadores de iniciativa durante a batalha
    // - Atualiza a fila quando personagens entram/saem
    // - Fornece informações sobre próximos personagens a agir
    private InitiativeController? _initiativeController;

    // TODO
    // RoundController - gerencia o fluxo de rounds da batalha
    // - Inicia um novo round
    // TODO - Definir a relação com o ActionsController
    // TODO - Definir a relação com o TurnController
    // - Finaliza o round
    private RoundController? _roundController;

    // TODO
    // ActionsController - gerencia a declaração de ações dos personagens
    // - Gerencia a declaração das ações dos inimigos
    // - Gerencia a rolagem de dados para coleta de energia dos personagens
    // - Recebe comandos de declaração de ações dos personagens dos jogadores
    private ActionsController? _actionsController;

    // TODO
    // TurnController - gerencia a resolução dos turnos dos personagens (execução de ações)
    // - Inicia o turno de um personagem
    // - Gerencia a execução de ações do personagem
    // - Move personagem para o fim da fila de iniciativa após ação
    // - Finaliza o turno de um personagem
    // - Verifica condições para novos turnos
    // - Verifica condições para novas rodadas
    private TurnController? _turnController;

    // TODO
    // BattleResultsController - gerencia a exibição dos resultados da batalha
    // - Verifica condições de vitória/derrota
    // - Faz a transição para a tela de resultados (PostBattleController)

    // TODO
    // PostBattleController - gerencia ações após o término da batalha
    // - Exibe tela de resultados
    // - Gerencia a transição para tela de recompensas
    // - Gerencia a transição para tela de game over
}