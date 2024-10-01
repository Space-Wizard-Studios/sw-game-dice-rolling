import type { GameSceneType } from '@models/scenes/Scenes';
import type { SceneStateType } from '@models/states/States';
import { GameplayStates } from '@models/states/GameplayStates';
import { GameoverStates } from '@models/states/GameoverStates';
import { MainMenuStates } from '@models/states/MainMenuStates';

export function isValidSceneState(scene: GameSceneType, state: SceneStateType): boolean {
	switch (scene) {
		case 'gameplayScene':
			return state in GameplayStates;
		case 'gameoverScene':
			return state in GameoverStates;
		case 'mainMenuScene':
			return state in MainMenuStates;
		default:
			return false;
	}
}