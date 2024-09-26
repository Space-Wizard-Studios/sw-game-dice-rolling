import { addDialogueMessage } from "@stores/DialogueStore";

export async function BattleStart() {
	await addDialogueMessage({
		lines: [
			{ text: 'Esta é a fase do início de Batalha.' },
		],
		requiresUserAction: true,
	});
}