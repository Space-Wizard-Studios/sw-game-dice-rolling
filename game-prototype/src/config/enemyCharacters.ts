import { Character } from 'types/characters';
import { Roles } from 'types/roles';
import { Actions } from 'types/actions';
import { D4 } from 'types/dice';

export const enemyCharacters: Character[] = [
    {
        name: "Enemy 1",
        role: Roles.Fighter,
        health: {
            max: 100,
            current: 100,
        },
        speed: {
            max: 10,
        },
        die: [Actions.empty, Actions.empty, Actions.empty, Actions.empty] as D4,
    },
];

export const diceOptions = {
    1: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
    2: [Actions.attack, Actions.attack, Actions.defend, Actions.empty] as D4,
    3: [Actions.attack, Actions.defend, Actions.defend, Actions.empty] as D4,
    4: [Actions.attack, Actions.empty, Actions.attack, Actions.empty] as D4,
};

export type DiceOptions = keyof typeof diceOptions;