import type { ComboAction } from '@models/actions/ComboAction';
import type { Action } from '@models/actions/DiceAction';
import type { Health } from '@models/Characters';
import { Roles } from '@models/Roles';
import type { Role } from '@models/Roles';

export function getRoleName(role: Role): string {
    return role.name;
}

export function getRoleImage(role: Role): string {
    return role.image;
}

export function getRoleDescription(role: Role): string {
    return role.description;
}

export function getRoleBaseHealth(role: Role): Health {
    return role.baseHealth;
}

export function getRoleAllowedActions(role: Role): Action[] {
    return role.allowedActions;
}

export function getRoleAllowedCombos(role: Role): ComboAction[] {
    return role.allowedCombos ?? [];
}

export function getRole(roleType: string): Role {
    return Roles[roleType as keyof typeof Roles];
}