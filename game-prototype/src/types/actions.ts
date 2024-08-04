export type Action = {
    name: string;
    description: string;
}

export const Actions: { [key: string]: Action } = {
    empty: {
        name: 'Empty',
        description: 'Do nothing.'
    },
    attack: {
        name: 'Attack',
        description: 'Perform a physical attack on the enemy.'
    },
    defend: {
        name: 'Defend',
        description: 'Take a defensive stance to reduce incoming damage.'
    },
    heal: {
        name: 'Heal',
        description: 'Restore some health points.'
    },
    run: {
        name: 'Run',
        description: 'Attempt to flee from the battle.'
    }
};