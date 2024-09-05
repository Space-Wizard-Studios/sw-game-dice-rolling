import { Presentation } from '@scenes/Gameplay/states/Presentation';
import { Preparation } from '@scenes/Gameplay/states/Preparation';
import { BattleSetup } from '@scenes/Gameplay/states/BattleSetup';
import { BattleStart } from '@scenes/Gameplay/states/BattleStart';
import { BattleEnd } from '@scenes/Gameplay/states/BattleEnd';

import { GameplayStates } from '@models/gameStates/GameplayStates';
import { setGameState } from '@helpers/setGameState';

const scene = 'gameplay';

export async function startGameplay() {
    console.log('Starting game...');
    setGameState(scene, GameplayStates.presentation);
    await Presentation();
    await transitionToPreparation();
}

export async function transitionToPreparation() {
    console.log('Transitioning to preparation phase...');
    setGameState(scene, GameplayStates.preparation);
    await Preparation();
    await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
    console.log('Transitioning to battle setup phase...');
    setGameState(scene, GameplayStates.battleSetup);
    await BattleSetup();
    await transitionToBattleStart();
}

export async function transitionToBattleStart() {
    console.log('Transitioning to battle start phase...');
    setGameState(scene, GameplayStates.battleStart);
    await BattleStart();
    await transitionToBattleEnd();
}

export async function transitionToBattleEnd() {
    console.log('Transitioning to battle end phase...');
    setGameState(scene, GameplayStates.battleEnd);
    await BattleEnd();
    // TODO Decide next phase or end game
}