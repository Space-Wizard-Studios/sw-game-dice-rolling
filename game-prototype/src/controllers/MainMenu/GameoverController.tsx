import { updateGameSceneState } from '@helpers/updateGameState';
import type { GameSceneType } from '@models/scenes/Scenes';

const scene: GameSceneType = 'mainMenuScene';

export async function startGameover() {
    console.log('Starting gameover...');
    updateGameSceneState(scene, 'mainMenuPlaceholder');
}