import { GameScenes } from '@models/GameScenes';
import { gameStateStore, setGameStateStore } from '@stores/GameStateStore';
import type { GameSceneType } from '@models/GameScenes';
import type { GameState } from '@models/GameStates';

function isStateAllowedInScene(scene: GameSceneType, state: string): boolean {
    return GameScenes[scene].allowedStates.includes(state);
}

export function setGameState(scene: GameSceneType, state: GameState) {
    if (!isStateAllowedInScene(scene, state.name)) {
        throw new Error(`State ${state.name} is not allowed in scene ${scene}`);
    }
    setGameStateStore({
        currentScene: GameScenes[scene],
        currentState: state,
    });
}