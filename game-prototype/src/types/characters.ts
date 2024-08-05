import { D4, D6, D8, D10, D12, D20, D100 } from './dice';
import { Role } from './roles';

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
    die: (D4 | D6 | D8 | D10 | D12 | D20 | D100) | null;
}