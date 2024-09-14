import { DiceActions } from "@models/actions/DiceAction";
import { getRandomElement } from "@helpers/getRandomElement";
import type { DiceType, DiceActionsMap, ExtractSides } from "@models/Dice";

export function generateRandomDice(quantity: number, possibleSides: (keyof DiceActionsMap)[]): DiceType[] {
	const diceSet: DiceType[] = [];

	for (let i = 0; i < quantity; i++) {
		const sides = getRandomElement(possibleSides) as keyof DiceActionsMap;
		const actions = Array.from({ length: sides }, () => getRandomElement(Object.values(DiceActions)));
		const dice: DiceType = {
			name: `D${sides}`,
			actions: actions as DiceActionsMap[typeof sides],
			sides: sides as ExtractSides<DiceActionsMap[typeof sides]>,
		};
		diceSet.push(dice);
	}

	return diceSet;
}