import { getMostProbableAction } from "@helpers/getDiceActions";
import type { Dice } from "@models/Dice";
import { type DiceAction, DiceActions } from "@models/actions/DiceAction";

export function getDiceColor(dice: Dice): string {
    const action = getMostProbableAction(dice);
    const diceBG = DiceActions[action.key as keyof typeof DiceActions].bgColor;
    const diceText = DiceActions[action.key as keyof typeof DiceActions].textColor;
    return `${diceBG} ${diceText}`;
}