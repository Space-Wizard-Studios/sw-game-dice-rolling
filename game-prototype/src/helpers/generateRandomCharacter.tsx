import { v4 as uuidv4 } from 'uuid';
import { getRandomElement } from '@helpers/getRandomElement';
import { PlayableRoles, EnemyRoles } from '@models/Role';
import type { Role } from '@models/Role';
import type { Character } from '@models/Character';
import { uniqueNamesGenerator, names, type Config } from 'unique-names-generator';

const config: Config = {
	dictionaries: [names],
	separator: ' ',
}

export function generateRandomCharacter(n: number, prefix: string = '', isEnemy: boolean = false): Character[] {
	const roles: Role[] = isEnemy
		? Object.values(EnemyRoles)
		: Object.values(PlayableRoles);
	const characters: Character[] = [];

	for (let i = 0; i < n; i++) {
		const role = getRandomElement(roles);
		const characterName: string = uniqueNamesGenerator(config);

		if (!role) {
			console.error('Failed to get a random role. Roles array:', roles);
			continue;
		}
		const character: Character = {
			id: uuidv4(),
			name: `${prefix ? prefix + ' ' : ''} ${characterName}`,
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