import { GameScenes } from "@models/scenes/Scenes";
import type { GameScene, GameSceneType } from "@models/scenes/Scenes";

/**
 * Retrieves the name of a game scene.
 *
 * @param {GameSceneType} scene - The type of the game scene.
 * @returns {string} The name of the game scene.
 */
export const getGameSceneName = (scene: GameSceneType): string => {
	return GameScenes[scene]?.name;
}

/**
 * Retrieves the background of a game scene.
 *
 * @param {GameSceneType} scene - The type of the game scene.
 * @returns {string} The background of the game scene.
 */
export const getGameSceneBg = (scene: GameSceneType): string => {
	return GameScenes[scene]?.bg;
}

/**
 * Retrieves the game scene object.
 *
 * @param {GameSceneType} scene - The type of the game scene.
 * @returns {GameScene} The game scene object.
 */
export const getGameScene = (scene: GameSceneType): GameScene => {
	return GameScenes[scene];
}