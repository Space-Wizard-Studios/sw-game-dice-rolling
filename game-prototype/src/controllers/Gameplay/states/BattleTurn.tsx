import { addDialogueMessage } from "@stores/DialogueStore";

export async function BattleTurn() {
	await addDialogueMessage({
		lines: [
			{
				text: 'Este é um turno da batalha. Vamos seguir para o resultado porque ainda não fiz essa parte.',
				type: 'wip',
			},
		],
		requiresUserAction: true,
	});
}