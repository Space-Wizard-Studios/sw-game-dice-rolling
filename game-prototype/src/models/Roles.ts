import type { Health, Speed } from "@models/Characters";
import { type Action, DiceActions } from "@models/actions/DiceAction";
import { ComboActions, type ComboAction } from "@models/actions/ComboAction";

export type Role = {
    name: string;
    image: string;
    description: string;
    baseHealth: Health;
    baseSpeed: Speed;
    allowedActions: Action[];
    allowedCombos?: ComboAction[];
};

export type RoleType = 'Fighter' | 'Mage' | 'Rogue';

export const Roles: Record<RoleType, Role> = {
    Fighter: {
        name: "Fighter",
        image: "https://api.dicebear.com/9.x/initials/svg?seed=Fighter",
        description: "A strong and brave warrior skilled in combat.",
        baseHealth: {
            max: 100,
        },
        baseSpeed: {
            max: 10,
        },
        allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
        allowedCombos: [ComboActions.chargedAttack, ComboActions.parry],
    },
    Mage: {
        name: "Mage",
        image: "https://api.dicebear.com/9.x/initials/svg?seed=Mage",
        description: "A master of magical arts.",
        baseHealth: {
            max: 70,
        },
        baseSpeed: {
            max: 10,
        },
        allowedActions: [DiceActions.magicAttack, DiceActions.defend],
        allowedCombos: [ComboActions.magicBurst],
    },
    Rogue: {
        name: "Rogue",
        description: "A cunning and agile character skilled in stealth.",
        image: "https://api.dicebear.com/9.x/initials/svg?seed=Rogue",
        baseHealth: {
            max: 75,
        },
        baseSpeed: {
            max: 10,
        },
        allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
        allowedCombos: [],
    }
};