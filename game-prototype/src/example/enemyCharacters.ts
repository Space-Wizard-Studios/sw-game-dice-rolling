import { Roles } from 'types/Roles';

import { DiceActions } from 'types/actions/DiceAction';
import type { Character } from 'types/Characters';
import type { D4, D6 } from 'types/Dice';

const d4Example: D4 = [DiceActions.PhysicalAttack, DiceActions.Empty, DiceActions.MagicAttack, DiceActions.Defend];
const d6Example: D6 = [DiceActions.PhysicalAttack, DiceActions.MagicAttack, DiceActions.Defend, DiceActions.Empty, DiceActions.PhysicalAttack, DiceActions.MagicAttack];

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
        diceSet: [
            { name: 'd4', dice: d4Example },
            { name: 'd6', dice: d6Example },
        ],
    },
];