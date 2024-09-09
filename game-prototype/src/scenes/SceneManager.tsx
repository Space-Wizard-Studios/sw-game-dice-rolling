import { onMount } from "solid-js";
import { createEffect } from "solid-js";
import { GameProvider, useGameManager } from "@stores/GameContext";

import { GameplayScene } from "@scenes/Gameplay/GameplayScene";
import { GameoverScene } from "@scenes/Gameover/GameoverScene";

import { GameScenes, type GameScene } from "@models/GameScenes";


function renderScene(scene: GameScene) {
    switch (scene) {
        case GameScenes.gameplay:
            return <GameplayScene />;
        case GameScenes.gameover:
            return <GameoverScene />;
        default:
            return null;
    }
}

export const SceneManager = () => {
    const [gameManager] = useGameManager();

    console.log('SceneManager mounted in', gameManager.currentScene.name, '/', gameManager.currentState.name);
    return (
        <GameProvider>
            <main class="relative h-dvh w-dvh text-white">
                {renderScene(gameManager.currentScene) ?? <GameplayScene />}
            </main>
        </GameProvider>
    );
};