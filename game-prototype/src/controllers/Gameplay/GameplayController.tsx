import { GameplayIntroduction } from '@controllers/Gameplay/states/Introduction';
import { InitialSetup } from '@controllers/Gameplay/states/InitialSetup';
import { BattleSetup } from '@controllers/Gameplay/states/BattleSetup';
import { BattleTurn } from '@controllers/Gameplay/states/BattleTurn';
import { BattleEnd } from '@controllers/Gameplay/states/BattleEnd';
import { updateGameState, updateGameSceneState } from '@helpers/updateGameState';

import type { GameplaySceneType } from '@models/scenes/GameplayScene';
import type { GameplayStateType } from '@models/states/GameplayStates';
import { startGameover } from '@controllers/Gameover/GameoverController';

let scene: GameplaySceneType;
let state: GameplayStateType;

export async function transitionToIntroduction() {
	scene = 'gameplayScene';
	state = 'gameplayIntroduction';
	updateGameSceneState(scene, state);
	await GameplayIntroduction();
	await transitionToInitialSetup();
}

export async function transitionToInitialSetup() {
	state = 'gameplayInitialSetup';
	updateGameState(state);
	await InitialSetup();
	await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
	state = 'gameplayBattleSetup';
	updateGameState(state);
	await BattleSetup();
	await transitionToBattleTurn();
}

export async function transitionToBattleTurn() {
	state = 'gameplayBattleTurn';
	updateGameState(state);
	await BattleTurn();

	const result = 'defeat';
	await transitionToBattleEnd(result);
}

export async function transitionToBattleEnd(result: 'victory' | 'defeat') {
	state = 'gameplayBattleResult';
	updateGameState(state);
	await BattleEnd(result);

	if (result === 'defeat') {
		startGameover();
	}
}