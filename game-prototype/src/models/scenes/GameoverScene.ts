import type { GameScene } from "@models/scenes/Scenes";
import { GameoverStates } from "@models/states/GameoverStates";

export type GameoverSceneType = 'gameoverScene';

export const GameoverScenes: Record<GameoverSceneType, GameScene> = {
	gameoverScene: {
		name: "Gameover Placeholder",
		bg: "placeholder-bg",
		defaultState: 'gameoverPlaceholder',
	},
} as const;