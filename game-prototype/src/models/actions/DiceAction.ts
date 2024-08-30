import { Targets, type ActionTarget } from '@models/actions/Target';

export type Action = {
    name: string;
    description: string;
    targets: ActionTarget[];
}

type ActionType = 'empty' | 'physicalAttack' | 'magicAttack' | 'defend' | 'special';

export const DiceActions: Record<ActionType, Action> = {
    empty: {
        name: 'Empty',
        description: 'Do nothing.',
        targets: [Targets.self],        
    },
    physicalAttack: {
        name: 'Physical Attack',
        description: 'Perform a physical attack.',
        targets: [Targets.enemySingle],
    },
    magicAttack: {
        name: 'Magic Attack',
        description: 'Perform a magic attack.',
        targets: [Targets.enemySingle, Targets.enemyAll],
    },
    defend: {
        name: 'Defend',
        description: 'Take a defensive stance to reduce incoming damage.',
        targets: [Targets.self],
    },
    special: {
        name: 'Special',
        description: 'Use a special ability.',
        targets: [Targets.any],
    },
} as const;