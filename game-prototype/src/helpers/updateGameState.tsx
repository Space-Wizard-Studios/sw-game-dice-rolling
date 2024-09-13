import { setGameState } from '@stores/GameContext';

import type { GameSceneType } from '@models/scenes/Scenes';
import type { GameStateType } from '@models/states/States';

/**
 * Updates the current game scene.
 * 
 * @param {GameSceneType} scene - The new game scene to set.
 */
export function updateGameScene(scene: GameSceneType) {
	setGameState({
		currentScene: scene,
	});
}

/**
 * Updates the current game state.
 * 
 * @param {GameStateType} state - The new game state to set.
 */
export function updateGameState(state: GameStateType) {
	setGameState({
		currentState: state,
	});
}

/**
 * Updates both the game scene and game state.
 * 
 * @param {GameSceneType} scene - The new game scene to set.
 * @param {GameStateType} state - The new game state to set.
 */
export function updateGameSceneState(scene: GameSceneType, state: GameStateType) {
	updateGameScene(scene);
	updateGameState(state);
}