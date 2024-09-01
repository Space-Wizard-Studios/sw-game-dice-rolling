import { v4 as uuidv4 } from 'uuid';
import { getRandomElement } from '@helpers/getRandomElement';
import { Roles } from '@models/Roles';
import type { Character } from '@models/Characters';

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
        const role = getRandomElement(roles);
        if (!role) {
            console.error('Failed to get a random role. Roles array:', roles);
            continue;
        }
        const character: Character = {
            id: uuidv4(),
            name: `(${role.name}) ${prefix ? prefix + ' ' : ''} Character ${i + 1}`,
            image: 'https://via.placeholder.com/150',
            role: role,
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