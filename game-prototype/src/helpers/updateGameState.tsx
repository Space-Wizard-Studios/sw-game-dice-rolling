import { GameScenes } from '@models/scenes/Scenes';
import { GameStates } from '@models/states/States';
import { setGameState } from '@stores/GameContext';

import type { GameSceneType } from '@models/scenes/Scenes';
import type { GameStateType } from '@models/states/States';

export function updateGameScene(scene: GameSceneType) {
    setGameState({
        currentScene: scene,
    });
}

export function updateGameState(state: GameStateType) {
    setGameState({
        currentState: state,
    });
}

export function updateGameSceneState(scene: GameSceneType, state: GameStateType) {
    updateGameScene(scene);
    updateGameState(state);
}