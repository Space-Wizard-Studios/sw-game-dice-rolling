import { Targets, type ActionTarget } from '@models/actions/Target';

export type ActionColor = {
	background: string;
	text: string;
};


export type DiceAction = {
	name: string;
	description: string;
	targets: ActionTarget[];
	colors: ActionColor;
}

type ActionType = 'empty' | 'physicalAttack' | 'magicAttack' | 'defend' | 'special';

export const DiceActions: Record<ActionType, DiceAction> = {
	empty: {
		name: 'Vazio',
		description: 'Do nothing.',
		targets: [Targets.self],
		colors: {
			background: '#d4d4d8',
			text: '#404040',
		}
	},
	physicalAttack: {
		name: 'Ataque Físico',
		description: 'Perform a physical attack.',
		targets: [Targets.enemySingle],
		colors: {
			background: '#fca5a5',
			text: '#7f1d1d',
		}
	},
	magicAttack: {
		name: 'Ataque Mágico',
		description: 'Perform a magic attack.',
		targets: [Targets.enemySingle, Targets.enemyAll],
		colors: {
			background: '#93c5fd',
			text: '#1e3a8a',
		}
	},
	defend: {
		name: 'Defender',
		description: 'Take a defensive stance to reduce incoming damage.',
		targets: [Targets.self],
		colors: {
			background: '#fde047',
			text: '#78350f',
		}
	},
	special: {
		name: 'Especial',
		description: 'Use a special ability.',
		targets: [Targets.any],
		colors: {
			background: '#d8b4fe',
			text: '#581c87',
		}
	},
} as const;