import { Presentation } from '@scenes/Gameplay/states/Presentation';

import { GameoverStates } from '@models/gameStates/GameoverStates';

import { updateSceneState } from '@helpers/updateGameState';

const scene = 'gameover';

export async function startGameover() {
    console.log('Starting game...');
    updateSceneState(scene, GameoverStates.gameoverPlaceholder);
    await Presentation();
}