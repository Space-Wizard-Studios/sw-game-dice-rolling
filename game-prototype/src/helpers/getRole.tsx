import type { ComboAction } from '@models/actions/ComboAction';
import type { DiceAction } from '@models/actions/DiceAction';
import type { Health } from '@models/Character';
import { Roles } from '@models/Role';
import type { Role } from '@models/Role';

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

export function getRoleAllowedActions(role: Role): DiceAction[] {
	return role.allowedActions;
}

export function getRoleAllowedCombos(role: Role): ComboAction[] {
	return role.allowedCombos ?? [];
}

export function getRole(roleType: string): Role {
	return Roles[roleType as keyof typeof Roles];
}