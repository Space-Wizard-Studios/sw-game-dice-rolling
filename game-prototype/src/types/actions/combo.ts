import { DiceActions } from './dice';
import type { DiceAction } from './dice';

export type ComboAction = {
    name: string;
    description: string;
    requiredActions: DiceAction[];
};

type ComboActionType = 'chargedAttack' | 'parry';

export const ComboActions: Record<ComboActionType, ComboAction> = {
    chargedAttack: {
        name: 'Charged Attack',
        description: 'Charge up an attack to deal massive damage.',
        requiredActions: [DiceActions.physicalAttack, DiceActions.physicalAttack],
    },
    parry: {
        name: 'Parry',
        description: 'Block and counter an incoming attack.',
        requiredActions: [DiceActions.defend, DiceActions.physicalAttack],
    }
} as const;