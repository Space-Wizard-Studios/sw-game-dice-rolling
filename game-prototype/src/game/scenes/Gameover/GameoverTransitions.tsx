import { Presentation } from '@scenes/Gameplay/states/Presentation';

import { GameplayStates } from '@models/gameStates/GameplayStates';
import { setGameState } from '@helpers/setGameState';

import { GameScenes } from '@models/GameScenes';

const scene = GameScenes.gameover;

export async function startGameover() {
    console.log('Starting game...');
    // setGameState(GameplayStates.presentation, scene);
    await Presentation();
}