import { GameStates } from '@models/states/States';
import type { SceneState, SceneStateType } from '@models/states/States';

/**
 * Retrieves the name of the game state.
 * 
 * @param {SceneStateType} stateType - The type of the game state.
 * @returns {string} The name of the game state.
 */
export const getGameStateName = (stateType: SceneStateType): string => {
	return GameStates[stateType]?.name;
};

/**
 * Retrieves the icon of the game state.
 * 
 * @param {SceneStateType} stateType - The type of the game state.
 * @returns {string} The icon of the game state.
 */
export const getGameStateIcon = (stateType: SceneStateType): string => {
	return GameStates[stateType]?.icon;
}

/**
 * Retrieves the background of the game state.
 * 
 * @param {SceneStateType} stateType - The type of the game state.
 * @returns {string} The background of the game state.
 */
export const getGameStateBg = (stateType: SceneStateType): string => {
	return GameStates[stateType]?.bg;
}

/**
 * Retrieves the icon background of the game state.
 * 
 * @param {SceneStateType} stateType - The type of the game state.
 * @returns {string} The icon background of the game state.
 */
export const getGameStateIconBg = (stateType: SceneStateType): string => {
	return GameStates[stateType]?.iconBg;
}

/**
 * Retrieves the complete game state information including name, icon, background, and icon background.
 * 
 * @param {SceneStateType} stateType - The type of the game state.
 * @returns {Object} An object containing the name, icon, background, and icon background of the game state.
 */
export const getGameState = (stateType: SceneStateType): SceneState => {
	return GameStates[stateType];
}