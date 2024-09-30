import { addDialogueMessage } from "@stores/DialogueStore";

export async function BattleTurn() {
	await addDialogueMessage({
		lines: [
			{
				text: `Este é um turno da batalha. Vamos rolar os dados dos personagens que estão em campo.`,
				type: 'info',
			},
		],
		requiresUserAction: true,
	});
}