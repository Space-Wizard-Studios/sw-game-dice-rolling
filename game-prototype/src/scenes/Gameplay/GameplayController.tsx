import { Presentation } from '@scenes/Gameplay/states/Presentation';
import { Preparation } from '@scenes/Gameplay/states/Preparation';
import { BattleSetup } from '@scenes/Gameplay/states/BattleSetup';
import { BattleStart } from '@scenes/Gameplay/states/BattleStart';
import { BattleEnd } from '@scenes/Gameplay/states/BattleEnd';

import { GameplayStates } from '@models/gameStates/GameplayStates';
import { updateSceneState } from '@helpers/updateGameState';

const scene = 'gameplay';

export async function startGameplay() {
    console.log('Starting game...');
    updateSceneState(scene, GameplayStates.presentation);
    await Presentation();
    await transitionToPreparation();
}

export async function transitionToPreparation() {
    console.log('Transitioning to preparation phase...');
    updateSceneState(scene, GameplayStates.preparation);
    await Preparation();
    await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
    console.log('Transitioning to battle setup phase...');
    updateSceneState(scene, GameplayStates.battleSetup);
    await BattleSetup();
    await transitionToBattleStart();
}

export async function transitionToBattleStart() {
    console.log('Transitioning to battle start phase...');
    updateSceneState(scene, GameplayStates.battleStart);
    await BattleStart();
    await transitionToBattleEnd();
}

export async function transitionToBattleEnd() {
    console.log('Transitioning to battle end phase...');
    updateSceneState(scene, GameplayStates.battleEnd);
    await BattleEnd();
    // TODO Decide next phase or end game
}