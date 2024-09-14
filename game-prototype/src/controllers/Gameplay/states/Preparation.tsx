import { addDialogueMessage } from '@stores/DialogueStore';
import { generateRandomCharacter } from '@helpers/generateRandomCharacter';
import { CharacterSelection } from '@components/ItemSelection/CharacterSelection';
import { enemyCharacterStore, playerCharacterStore } from '@stores/CharacterStore';

import { DiceSelection } from '@components/ItemSelection/DiceSelection';
import { generateRandomDice } from '@helpers/generateRandomDiceSet';

export async function Preparation() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação.' },
			{ text: 'Vamos começar selecionando seu personagem.' },
		],
		requiresUserAction: true,
	});

	// Generate random characters and prompt player to select one
	const playerCharacters = generateRandomCharacter(3, 'Player');
	const playerSelectedCharacter = await CharacterSelection(playerCharacters);
	playerCharacterStore.addCharacter(playerSelectedCharacter);

	await addDialogueMessage({
		lines: [
			{ text: 'Ótima escolha!' },
			{ text: 'Agora vamos selecionar seus dados.' },
		],
		requiresUserAction: true,
	});

	const allSelectedDiceSets = [];
	// Loop to generate random dice and prompt the player to select 3 times
	for (let i = 0; i < 2; i++) {
		const diceOptions = generateRandomDice(5, [4, 6, 8]);
		const selectedDice = await DiceSelection(3, diceOptions);
		allSelectedDiceSets.push(selectedDice);
	}
	
	// Update the player's character with all selected dice sets
	playerCharacterStore.updateCharacter(playerSelectedCharacter.id, { diceSet: allSelectedDiceSets });

	await addDialogueMessage({
		lines: [
			{ text: 'Ótima escolha!' },
			{ text: 'Agora vamos gerar alguns inimigos...' },
		],
		requiresUserAction: true,
	});

	// Generate random characters for the enemy
	const enemyCharacters = generateRandomCharacter(5, 'Enemy');
	enemyCharacterStore.addCharacters(enemyCharacters);

	return null;
}