import { addDialogueMessage, addDialogueLine } from "@stores/Dialogue";

export async function BattleSetup() {
	addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação de Batalha.' },
		]
	});

	await new Promise(resolve => setTimeout(resolve, 3000));
}