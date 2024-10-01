import { setGameState } from '@stores/GameContext';
import type { GameSceneType } from '@models/scenes/Scenes';
import type { SceneStateType } from '@models/states/States';
import { isValidSceneState } from '@helpers/validateSceneState';

export function updateGameScene(scene: GameSceneType, state: SceneStateType) {
	if (!isValidSceneState(scene, state)) {
		throw new Error(`Invalid state "${state}" for scene "${scene}"`);
	}

	setGameState({
		currentSceneState: {
			scene,
			state,
		},
	});
}