import { GameStates } from '@models/states/States';
import type { GameState, GameStateType } from '@models/states/States';

/**
 * Retrieves the name of the game state.
 * 
 * @param {GameStateType} stateType - The type of the game state.
 * @returns {string | undefined} The name of the game state.
 */
export const getGameStateName = (stateType: GameStateType) => {
	return GameStates[stateType]?.name;
};

/**
 * Retrieves the icon of the game state.
 * 
 * @param {GameStateType} stateType - The type of the game state.
 * @returns {string | undefined} The icon of the game state.
 */
export const getGameStateIcon = (stateType: GameStateType) => {
	return GameStates[stateType]?.icon;
}

/**
 * Retrieves the background of the game state.
 * 
 * @param {GameStateType} stateType - The type of the game state.
 * @returns {string | undefined} The background of the game state.
 */
export const getGameStateBg = (stateType: GameStateType) => {
	return GameStates[stateType]?.bg;
}

/**
 * Retrieves the icon background of the game state.
 * 
 * @param {GameStateType} stateType - The type of the game state.
 * @returns {string | undefined} The icon background of the game state.
 */
export const getGameStateIconBg = (stateType: GameStateType) => {
	return GameStates[stateType]?.iconBg;
}

/**
 * Retrieves the complete game state information including name, icon, background, and icon background.
 * 
 * @param {GameStateType} stateType - The type of the game state.
 * @returns {Object} An object containing the name, icon, background, and icon background of the game state.
 */
export const getGameState = (stateType: GameStateType): GameState => {
	return GameStates[stateType];
}