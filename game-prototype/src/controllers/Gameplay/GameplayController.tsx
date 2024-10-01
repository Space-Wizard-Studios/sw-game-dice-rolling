import { GameplayIntroduction } from '@controllers/Gameplay/states/Introduction';
import { InitialSetup } from '@controllers/Gameplay/states/InitialSetup';
import { BattleSetup } from '@controllers/Gameplay/states/BattleSetup';
import { BattleTurn } from '@controllers/Gameplay/states/BattleTurn';
import { BattleEnd } from '@controllers/Gameplay/states/BattleEnd';
import { updateGameScene } from '@helpers/updateGameState';

import type { GameplaySceneType } from '@models/scenes/GameplayScene';
import type { GameplayStateType } from '@models/states/GameplayStates';
import { startGameover } from '@controllers/Gameover/GameoverController';

let scene: GameplaySceneType = 'gameplayScene';
let state: GameplayStateType;

export async function transitionToIntroduction() {
	state = 'gameplayIntroduction';
	updateGameScene(scene, state);
	await GameplayIntroduction();
	await transitionToInitialSetup();
}

export async function transitionToInitialSetup() {
	state = 'gameplayInitialSetup';
	updateGameScene(scene, state);
	await InitialSetup();
	await transitionToBattleSetup();
}

export async function transitionToBattleSetup() {
	state = 'gameplayBattleSetup';
	updateGameScene(scene, state);
	await BattleSetup();
	await transitionToBattleTurn();
}

export async function transitionToBattleTurn() {
	state = 'gameplayBattleTurn';
	updateGameScene(scene, state);
	await BattleTurn();

	const result = 'defeat';
	await transitionToBattleEnd(result);
}

export async function transitionToBattleEnd(result: 'victory' | 'defeat') {
	state = 'gameplayBattleResult';
	updateGameScene(scene, state);
	await BattleEnd(result);

	if (result === 'defeat') {
		startGameover();
	}
}