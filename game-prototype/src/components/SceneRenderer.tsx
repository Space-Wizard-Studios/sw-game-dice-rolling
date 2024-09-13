import { createEffect, onMount } from 'solid-js';
import { useGameManager } from "@stores/GameContext";
import { updateGameScene } from "@helpers/updateGameState";
import type { GameSceneType } from "@models/scenes/Scenes";

import { GameplayScene } from '@components/Scenes/Gameplay';
import { GameoverScene } from '@components/Scenes/Gameover';
import { MainMenuScene } from '@components/Scenes/MainMenu';

function renderScene(scene: GameSceneType | undefined) {
	switch (scene) {
		case 'gameplayScene':
			console.log('Rendering Gameplay');
			return <GameplayScene />;
		case 'gameoverScene':
			console.log('Rendering Game Over');
			return <GameoverScene />;
		case 'mainMenuScene':
			console.log('Rendering Main Menu');
			return <MainMenuScene />;
		default:
			return null;
	}
}

export const SceneRenderer = () => {
	const [gameManager] = useGameManager();

	return (
		<main class="relative h-dvh w-dvh overflow-hidden">
			{renderScene(gameManager.currentScene)}
		</main>
	);
};