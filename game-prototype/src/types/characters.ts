import { DiceType } from './dice';
import { Role } from 'types/roles';

import { CommonAction } from './actions/commonAction';

export type Health = {
    max: number;
    current?: number;
}

export type Speed = {
    max: number;
    current?: number;
}

export type Character = {
    name: string;
    role: Role;
    health: Health;
    speed: Speed;
    commonActions?: CommonAction[];
    diceSet?: DiceType[];
}