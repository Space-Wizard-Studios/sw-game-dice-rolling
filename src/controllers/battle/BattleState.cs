namespace DiceRolling.Controllers;

/// <summary>
/// Define os possíveis estados da batalha.
/// </summary>
public enum BattleState {
    Start,
    Pause,
    Resume,
    End,

    // Phase 1: Battle Preparation
    EnemiesGeneration,
    CharactersPosition,
    InitiativeQueueSetup,
    TransitionToRounds,

    // Phase 2: Battle Round
    RoundStart,
    ActionsDeclaration,
    TurnsResolution,
    RoundEnd,

    // Phase 3: Battle Result
    ResultChecking,
    PostBattleTransition,

    // Phase 4: Post Battle
    RewardsDistribution,
    GameOver
}

// Battle State Events
//  - Battle started
//  - Battle paused
//  - Battle resumed
//  - Battle ended

// Phase 1: Battle Preparation Events
//  - Step 1: Enemies generation
//  - Step 2: Characters position
//  - Step 3: Initiative queue setup
//  - Step 4: Transition to Rounds Phase

// Initiative Events
//  - Update queue when a character is added
//  - Update queue when a character is removed
//  - Update queue when a character's initiative is 

// Phase 2: Battle Round Events
//  - Step 1: Round start
//  - Step 2: Actions declaration
//  - Step 3: Turns resolution
//  - Step 4: Round end

// Enemy Character Events
//  - Enemy declares an action

// Player Characters Events
//  - Character rolls dice for mana
//  - Player declares an action for a character
//  - Player selects a target for an action
//  - Player cancels an action for a character

// Turns Events
//  - Character starts it's turn
//  - Character performs it's action
//  - Character is moved to the end of initiative queue
//  - Character ends it's turn

// Turn Check Events
// - Check if the next turn is from a player character
// Check if a new round starts or the battle ends

// Phase 3: Battle Result Events
//  - Step 1: Result checking
//  - Step 2: Post Battle transition

// Phase 4: Post Battle Events
//  - Rewards distribution
// or
//  - Game Over event