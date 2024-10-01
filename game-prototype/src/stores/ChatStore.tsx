import { createStore } from 'solid-js/store';
import { waitUserAction, useGameManager, resumeOnAction, type UserActionType } from '@stores/GameContext';
import type { SceneStateType } from '@models/states/States';

type LineType = 'info' | 'failure' | 'success' | 'warning' | 'wip';

export type ChatLine = {
	text: string;
	align?: 'left' | 'center' | 'right';
	type?: LineType;
};

export type ChatMessage = {
	lines: ChatLine[];
	gameState?: SceneStateType;
	requiresUserAction?: {
		type: UserActionType;
	};
};

export const [chatStore, setChatStore] = createStore<{ messages: ChatMessage[] }>({
	messages: [],
});

export function addChatMessage(message: ChatMessage): Promise<void> {
	const [gameState] = useGameManager();
	const currentState = gameState.currentSceneState.state;
	const messageState = { ...message, gameState: currentState };
	setChatStore('messages', messages => [...messages, messageState]);

	if (message.requiresUserAction) {
		return waitUserAction(message.requiresUserAction.type);
	} else {
		return Promise.resolve();
	}
}

export function addChatLine(line: ChatLine): void {
	const lastMessage = chatStore.messages[chatStore.messages.length - 1];
	const newMessage = { ...lastMessage, lines: [...lastMessage.lines, line] };
	setChatStore('messages', messages => [...messages.slice(0, -1), newMessage]);
}