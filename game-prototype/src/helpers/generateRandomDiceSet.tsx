import { DiceActions } from "@models/actions/DiceAction";
import { getRandomElement } from "@helpers/getRandomElement";

import type { DiceType, D4, D6, D8, D10, D12, D20, D100 } from "@models/Dice";

export function generateRandomDiceSet(quantity: number, sides: number[]): DiceType[] {
	const diceSet: DiceType[] = [];

	for (let i = 0; i < quantity; i++) {
		const randomSides = getRandomElement(sides);
		const diceActions = Array.from({ length: randomSides }, () => getRandomElement(Object.values(DiceActions)));

		diceSet.push({
			name: `D${randomSides}`,
			dice: diceActions as (D4 | D6 | D8 | D10 | D12 | D20 | D100)
		});
	}

	return diceSet;
}