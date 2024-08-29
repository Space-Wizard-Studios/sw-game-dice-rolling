export type DiceAction = {
    name: string;
    description: string;
}

type DiceActionType = 'Empty' | 'PhysicalAttack' | 'MagicAttack' | 'Defend' | 'Special';

export const DiceActions: Record<DiceActionType, DiceAction> = {
    Empty: {
        name: 'Empty',
        description: 'Do nothing.',
    },
    PhysicalAttack: {
        name: 'Physical Attack',
        description: 'Perform a physical attack.',
    },
    MagicAttack: {
        name: 'Magic Attack',
        description: 'Perform a magic attack.',
    },
    Defend: {
        name: 'Defend',
        description: 'Take a defensive stance to reduce incoming damage.',
    },
    Special: {
        name: 'Special',
        description: 'Use a special ability.',
    },
} as const;