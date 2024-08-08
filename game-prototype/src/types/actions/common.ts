export type CommonAction = {
    name: string;
    description: string;
}

type CommonActionType = 'flee' | 'blah';

export const CommonActions: Record<CommonActionType, CommonAction> = {
    flee: {
        name: 'Flee',
        description: 'Attempt to flee from the battle.'
    },
    blah: {
        name: 'Blah',
        description: 'Attempt to blah.'
    },
} as const;
