import { getMostProbableActions } from "@helpers/getDiceActions";
import type { Dice } from "@models/Dice";
import { DiceActions } from "@models/actions/DiceAction";

type DiceColor = {
    bgColor: string;
    textColor: string;
};

export function getDiceColors(dice: Dice): DiceColor[] {
    const actions = getMostProbableActions(dice);

    if (actions.length === 1) {
        const action = actions[0];
        const diceBG = DiceActions[action.key as keyof typeof DiceActions].bgColor;
        const diceText = DiceActions[action.key as keyof typeof DiceActions].textColor;
        return [{ bgColor: diceBG, textColor: diceText }, { bgColor: diceBG, textColor: diceText }];
    } else if (actions.length >= 2) {
        return actions.map(action => ({
            bgColor: DiceActions[action.key as keyof typeof DiceActions].bgColor,
            textColor: DiceActions[action.key as keyof typeof DiceActions].textColor
        }));
    } else {
        return [];
    }
}