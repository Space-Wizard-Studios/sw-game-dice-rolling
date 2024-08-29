import { DiceActions } from "./actions/DiceAction";

import type { DiceAction } from "./actions/DiceAction";
import { ComboActions, type ComboAction } from "@models/actions/ComboAction";

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
        allowedActions: [DiceActions.PhysicalAttack, DiceActions.Defend],
        allowedCombos: [ComboActions.chargedAttack, ComboActions.parry],
    },
    Assassin: {
        name: "Assassin",
        description: "A stealthy and agile character skilled in deception and evasion.",
        allowedActions: [DiceActions.PhysicalAttack, DiceActions.MagicAttack],
        allowedCombos: [ComboActions.chargedAttack],
    }
};