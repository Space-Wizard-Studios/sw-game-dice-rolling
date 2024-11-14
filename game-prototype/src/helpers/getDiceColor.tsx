import { getMostProbableActions } from "@helpers/getDiceActions";
import type { Dice } from "@models/Dice";
import { DiceActions } from "@models/DiceAction";

type DiceColor = {
	background: string;
	text: string;
};

export function getDiceColors(dice: Dice): DiceColor[] {
	const actions = getMostProbableActions(dice);

	if (actions.length === 1) {
		const action = actions[0];
		const diceBG = DiceActions[action.key as keyof typeof DiceActions].colors.background;
		const diceText = DiceActions[action.key as keyof typeof DiceActions].colors.text;
		return [{ background: diceBG, text: diceText }, { background: diceBG, text: diceText }];
	} else if (actions.length >= 2) {
		return actions.map(action => ({
			background: DiceActions[action.key as keyof typeof DiceActions].colors.background,
			text: DiceActions[action.key as keyof typeof DiceActions].colors.text
		}));
	} else {
		return [];
	}
}