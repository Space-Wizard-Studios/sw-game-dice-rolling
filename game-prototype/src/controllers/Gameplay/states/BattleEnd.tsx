import { addDialogueMessage, addDialogueLine } from "@stores/DialogueStore";

export async function BattleEnd() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase do fim da Batalha.' },
		],
		requiresUserAction: true,
	});

}