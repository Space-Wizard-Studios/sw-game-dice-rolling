import { DiceActions } from '@models/DiceAction';
import type { DiceAction } from '@models/DiceAction';

type DiceActionType = 'chargedAttack' | 'heal' | 'magicBurst' | 'parry';

export type DiceAction = {
	name: string;
	description: string;
	requiredActions: DiceAction[];
};

export const DiceActions: Record<DiceActionType, DiceAction> = {
	chargedAttack: {
		name: 'Charged Attack',
		description: 'Charge up an attack to deal massive damage.',
		requiredActions: [DiceActions.physicalAttack, DiceActions.physicalAttack],
	},
	heal: {
		name: 'Heal',
		description: 'Restore health to yourself or an ally.',
		requiredActions: [DiceActions.magicAttack, DiceActions.special],
	},
	magicBurst: {
		name: 'Magic Burst',
		description: 'Charge up an magical attack to deal massive damage.',
		requiredActions: [DiceActions.magicAttack, DiceActions.magicAttack],
	},
	parry: {
		name: 'Parry',
		description: 'Block and counter an incoming attack.',
		requiredActions: [DiceActions.defend, DiceActions.physicalAttack],
	}
} as const;