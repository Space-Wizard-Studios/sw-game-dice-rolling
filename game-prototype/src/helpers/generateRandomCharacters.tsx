import { v4 as uuidv4 } from 'uuid';
import { getRandomElement } from '@helpers/getRandomElement';
import { Roles } from 'types/Roles';
import type { Character } from 'types/Characters';

const roles = [Roles.Fighter, Roles.Mage, Roles.Rogue];

/** 
 * Generates a list of random characters with the specified prefix.
 *
 * @param {number} n - The number of characters to generate.
 * @param {string} prefix - The prefix to add to the character names.
 * @returns {Character[]} - An array of randomly generated characters.
 */

export function generateRandomCharacters(n: number, prefix: string = ''): Character[] {
    const characters: Character[] = [];

    for (let i = 0; i < n; i++) {
        const character: Character = {
            id: uuidv4(),
            name: `${prefix ? prefix + ' ' : ''}Character ${i + 1}`,
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