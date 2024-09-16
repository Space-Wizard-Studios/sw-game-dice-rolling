import type { GameplaySceneType } from "@models/scenes/GameplayScene";
import type { GameoverSceneType } from "@models/scenes/GameoverScene";
import type { MainMenuSceneType } from "@models/scenes/MainMenuScene";

import { GameplayScenes } from "@models/scenes/GameplayScene";
import { GameoverScenes } from "@models/scenes/GameoverScene";
import { MainMenuScenes } from "@models/scenes/MainMenuScene";

export type GameSceneType = GameplaySceneType | GameoverSceneType | MainMenuSceneType;

export type GameScene = {
	name: string;
	bg: string;
};

export const GameScenes: Record<GameSceneType, GameScene> = {
	...GameplayScenes,
	...GameoverScenes,
	...MainMenuScenes,
} as const;