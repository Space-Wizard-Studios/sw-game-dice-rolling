import { playerCharacterStore } from '@stores/CharacterStore';
import { diceStore } from '@stores/DiceStore';

import type { DiceAction } from '@models/actions/DiceAction';
import type { Dice } from '@models/Dice';
import { addChatLine, addChatMessage } from '@stores/ChatStore';

export function rollDice(dice: Dice): { rolledSide: number, action: DiceAction } {
	const sides = dice.sides;
	const rolledSide = Math.floor(Math.random() * sides) + 1;
	return { rolledSide, action: dice.actions[rolledSide - 1] };
}

export function rollAllPlayerDice(): Record<string, DiceAction[]> {
	const results: Record<string, DiceAction[]> = {};

	const playerCharacters = playerCharacterStore.store.characters;

	playerCharacters.forEach(character => {
		const diceResults: DiceAction[] = [];
		const diceIds = character.diceIds ?? [];

		if(diceIds.length === 0) {
			return;
		}

		addChatMessage({
			lines: [
				{ text: `${character.name} rolou os dados.` },
			],
		});

		diceIds.forEach(diceId => {
			const dice = diceStore.getDiceByID(diceId);
			if (dice) {
				const { rolledSide, action } = rollDice(dice);
				diceResults.push(action);

				addChatLine({
					text: `${dice.name} (${dice.sides} lados): rolou ${rolledSide}, ação ${action.name}`,
				});

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