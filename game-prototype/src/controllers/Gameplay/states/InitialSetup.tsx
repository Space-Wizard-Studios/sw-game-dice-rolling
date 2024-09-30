import { addDialogueMessage } from '@stores/DialogueStore';
import { generateRandomCharacter } from '@helpers/generateRandomCharacter';
import { CharacterSelection } from '@components/ItemSelection/CharacterSelection';

import { playerCharacterStore } from '@stores/CharacterStore';
import { diceStore } from '@stores/DiceStore';

import { DiceSelection } from '@components/ItemSelection/DiceSelection';
import { generateRandomDice } from '@helpers/generateRandomDice';
import { transferDice } from '@helpers/diceTransferHandler';

export async function InitialSetup() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação.' },
			{ text: 'Vamos começar selecionando seus personagens.' },
		],
		requiresUserAction: true,
	});

	// Generate some random characters and prompt player to select one
	const randomPlayerCharacters = generateRandomCharacter(5, 'Player');
	const selectedCharacter = await CharacterSelection(randomPlayerCharacters);
	playerCharacterStore.addCharacter(selectedCharacter);

	const randomPlayerCharacters2 = generateRandomCharacter(5, 'Player');
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
	const randomPlayerDice = generateRandomDice(10, [4, 6, 8, 10, 12, 20, 100]);
	const selectedDice = await DiceSelection(randomPlayerDice);
	diceStore.addDice(selectedDice);
	transferDice(selectedDice.id, null, 'inventory');

	const randomPlayerDice2 = generateRandomDice(5, [4, 6, 8]);
	const selectedDice2 = await DiceSelection(randomPlayerDice2);
	diceStore.addDice(selectedDice2);
	transferDice(selectedDice2.id, null, 'inventory');

	const randomPlayerDice3 = generateRandomDice(3, [4, 6, 8]);
	const selectedDice3 = await DiceSelection(randomPlayerDice3);
	diceStore.addDice(selectedDice3);
	transferDice(selectedDice3.id, null, 'inventory');

	await addDialogueMessage({
		lines: [
			{ text: 'Ótima escolha!' },
			{ text: 'Agora vamos iniciar uma batalha.' },
		],
		requiresUserAction: true,
	});
}