import { DiceActions } from './diceAction';
import type { DiceAction } from './diceAction';

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
        requiredActions: [DiceActions.PhysicalAttack, DiceActions.PhysicalAttack],
    },
    parry: {
        name: 'Parry',
        description: 'Block and counter an incoming attack.',
        requiredActions: [DiceActions.Defend, DiceActions.PhysicalAttack],
    }
} as const;