import { updateGameSceneState } from '@helpers/updateGameState';
import type { GameSceneType } from '@models/scenes/Scenes';

const scene: GameSceneType = 'gameoverScene';

export async function startGameover() {
	console.log('Starting gameover...');
	updateGameSceneState(scene, 'gameoverPlaceholder');
}