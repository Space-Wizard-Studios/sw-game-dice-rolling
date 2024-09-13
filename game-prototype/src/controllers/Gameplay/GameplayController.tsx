import { Presentation } from '@controllers/Gameplay/states/Presentation';
import { Preparation } from '@controllers/Gameplay/states/Preparation';
import { BattleSetup } from '@controllers/Gameplay/states/BattleSetup';
import { BattleStart } from '@controllers/Gameplay/states/BattleStart';
import { BattleEnd } from '@controllers/Gameplay/states/BattleEnd';
import { updateGameState, updateGameSceneState } from '@helpers/updateGameState';

import type { GameplaySceneType } from '@models/scenes/GameplayScene';
import type { GameplayStateType } from '@models/states/GameplayStates';

let scene: GameplaySceneType;
let state: GameplayStateType;

export async function startGameplay() {
    scene = 'gameplayScene';
    state = 'gameplayPresentation';
    console.log('Starting gameplay...');
    updateGameSceneState(scene, state);
    await Presentation();
    await transitionToPreparation();
}

export async function transitionToPreparation() {
    console.log('Transitioning to preparation phase...');
    state = 'gameplayPreparation';
    updateGameState(state);
    await Preparation();
    await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
    console.log('Transitioning to battle setup phase...');
    state = 'gameplaySetup';
    updateGameState(state);
    await BattleSetup();
    await transitionToBattleStart();
}

export async function transitionToBattleStart() {
    console.log('Transitioning to battle start phase...');
    state = 'gameplayBattle';
    updateGameState(state);
    await BattleStart();
    await transitionToBattleEnd();
}

export async function transitionToBattleEnd() {
    console.log('Transitioning to battle end phase...');
    state = 'gameplayBattleResult';
    updateGameState(state);
    await BattleEnd();
    // TODO Decide next phase or end game
}