export type DiceAction = {
    name: string;
    description: string;
}

type DiceActionType = 'empty' | 'physicalAttack' | 'magicAttack' | 'defend' | 'special';

export const DiceActions: Record<DiceActionType, DiceAction> = {
    empty: {
        name: 'Empty',
        description: 'Do nothing.',
    },
    physicalAttack: {
        name: 'Physical Attack',
        description: 'Perform a physical attack.',
    },
    magicAttack: {
        name: 'magic Attack',
        description: 'Perform a magic attack.',
    },
    defend: {
        name: 'Defend',
        description: 'Take a defensive stance to reduce incoming damage.',
    },
    special: {
        name: 'Special',
        description: 'Use a special ability.',
    },
} as const;