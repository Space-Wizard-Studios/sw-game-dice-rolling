import { type Health } from "@models/Characters";
import { type Action, DiceActions } from "@models/actions/DiceAction";
import { ComboActions, type ComboAction } from "@models/actions/ComboAction";

export type Role = {
    name: string;
    description: string;
    baseHealth: Health;
    allowedActions: Action[];
    allowedCombos?: ComboAction[];
};

export const Roles: { [key: string]: Role } = {
    Fighter: {
        name: "Fighter",
        description: "A strong and brave warrior skilled in combat.",
        baseHealth: {
            max: 100,
        },
        allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
        allowedCombos: [ComboActions.chargedAttack, ComboActions.parry],
    },
    Assassin: {
        name: "Assassin",
        description: "A stealthy and agile character skilled in deception and evasion.",
        baseHealth: {
            max: 80,
        },
        allowedActions: [DiceActions.physicalAttack, DiceActions.magicAttack],
        allowedCombos: [ComboActions.chargedAttack],
    }
};