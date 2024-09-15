import { Targets, type ActionTarget } from '@models/actions/Target';

export type DiceAction = {
    name: string;
    description: string;
    targets: ActionTarget[];
    bgColor: string;
    textColor: string;
}

type ActionType = 'empty' | 'physicalAttack' | 'magicAttack' | 'defend' | 'special';

export const DiceActions: Record<ActionType, DiceAction> = {
    empty: {
        name: 'Empty',
        description: 'Do nothing.',
        targets: [Targets.self],
        bgColor: 'bg-gray-300',
        textColor: 'text-gray-800',
    },
    physicalAttack: {
        name: 'Physical Attack',
        description: 'Perform a physical attack.',
        targets: [Targets.enemySingle],
        bgColor: 'bg-red-300',
        textColor: 'text-red-800',
    },
    magicAttack: {
        name: 'Magic Attack',
        description: 'Perform a magic attack.',
        targets: [Targets.enemySingle, Targets.enemyAll],
        bgColor: 'bg-blue-300',
        textColor: 'text-blue-800',
    },
    defend: {
        name: 'Defend',
        description: 'Take a defensive stance to reduce incoming damage.',
        targets: [Targets.self],
        bgColor: 'bg-green-300',
        textColor: 'text-green-800',
    },
    special: {
        name: 'Special',
        description: 'Use a special ability.',
        targets: [Targets.any],
        bgColor: 'bg-purple-300',
        textColor: 'text-purple-800',
    },
} as const;