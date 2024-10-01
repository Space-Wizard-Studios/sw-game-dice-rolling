import type { Health, Speed } from "@models/Character";
import { type DiceAction, DiceActions } from "@models/actions/DiceAction";
import { ComboActions, type ComboAction } from "@models/actions/ComboAction";

export type Role = {
	name: string;
	image: string;
	description: string;
	baseHealth: Health;
	baseSpeed: Speed;
	baseDiceCapacity: number;
	allowedActions: DiceAction[];
	allowedCombos?: ComboAction[];
};

export type RoleType = 'Fighter' | 'Healer' | 'Mage' | 'Rogue';

export const PlayableRoles: Record<RoleType, Role> = {
	Fighter: {
		name: "Fighter",
		image: "https://api.dicebear.com/9.x/initials/svg?seed=Fighter",
		description: "A strong and brave warrior skilled in combat.",
		baseHealth: {
			max: 100,
		},
		baseSpeed: {
			max: 10,
		},
		baseDiceCapacity: 4,
		allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
		allowedCombos: [ComboActions.chargedAttack, ComboActions.parry],
	},
	Mage: {
		name: "Mage",
		image: "https://api.dicebear.com/9.x/initials/svg?seed=Mage",
		description: "A master of magical arts.",
		baseHealth: {
			max: 70,
		},
		baseSpeed: {
			max: 10,
		},
		baseDiceCapacity: 3,
		allowedActions: [DiceActions.magicAttack, DiceActions.defend],
		allowedCombos: [ComboActions.magicBurst],
	},
	Rogue: {
		name: "Rogue",
		description: "A cunning and agile character skilled in stealth.",
		image: "https://api.dicebear.com/9.x/initials/svg?seed=Rogue",
		baseHealth: {
			max: 75,
		},
		baseSpeed: {
			max: 10,
		},
		baseDiceCapacity: 2,
		allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
		allowedCombos: [],
	},
	Healer: {
		name: "Healer",
		description: "A cunning and agile character skilled in stealth.",
		image: "https://api.dicebear.com/9.x/initials/svg?seed=Healer",
		baseHealth: {
			max: 75,
		},
		baseSpeed: {
			max: 10,
		},
		baseDiceCapacity: 1,
		allowedActions: [DiceActions.physicalAttack, DiceActions.defend],
		allowedCombos: [],
	}
};

export const EnemyRoles = {
	GiantRat: {
		name: "Giant Rat",
		image: "https://api.dicebear.com/9.x/initials/svg?seed=GiantRat",
		description: "A large and aggressive rat that bites.",
		baseHealth: {
			max: 50,
		},
		baseSpeed: {
			max: 8,
		},
		baseDiceCapacity: 0,
		allowedActions: [DiceActions.physicalAttack],
		allowedCombos: [],
	},
};