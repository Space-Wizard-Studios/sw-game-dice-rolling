import { createEffect, onMount, createSignal } from 'solid-js';
import type { Component } from 'solid-js';

import { useGameManager } from '@stores/GameContext';
import { chatStore } from '@stores/ChatStore';

import type { ChatMessage } from '@stores/ChatStore';
import { Message } from '@components/Chat/Message';

import { cn } from '@helpers/cn';
import { getGameStateName } from '@helpers/getGameState';
import { getGameSceneName } from '@helpers/getGameScene';

type ChatProps = {
	message?: ChatMessage;
	class?: string;
}

export const Chat: Component<ChatProps> = (props) => {
	const [gameState] = useGameManager();
	let messagesContainer: HTMLDivElement | undefined;

	const scrollToBottom = () => {
		if (messagesContainer) {
			messagesContainer.scrollTop = messagesContainer.scrollHeight;
		}
	};

	onMount(scrollToBottom);

	createEffect(() => {
		chatStore.messages;
		scrollToBottom();
	});

	const [title, setTitle] = createSignal('');

	createEffect(() => {
		const sceneName = getGameSceneName(gameState.currentSceneState.scene);
		const stateName = getGameStateName(gameState.currentSceneState.state);
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
					{chatStore.messages?.map(message => (
						<Message {...message} />
					))}
				</div>
			</div>
		</div>
	);
};