import { v4 as uuidv4 } from 'uuid';

import { getRandomElement } from '@helpers/getRandomElement';

import { Roles } from 'types/Roles';
import { Character } from 'types/Characters';

// import { DiceActions } from 'types/actions/DiceAction';
// import { D4, D6 } from 'types/Dice';
// const d4Example: D4 = [DiceActions.PhysicalAttack, DiceActions.Empty, DiceActions.MagicAttack, DiceActions.Defend];
// const d6Example: D6 = [DiceActions.PhysicalAttack, DiceActions.MagicAttack, DiceActions.Defend, DiceActions.Empty, DiceActions.PhysicalAttack, DiceActions.MagicAttack];

const roles = [Roles.Fighter, Roles.Mage, Roles.Rogue];

export function generateRandomCharacters(n: number): Character[] {
    const characters: Character[] = [];

    for (let i = 0; i < n; i++) {
        const character: Character = {
            id: uuidv4(),
            type: 'player',
            name: `Character ${i + 1}`,
            image: 'https://via.placeholder.com/150',
            role: getRandomElement(roles),
            health: {
                max: 100,
                current: 100,
            },
            speed: {
                max: 10,
                current: 10,
            },
        };

        characters.push(character);
    }

    return characters;
}