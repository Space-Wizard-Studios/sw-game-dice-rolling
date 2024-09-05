import { GameplayStates } from "@models/gameStates/GameplayStates";
import { GameScenes } from "@models/GameScenes";
import { createStore } from "solid-js/store";
import type { GameManager } from "../game/GameContext";


export const [gameStateStore, setGameStateStore] = createStore<GameManager>({
    currentScene: GameScenes.gameplay,
    currentState: GameplayStates.presentation,
});
