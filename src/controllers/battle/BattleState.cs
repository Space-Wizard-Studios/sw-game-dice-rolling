namespace DiceRolling.Controllers;

public enum BattleState {
    Preparation,    // Preparação inicial da batalha
    ActionDeclaration,  // Jogadores e inimigos declarando ações
    TurnExecution,  // Executando turnos com base na iniciativa
    BattleEnd,      // Batalha finalizada (vitória ou derrota)
    Paused          // Batalha pausada temporariamente
}