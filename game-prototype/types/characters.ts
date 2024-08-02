import { D4, D6, D8, D10, D12, D20, D100 } from './dice';
import { Role } from './roles';

export interface Character {
    name: string;
    role: Role;
    health: number;
    die: (D4 | D6 | D8 | D10 | D12 | D20 | D100) | null;
}