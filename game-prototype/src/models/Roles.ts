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

// TODO specify the type of the Roles object

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
    },
    Mage: {
        name: "Mage",
        description: "A master of magical arts.",
        baseHealth: {
            max: 70,
        },
        allowedActions: [DiceActions.magicAttack, DiceActions.defend],
        allowedCombos: [ComboActions.magicBurst],
    },
    Rogue: {
        name: "Rogue",
        description: "A cunning and agile character skilled in stealth.",
        baseHealth: {
            max: 75,
        },
        allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
        allowedCombos: [],
    }
};