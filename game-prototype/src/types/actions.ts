export type Action = {
    name: string;
    description: string;
}

export type Combo = {
    name: string;
    description: string;
    requiredActions: Action[];
};

export const Actions: { [key: string]: Action } = {
    empty: {
        name: 'Empty',
        description: 'Do nothing.',
    },
    attack: {
        name: 'Attack',
        description: 'Perform a physical attack on the enemy.',
    },
    defend: {
        name: 'Defend',
        description: 'Take a defensive stance to reduce incoming damage.',
    },
    heal: {
        name: 'Heal',
        description: 'Restore some health points.'
    },
    run: {
        name: 'Run',
        description: 'Attempt to flee from the battle.'
    },
    parry: {
        name: 'Parry',
        description: 'Block and counter an incoming attack.'
    }
};

export const Combos: { [key: string]: Combo } = {
    chargedAttack: {
        name: 'Charged Attack',
        description: 'Charge up an attack to deal massive damage.',
        requiredActions: [Actions.attack, Actions.attack],
    },
    parry: {
        name: 'Parry',
        description: 'Block and counter an incoming attack.',
        requiredActions: [Actions.defend, Actions.attack],
    }
};