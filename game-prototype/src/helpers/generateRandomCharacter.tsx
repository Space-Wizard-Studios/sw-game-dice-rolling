import { v4 as uuidv4 } from 'uuid';
import { getRandomElement } from '@helpers/getRandomElement';
import { PlayableRoles, EnemyRoles } from '@models/Role';
import type { Role } from '@models/Role';
import type { Character } from '@models/Character';

/** 
 * Generates a list of random characters with the specified prefix.
 *
 * @param {number} n - The number of characters to generate.
 * @param {string} prefix - The prefix to add to the character names.
 * @returns {Character[]} - An array of randomly generated characters.
 */

export function generateRandomCharacter(n: number, prefix: string = '', isEnemy: boolean = false): Character[] {
	const roles: Role[] = isEnemy
		? Object.values(EnemyRoles)
		: Object.values(PlayableRoles);
	const characters: Character[] = [];

	for (let i = 0; i < n; i++) {
		const role = getRandomElement(roles);
		if (!role) {
			console.error('Failed to get a random role. Roles array:', roles);
			continue;
		}
		const character: Character = {
			id: uuidv4(),
			name: `${prefix ? prefix + ' ' : ''}${i + 1}`,
			role: role,
			health: {
				max: role.baseHealth.max,
				current: role.baseHealth.max,
			},
			speed: {
				max: role.baseSpeed.max,
				current: role.baseSpeed.max,
			},
			diceCapacity: role.baseDiceCapacity,
		};

		characters.push(character);
	}

	return characters;
}