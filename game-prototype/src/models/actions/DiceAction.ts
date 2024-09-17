import { Targets, type ActionTarget } from '@models/actions/Target';

export type DiceAction = {
	name: string;
	description: string;
	targets: ActionTarget[];
	bgColor: string;
}

type ActionType = 'empty' | 'physicalAttack' | 'magicAttack' | 'defend' | 'special';

export const DiceActions: Record<ActionType, DiceAction> = {
	empty: {
		name: 'Vazio',
		description: 'Do nothing.',
		targets: [Targets.self],
		bgColor: '#d4d4d8',
	},
	physicalAttack: {
		name: 'Ataque Físico',
		description: 'Perform a physical attack.',
		targets: [Targets.enemySingle],
		bgColor: '#fca5a5',
	},
	magicAttack: {
		name: 'Ataque Mágico',
		description: 'Perform a magic attack.',
		targets: [Targets.enemySingle, Targets.enemyAll],
		bgColor: '#93c5fd',
	},
	defend: {
		name: 'Defender',
		description: 'Take a defensive stance to reduce incoming damage.',
		targets: [Targets.self],
		bgColor: '#fde047',
	},
	special: {
		name: 'Especial',
		description: 'Use a special ability.',
		targets: [Targets.any],
		bgColor: '#d8b4fe',
	},
} as const;