import { Presentation } from '@scenes/Gameplay/states/Presentation';

import { GameoverStates } from '@models/gameStates/GameoverStates';
import { setGameState } from '@helpers/setGameState';

import { GameScenes } from '@models/GameScenes';

const scene = 'gameover';

export async function startGameover() {
    console.log('Starting game...');
    setGameState(scene, GameoverStates.gameOverPlaceholder);
    await Presentation();
}