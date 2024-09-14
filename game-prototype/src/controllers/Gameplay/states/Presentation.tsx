import { addDialogueLine, addDialogueMessage } from "@stores/DialogueStore";

export async function Presentation() {
	await addDialogueMessage({
		lines: [
			{
				text: 'Boas vindas ao maravilhoso jogo do Danilo :)',
			},
			{
				text: 'Clique em continuar para prosseguir.',
				align: 'right',
			}
		],
		requiresUserAction: true,
	});

	await addDialogueMessage({
		lines: [
			{
				text: "Vamos testar algumas mensagens.",
			},
			{
				text: 'Mensagem de falha.',
				type: 'failure',
			},
			{
				text: 'Mensagem de informação.',
				type: 'info',
			},
			{
				text: 'Mensagem de sucesso.',
				type: 'success',
			},
			{
				text: 'Mensagem de aviso.',
				type: 'warning',
			},
		],
		requiresUserAction: true,
	});
}