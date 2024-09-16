import type { Dice } from './Dice';
import type { Role } from '@models/Role';

import type { CommonAction } from './actions/CommonAction';

export type Health = {
	max: number;
	current?: number;
}

export type Speed = {
	max: number;
	current?: number;
}

export type Character = {
	id: string;
	name: string;
	role: Role;
	health?: Health;
	speed?: Speed;
	commonActions?: CommonAction[];
	diceIDs?: string[];
}