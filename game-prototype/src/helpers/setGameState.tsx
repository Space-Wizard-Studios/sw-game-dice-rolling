import { GameScenes } from '@models/GameScenes';
import { setGameStateStore } from '@stores/GameStateStore';
import type { GameSceneType } from '@models/GameScenes';
import type { GameState } from '@models/GameStates';


export function setGameState(scene: GameSceneType, state: GameState) {
    setGameStateStore({
        currentScene: GameScenes[scene],
        currentState: state,
    });
}