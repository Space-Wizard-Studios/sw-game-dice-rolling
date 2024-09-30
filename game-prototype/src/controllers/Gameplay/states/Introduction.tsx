import { addDialogueMessage } from "@stores/DialogueStore";

export async function GameplayIntroduction() {
	await addDialogueMessage({
		lines: [
			{ text: 'Olá, boas vindas ao jogo!' },
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

	await addDialogueMessage({
		lines: [
			{
				text: 'Este é um protótipo para um jogo de RPG por turnos onde você irá '
					+ 'gerenciar sua equipe de personagens e resolver em batalhas.'
			},
			{ text: 'Neste jogo, os dados são apenas mais um recurso que você irá utilizar e melhorar.' },
		],
		requiresUserAction: true,
	});
	
	await addDialogueMessage({
		lines: [
			{ text: 'Tente sobreviver e boa sorte!' }
		],
		requiresUserAction: true,
	});
}