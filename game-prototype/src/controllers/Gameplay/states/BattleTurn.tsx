import { addChatMessage } from "@stores/ChatStore";

export async function BattleTurn() {
	await addChatMessage({
		lines: [
			{
				text: `Este é um turno da batalha, mas não existe batalha ainda 🤙`,
				type: 'wip',
			},
		],
		requiresUserAction: {type: 'continue'},
	});
}