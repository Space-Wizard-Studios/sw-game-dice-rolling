import { GameScenes } from '@models/GameScenes';
import { setGameState } from '@stores/GameContext';
import type { GameSceneType } from '@models/GameScenes';
import type { GameState } from '@models/GameStates';

/**
 * Updates the game state with the provided scene and state.
 *
 * @param {GameSceneType} scene - The scene to update to.
 * @param {GameState} state - The new state of the game.
 */
export function updateSceneState(scene: GameSceneType, state: GameState) {
    setGameState({
        currentScene: GameScenes[scene],
        currentState: state,
    });
}