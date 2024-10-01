import { addDialogueMessage } from "@stores/DialogueStore";

export async function BattleTurn() {
	await addDialogueMessage({
		lines: [
			{
				text: `Este é um turno da batalha, mas não existe batalha ainda 🤙`,
				type: 'wip',
			},
		],
		requiresUserAction: {type: 'continue'},
	});
}