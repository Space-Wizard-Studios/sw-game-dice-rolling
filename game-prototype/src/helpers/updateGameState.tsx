import { GameScenes } from '@models/GameScenes';
import { setGameState } from '@stores/GameContext';
import type { GameSceneType } from '@models/GameScenes';
import type { GameState } from '@models/GameStates';

export function updateSceneState(scene: GameSceneType, state: GameState) {
    setGameState({
        currentScene: GameScenes[scene],
        currentState: state,
    });
}