import type { Dice } from '@models/Dice';
import { DiceActions } from '@models/actions/DiceAction';

/**
 * Calculates the probabilities of each action on a dice.
 *
 * @param {Dice} dice - The dice object containing actions.
 * @returns {Array<{ key: keyof typeof DiceActions, name: string, probability: string }>} An array of objects representing the action probabilities.
 */
export function getActionProbabilities(dice: Dice) {
	const totalActions = dice.actions.length;
	const actionCounts = dice.actions.reduce((acc, action) => {
		acc[action.name] = (acc[action.name] || 0) + 1;
		return acc;
	}, {} as Record<string, number>);

	return Object.entries(actionCounts).map(([name, count]) => {
		const key = Object.keys(DiceActions).find(key => DiceActions[key as keyof typeof DiceActions].name === name);
		return {
			key: key as keyof typeof DiceActions,
			name,
			probability: ((count / totalActions) * 100).toFixed(2),
		};
	});
}

/**
 * Retrieves a list of action names from a dice.
 *
 * @param {Dice} dice - The dice object containing actions.
 * @returns {Array<string>} An array of action names.
 */
export function getActionList(dice: Dice) {
	return dice.actions.map(action => action.name);
}

/**
 * Finds the most probable actions on a dice.
 *
 * @param {Dice} dice - The dice object containing actions.
 * @returns {Array<{ key: keyof typeof DiceActions, name: string, probability: string }>} An array of objects representing the most probable actions.
 */
export function getMostProbableActions(dice: Dice) {
	const actionProbabilities = getActionProbabilities(dice);
	const maxProbability = Math.max(...actionProbabilities.map(action => parseFloat(action.probability)));
	return actionProbabilities.filter(action => parseFloat(action.probability) === maxProbability);
}

/**
 * Counts the occurrences of each action on a dice.
 *
 * @param {Dice} dice - The dice object containing actions.
 * @returns {Record<string, number>} An object where keys are action names and values are their counts.
 */
export function getActionsCount(dice: Dice) {
	return dice.actions.reduce((acc, action) => {
		acc[action.name] = (acc[action.name] || 0) + 1;
		return acc;
	}, {} as Record<string, number>);
}

/**
 * Counts the number of unique actions on a dice.
 *
 * @param {Dice} dice - The dice object containing actions.
 * @returns {number} The number of unique actions.
 */
export function getUniqueActionsCount(dice: Dice): number {
	const uniqueActions = new Set(dice.actions.map(action => action.name));
	return uniqueActions.size;
}