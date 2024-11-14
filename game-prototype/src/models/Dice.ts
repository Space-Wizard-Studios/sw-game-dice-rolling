import type { DiceAction } from '@models/DiceAction';

/**
 * Represents a single side of a dice, which is an action.
 */
export type DiceSide = DiceAction;

/**
 * Recursive type to represent a dice with a specific number of sides.
 * Each side is an action.
 * 
 * @template Sides - The number of sides on the dice.
 * @template T - The type of each side (default is DiceSide).
 * @template R - The accumulated sides (default is an empty array).
 */
export type DiceType<
	Sides extends number,
	T = DiceSide,
	R extends T[] = []
> = R['length'] extends Sides ? R : DiceType<Sides, T, [T, ...R]>;

/**
 * Specific dice types with a fixed number of sides.
 */
export type D4Actions = DiceType<4>;
export type D6Actions = DiceType<6>;
export type D8Actions = DiceType<8>;
export type D10Actions = DiceType<10>;
export type D12Actions = DiceType<12>;
export type D20Actions = DiceType<20>;
export type D100Actions = DiceType<100>;

/**
 * Maps the number of actions to the corresponding dice type.
 */
export type DiceActionsMap = {
	4: D4Actions;
	6: D6Actions;
	8: D8Actions;
	10: D10Actions;
	12: D12Actions;
	20: D20Actions;
	100: D100Actions;
};

/**
 * Extracts the number of sides from a given dice type.
 * 
 * @template T - The dice type.
 */
export type ExtractSides<T> = T extends DiceType<infer Sides> ? Sides : never;

/**
 * Represents the location of a dice.
 */
export type DiceLocation = 'inventory' | string | null;

/**
 * Represents a dice with a specific number of sides and associated actions.
 * 
 * @template T - The key of DiceSidesMap (default is any key of DiceSidesMap).
 */
export type Dice<T extends keyof DiceActionsMap = keyof DiceActionsMap> = {
	id: string;
	name: string;
	actions: DiceActionsMap[T]; // The actions associated with each side of the dice.
	sides: ExtractSides<DiceActionsMap[T]>; // The number of sides on the dice.
	location: DiceLocation;
};