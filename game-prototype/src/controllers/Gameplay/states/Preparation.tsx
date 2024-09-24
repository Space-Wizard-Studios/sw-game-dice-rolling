import { addDialogueMessage } from '@stores/DialogueStore';
import { generateRandomCharacter } from '@helpers/generateRandomCharacter';
import { CharacterSelection } from '@components/ItemSelection/CharacterSelection';

import { enemyCharacterStore, playerCharacterStore } from '@stores/CharacterStore';
import { diceStore } from '@stores/DiceStore';

import { DiceSelection } from '@components/ItemSelection/DiceSelection';
import { generateRandomDice } from '@helpers/generateRandomDice';
import { transferDice } from '@helpers/diceTransferHandler';

export async function Preparation() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação.' },
			{ text: 'Vamos começar selecionando seu personagem.' },
		],
		requiresUserAction: true,
	});

	// Generate some random characters and prompt player to select one
	const randomPlayerCharacters = generateRandomCharacter(3, 'Player');
	const selectedCharacter = await CharacterSelection(randomPlayerCharacters);
	playerCharacterStore.addCharacter(selectedCharacter);

	await addDialogueMessage({
		lines: [
			{ text: 'Ótima escolha!' },
			{ text: 'Agora vamos selecionar seus dados.' },
		],
		requiresUserAction: true,
	});

	const randomPlayerCharacters2 = generateRandomCharacter(3, 'Player');
	const selectedCharacter2 = await CharacterSelection(randomPlayerCharacters2);
	playerCharacterStore.addCharacter(selectedCharacter2);

	await addDialogueMessage({
		lines: [
			{ text: 'Ótima escolha!' },
			{ text: 'Agora vamos selecionar seus dados.' },
		],
		requiresUserAction: true,
	});


	// Generate a random dice and prompt the player to select
	const randomPlayerDice = generateRandomDice(5, [4, 6, 8]);
	const selectedDice = await DiceSelection(randomPlayerDice);
	diceStore.addDice(selectedDice);
	transferDice(selectedDice.id, null, 'inventory');

	const randomPlayerDice2 = generateRandomDice(5, [4, 6, 8]);
	const selectedDice2 = await DiceSelection(randomPlayerDice2);
	diceStore.addDice(selectedDice2);
	transferDice(selectedDice2.id, null, 'inventory');

	await addDialogueMessage({
		lines: [
			{ text: 'Ótima escolha!' },
			{ text: 'Agora vamos gerar alguns inimigos...' },
		],
		requiresUserAction: true,
	});

	// Generate random characters for the enemy
	const enemyCharacters = generateRandomCharacter(5, 'Enemy');
	enemyCharacterStore.addMultipleCharacters(enemyCharacters);

	return null;
}