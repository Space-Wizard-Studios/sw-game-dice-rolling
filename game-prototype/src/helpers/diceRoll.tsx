import type { DiceAction } from '@models/actions/DiceAction';
import type { Dice } from '@models/Dice';

/**
 * Rolls a dice and returns the corresponding action.
 *
 * @param {Dice} dice - The dice object to roll.
 * @returns {DiceAction} The action corresponding to the rolled side.
 */
export function rollDice(dice: Dice): DiceAction {
	const sides = dice.sides;
	const rolledSide = Math.floor(Math.random() * sides);
	return dice.actions[rolledSide];
}