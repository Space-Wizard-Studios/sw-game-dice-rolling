import { addChatMessage } from "@stores/ChatStore";

export async function BattleTurn() {
	await addChatMessage({
		lines: [
			{
				text: `Este é um turno da batalha, mas não existe batalha ainda.`,
				type: 'wip',
			},
			{
				text: 'O que você pode fazer é equipar os dados e ficar rolando aí, sidivirta. 🤙',
				type: 'wip',
			}
		],
		requiresUserAction: {type: 'rollDice'},
	});
}