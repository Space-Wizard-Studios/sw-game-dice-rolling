import { addDialogueMessage } from "@stores/DialogueStore";

type BattleResult = 'victory' | 'defeat';

export async function BattleEnd(result: BattleResult) {
	await addDialogueMessage({
		lines: [
			{
				text: 'Esta é a fase do fim da Batalha. Vamos fingir que você perdeu porque ainda não fiz essa parte.',
				type: 'wip',
			},
		],
		requiresUserAction: true,
	});
}