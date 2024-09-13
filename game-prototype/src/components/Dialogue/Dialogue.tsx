import { createEffect, onMount, createSignal } from 'solid-js';
import { cn } from '@helpers/cn';

import { gameState } from '@stores/GameContext';
import { dialogueStore } from '@stores/Dialogue';
import { Message } from './Message';

import type { Component } from 'solid-js';
import type { DialogueMessage } from '@stores/Dialogue';
import { getGameStateName } from '@helpers/getGameState';

type DialogueProps = {
	message?: DialogueMessage;
	class?: string;
}

export const Dialogue: Component<DialogueProps> = (props) => {
	let messagesContainer: HTMLDivElement | undefined;
	const [title, setTitle] = createSignal('');

	const scrollToBottom = () => {
		if (messagesContainer) {
			messagesContainer.scrollTop = messagesContainer.scrollHeight;
		}
	};

	onMount(scrollToBottom);

	createEffect(() => {
		setTitle(getGameStateName(gameState.currentState));
		console.log('title:', title());
		dialogueStore.messages;
		scrollToBottom();
	});

	return (
		<div class={cn('gap-1', props.class)}>
			<div class='flex flex-col p-1 h-full w-full bg-neutral-700 bg-opacity-25 rounded-md'>
				<h3>Phase: {title()}</h3>
				<div
					ref={messagesContainer}
					class='flex flex-col h-full w-full overflow-y-auto p-1 gap-1 bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50'
				>
					{dialogueStore.messages?.map(message => (
						<Message message={message} />
					))}
				</div>
			</div>
		</div>
	);
};