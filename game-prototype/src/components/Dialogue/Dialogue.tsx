import { createEffect, onMount, createSignal } from 'solid-js';
import type { Component } from 'solid-js';

import { useGameManager } from '@stores/GameContext';
import { dialogueStore } from '@stores/DialogueStore';

import type { DialogueMessage } from '@stores/DialogueStore';
import { Message } from '@components/Dialogue/Message';

import { cn } from '@helpers/cn';
import { getGameStateName } from '@helpers/getGameState';
import { getGameSceneName } from '@helpers/getGameScene';

type DialogueProps = {
	message?: DialogueMessage;
	class?: string;
}

export const Dialogue: Component<DialogueProps> = (props) => {
	const [gameState] = useGameManager();
	let messagesContainer: HTMLDivElement | undefined;

	const scrollToBottom = () => {
		if (messagesContainer) {
			messagesContainer.scrollTop = messagesContainer.scrollHeight;
		}
	};

	onMount(scrollToBottom);

	createEffect(() => {
		dialogueStore.messages;
		scrollToBottom();
	});

	const [title, setTitle] = createSignal('');

	createEffect(() => {
		const sceneName = getGameSceneName(gameState.currentScene);
		const stateName = getGameStateName(gameState.currentState);
		setTitle(`${sceneName} - ${stateName}`);
	});


	return (
		<div class={cn('gap-2', props.class)}>
			<div class='flex flex-col p-2 h-full w-full bg-neutral-700 bg-opacity-25 rounded-md'>
				<h3>{`${title()}`}</h3>
				<div
					ref={messagesContainer}
					class='flex flex-col h-full w-full overflow-y-auto p-2 gap-2 bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50'
				>
					{dialogueStore.messages?.map(message => (
						<Message {...message} />
					))}
				</div>
			</div>
		</div>
	);
};