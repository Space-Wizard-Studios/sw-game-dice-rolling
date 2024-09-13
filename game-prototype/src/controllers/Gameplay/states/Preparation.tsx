import { addDialogueLine, addDialogueMessage } from '@stores/Dialogue';
import { generateRandomCharacters } from '@helpers/generateRandomCharacters';
import { CharacterSelection } from '@components/ItemSelection/CharacterSelection';
import { enemyCharacterStore, playerCharacterStore } from '@stores/Character';

import { DiceSelection } from '@components/ItemSelection/DiceSelection';
import { generateRandomDiceSet } from '@helpers/generateRandomDiceSet';

export async function Preparation() {
	addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação.' },
		]
	});

	// Generate random characters and prompt player to select one
	const playerCharacters = generateRandomCharacters(3, 'Player');
	const playerSelectedCharacter = await CharacterSelection(playerCharacters);
	playerCharacterStore.addCharacter(playerSelectedCharacter);

	const allSelectedDiceSets = [];
	// Loop to generate random dice and prompt the player to select 3 times
	for (let i = 0; i < 2; i++) {
		const dice = generateRandomDiceSet(5, [4, 6, 8]);
		const selectedDice = await DiceSelection(3, dice);
		allSelectedDiceSets.push(selectedDice);
	}

	// Update the player's character with all selected dice sets
	playerCharacterStore.updateCharacter(playerSelectedCharacter.id, { diceSet: allSelectedDiceSets });


	// Generate random characters for the enemy
	const enemyCharacters = generateRandomCharacters(5, 'Enemy');
	enemyCharacterStore.addCharacters(enemyCharacters);

	return null;
}