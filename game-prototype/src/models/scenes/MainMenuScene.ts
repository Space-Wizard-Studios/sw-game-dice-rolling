import type { GameScene } from "@models/scenes/Scenes";

export type MainMenuSceneType = 'mainMenuScene';

export const MainMenuScenes: Record<MainMenuSceneType, GameScene> = {
	mainMenuScene: {
		name: "Gameover Placeholder",
		bg: "placeholder-bg",
	},
} as const;