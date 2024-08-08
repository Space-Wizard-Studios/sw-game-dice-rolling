import { DiceActions } from "./actions/dice";
import { ComboActions } from "./actions/combo";

import type { DiceAction } from "./actions/dice";
import type { ComboAction } from "./actions/combo";

export type Role = {
    name: string;
    description: string;
    allowedActions: DiceAction[];
    allowedCombos?: ComboAction[];
};

export const Roles: { [key: string]: Role } = {
    Fighter: {
        name: "Fighter",
        description: "A strong and brave warrior skilled in combat.",
        allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
        allowedCombos: [ComboActions.chargedAttack, ComboActions.parry],
    },
    Assassin: {
        name: "Assassin",
        description: "A stealthy and agile character skilled in deception and evasion.",
        allowedActions: [DiceActions.physicalAttack, DiceActions.magicAttack],
        allowedCombos: [ComboActions.chargedAttack],
    }
};