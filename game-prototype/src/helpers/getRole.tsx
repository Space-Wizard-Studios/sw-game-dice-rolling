import type { ComboAction } from '@models/actions/ComboAction';
import type { DiceAction } from '@models/actions/DiceAction';
import type { Health } from '@models/Character';
import { PlayableRoles } from '@models/Role';
import type { Role } from '@models/Role';

/**
 * Retrieves the name of a role.
 *
 * @param {Role} role - The role object.
 * @returns {string} The name of the role.
 */
export function getRoleName(role: Role): string {
	return role.name;
}

/**
 * Retrieves the image of a role.
 *
 * @param {Role} role - The role object.
 * @returns {string} The image of the role.
 */
export function getRoleImage(role: Role): string {
	return role.image;
}

/**
 * Retrieves the description of a role.
 *
 * @param {Role} role - The role object.
 * @returns {string} The description of the role.
 */
export function getRoleDescription(role: Role): string {
	return role.description;
}

/**
 * Retrieves the base health of a role.
 *
 * @param {Role} role - The role object.
 * @returns {Health} The base health of the role.
 */
export function getRoleBaseHealth(role: Role): Health {
	return role.baseHealth;
}

/**
 * Retrieves the allowed actions of a role.
 *
 * @param {Role} role - The role object.
 * @returns {DiceAction[]} An array of allowed dice actions for the role.
 */
export function getRoleAllowedActions(role: Role): DiceAction[] {
	return role.allowedActions;
}

/**
 * Retrieves the allowed combo actions of a role.
 *
 * @param {Role} role - The role object.
 * @returns {ComboAction[]} An array of allowed combo actions for the role.
 */
export function getRoleAllowedCombos(role: Role): ComboAction[] {
	return role.allowedCombos ?? [];
}

/**
 * Retrieves a role object by its type.
 *
 * @param {string} roleType - The type of the role.
 * @returns {Role} The role object.
 */
export function getRole(roleType: string): Role {
	return PlayableRoles[roleType as keyof typeof PlayableRoles];
}