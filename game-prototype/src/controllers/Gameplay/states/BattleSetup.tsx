import { addDialogueMessage } from "@stores/DialogueStore";
import { enemyCharacterStore } from '@stores/CharacterStore';
import { generateRandomCharacter } from '@helpers/generateRandomCharacter';

export async function BattleSetup() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação da batalha.' },
		],
		requiresUserAction: {type: 'continue'},
	});

	
	await addDialogueMessage({
		lines: [
			{ text: 'Agora vamos gerar alguns inimigos...' },
		],
		requiresUserAction: {type: 'continue'},
	});

	// Generate random characters for the enemy
    const enemyCharacters = generateRandomCharacter(3, 'Enemy', true);
    enemyCharacterStore.addMultipleCharacters(enemyCharacters);
}