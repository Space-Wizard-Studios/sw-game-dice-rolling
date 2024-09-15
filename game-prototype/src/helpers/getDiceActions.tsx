import type { Dice } from '@models/Dice';

export function getActionProbabilities(dice: Dice) {
	const totalActions = dice.actions.length;
	const actionCounts = dice.actions.reduce((acc, action) => {
		acc[action.name] = (acc[action.name] || 0) + 1;
		return acc;
	}, {} as Record<string, number>);

	return Object.entries(actionCounts).map(([name, count]) => ({
		name,
		probability: ((count / totalActions) * 100).toFixed(2),
	}));
}

export function getActionList(dice: Dice) {
	return dice.actions.map(action => action.name);
}

export function getMostProbableAction(dice: Dice) {
	const actionProbabilities = getActionProbabilities(dice);
	return actionProbabilities.reduce((max, action) =>
		parseFloat(action.probability) > parseFloat(max.probability) ? action : max
	);
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
