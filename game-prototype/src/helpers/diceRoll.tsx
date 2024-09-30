import type { Dice } from '@models/Dice';

/**
 * Rolls a dice and returns the result.
 *
 * @param {Dice} dice - The dice object to roll.
 * @returns {number} The result of the dice roll.
 */
export function rollDice(dice: Dice): number {
    const sides = dice.sides;
    return Math.floor(Math.random() * sides) + 1;
}