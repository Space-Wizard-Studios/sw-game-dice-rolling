import { Character } from 'types/characters';
import { Roles } from 'types/roles';
import { DiceActions } from 'types/actions/dice';
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
        dice: [DiceActions.empty, DiceActions.empty, DiceActions.empty, DiceActions.empty] as D4,
    },
];