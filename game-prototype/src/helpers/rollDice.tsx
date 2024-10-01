import { playerCharacterStore } from '@stores/CharacterStore';
import { diceStore } from '@stores/DiceStore';

import type { DiceAction } from '@models/actions/DiceAction';
import type { Dice } from '@models/Dice';

export function rollDice(dice: Dice): DiceAction {
	const sides = dice.sides;
	const rolledSide = Math.floor(Math.random() * sides);
	return dice.actions[rolledSide];
}

export function rollAllPlayerDice(): Record<string, DiceAction[]> {
	const results: Record<string, DiceAction[]> = {};

	const playerCharacters = playerCharacterStore.store.characters;

	playerCharacters.forEach(character => {
		const diceResults: DiceAction[] = [];
		const diceIds = character.diceIds ?? [];

		diceIds.forEach(diceId => {
			const dice = diceStore.getDiceByID(diceId);
			if (dice) {
				const result = rollDice(dice);
				diceResults.push(result);
			} else {
				console.warn(`Dice with ID ${diceId} not found`);
			}
		});

		results[character.id] = diceResults;

		console.log(`Character Name: ${character.name}`);
		console.log('Dice Results:', diceResults);
	});

	return results;
}