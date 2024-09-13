import { addDialogueMessage, addDialogueLine } from "@stores/DialogueStore";

export async function BattleSetup() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase de preparação de Batalha.' },
		],
		requiresUserAction: true,
	});

	await new Promise(resolve => setTimeout(resolve, 3000));
}