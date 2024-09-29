import { Targets, type ActionTarget } from '@models/actions/Target';

export type ActionColor = {
	background: string;
	text: string;
};


export type DiceAction = {
	name: string;
	abbreviation: string;
	description: string;
	targets: ActionTarget[];
	colors: ActionColor;
}

type ActionType = 'empty' | 'physicalAttack' | 'magicAttack' | 'defend' | 'special';

export const DiceActions: Record<ActionType, DiceAction> = {
	empty: {
		name: 'Falha',
		abbreviation: 'FAIL',
		description: 'Do nothing.',
		targets: [Targets.nothing],
		colors: {
			background: '#d4d4d8',
			text: '#404040',
		}
	},
	physicalAttack: {
		name: 'Ataque Físico',
		abbreviation: 'PATK',
		description: 'Perform a physical attack.',
		targets: [Targets.enemySingle],
		colors: {
			background: '#fca5a5',
			text: '#7f1d1d',
		}
	},
	magicAttack: {
		name: 'Ataque Mágico',
		abbreviation: 'MATK',
		description: 'Perform a magic attack.',
		targets: [Targets.enemySingle, Targets.enemyAll],
		colors: {
			background: '#93c5fd',
			text: '#1e3a8a',
		}
	},
	defend: {
		name: 'Defender',
		abbreviation: 'DEF',
		description: 'Take a defensive stance to reduce incoming damage.',
		targets: [Targets.self],
		colors: {
			background: '#fde047',
			text: '#78350f',
		}
	},
	special: {
		name: 'Especial',
		abbreviation: 'SPEC',
		description: 'Use a special ability.',
		targets: [Targets.any],
		colors: {
			background: '#d8b4fe',
			text: '#581c87',
		}
	},
} as const;

type EnemyActionType = 'bite' | 'claw';

export const EnemyDiceActions: Record<EnemyActionType, DiceAction> = {
	bite: {
		name: 'Morder',
		abbreviation: 'BITE',
		description: 'Bite the target.',
		targets: [Targets.enemySingle],
		colors: {
			background: '#fca5a5',
			text: '#7f1d1d',
		},
	},
	claw: {
		name: 'Arranhar',
		abbreviation: 'CLAW',
		description: 'Claw the target.',
		targets: [Targets.enemyAll],
		colors: {
			background: '#fca5a5',
			text: '#7f1d1d',
		}
	},
} as const;