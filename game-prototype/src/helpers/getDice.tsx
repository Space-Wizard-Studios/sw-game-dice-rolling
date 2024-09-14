import type { DiceType } from '@models/Dice';

export function getActionProbabilities(dice: DiceType) {
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

export function getActionList(dice: DiceType) {
    return dice.actions.map(action => action.name);
}

export function getMostProbableAction(dice: DiceType) {
    const actionProbabilities = getActionProbabilities(dice);
    return actionProbabilities.reduce((max, action) =>
        parseFloat(action.probability) > parseFloat(max.probability) ? action : max
    );
}