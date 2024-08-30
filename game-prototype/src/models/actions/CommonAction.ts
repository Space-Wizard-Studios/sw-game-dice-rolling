export type CommonAction = {
    name: string;
    description: string;
}

type CommonActionType = 'flee';

export const CommonActions: Record<CommonActionType, CommonAction> = {
    flee: {
        name: 'Flee',
        description: 'Attempt to flee from the battle.'
    },
} as const;
