export type ActionTarget = {
	name: string;
	description: string;
	category: 'enemy' | 'ally' | 'self' | 'any' | 'nothing';
	quantity: 'none' | 'all' | number;
}

type TargetType = 'allySingle' | 'allyAll' | 'enemySingle' | 'enemyAll' | 'self' | 'any' | 'nothing';

export const Targets: Record<TargetType, ActionTarget> = {
	allySingle: {
		name: 'Ally Single',
		description: 'Target a single ally.',
		category: 'ally',
		quantity: 1,
	},
	allyAll: {
		name: 'Ally All',
		description: 'Target all allies.',
		category: 'ally',
		quantity: 'all',
	},
	enemySingle: {
		name: 'Enemy Single',
		description: 'Target a single enemy.',
		category: 'enemy',
		quantity: 1,
	},
	enemyAll: {
		name: 'Enemy All',
		description: 'Target all enemies.',
		category: 'enemy',
		quantity: 'all',
	},
	self: {
		name: 'Self',
		description: 'Target yourself.',
		category: 'self',
		quantity: 1,
	},
	any: {
		name: 'Any',
		description: 'Target any character.',
		category: 'any',
		quantity: 1,
	},
	nothing: {
		name: 'Nothing',
		description: 'Do not target anything.',
		category: 'nothing',
		quantity: 'none',
	},
} as const;