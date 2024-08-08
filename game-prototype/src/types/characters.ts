import { D4, D6, D8, D10, D12, D20, D100 } from './dice';
import { Role } from './roles';

import { CommonAction } from './actions/common';

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
    dice?: (D4 | D6 | D8 | D10 | D12 | D20 | D100);
}