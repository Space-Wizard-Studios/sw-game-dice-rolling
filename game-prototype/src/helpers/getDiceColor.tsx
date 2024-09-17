import { getMostProbableActions } from "@helpers/getDiceActions";
import type { Dice } from "@models/Dice";
import { type DiceAction, DiceActions } from "@models/actions/DiceAction";

export function getDiceColors(dice: Dice): string[] {
    const actions = getMostProbableActions(dice);

    if (actions.length === 1) {
        const action = actions[0];
        const diceBG = DiceActions[action.key as keyof typeof DiceActions].bgColor;
        return [diceBG, diceBG];
    } else if (actions.length >= 2) {
        return actions.map(action => DiceActions[action.key as keyof typeof DiceActions].bgColor);
    } else {
        return [];
    }
}