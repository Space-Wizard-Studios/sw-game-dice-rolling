import { GameScenes } from "@models/scenes/Scenes";
import type { GameScene, GameSceneType } from "@models/scenes/Scenes";

export const getGameSceneName = (scene: GameSceneType): string => {
	return GameScenes[scene]?.name;
}

export const getGameSceneBg = (scene: GameSceneType): string => {
	return GameScenes[scene]?.bg;
}

export const getGameScene = (scene: GameSceneType): GameScene => {
	return GameScenes[scene];
}