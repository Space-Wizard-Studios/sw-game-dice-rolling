import type { Dice } from '@models/Dice';
import { DiceActions } from '@models/actions/DiceAction';

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

export function getActionList(dice: Dice) {
	return dice.actions.map(action => action.name);
}


export function getMostProbableActions(dice: Dice) {
	const actionProbabilities = getActionProbabilities(dice);
	const maxProbability = Math.max(...actionProbabilities.map(action => parseFloat(action.probability)));
	return actionProbabilities.filter(action => parseFloat(action.probability) === maxProbability);
}

export function getActionsCount(dice: Dice) {
	return (
		dice.actions.reduce((acc, action) => {
			acc[action.name] = (acc[action.name] || 0) + 1;
			return acc;
		}, {} as Record<string, number>)
	);
}

export function getUniqueActionsCount(dice: Dice): number {
	const uniqueActions = new Set(dice.actions.map(action => action.name));
	return uniqueActions.size;
}
