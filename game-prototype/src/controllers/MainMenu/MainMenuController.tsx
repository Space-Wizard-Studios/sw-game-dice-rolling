import { updateGameScene } from '@helpers/updateGameState';
import type { GameSceneType } from '@models/scenes/Scenes';

const scene: GameSceneType = 'mainMenuScene';

export async function startMainMenu() {
	updateGameScene(scene, 'mainMenuPlaceholder');
}