import { createStore } from 'solid-js/store';
import { waitUserAction, useGameManager, resumeOnAction, type UserActionType } from '@stores/GameContext';
import type { SceneStateType } from '@models/states/States';

type LineType = 'info' | 'failure' | 'success' | 'warning' | 'wip';

export type DialogueLine = {
	text: string;
	align?: 'left' | 'center' | 'right';
	type?: LineType;
};

export type DialogueMessage = {
	lines: DialogueLine[];
	gameState?: SceneStateType;
	requiresUserAction?: {
		type: UserActionType;
	};
};

export const [dialogueStore, setDialogueStore] = createStore<{ messages: DialogueMessage[] }>({
	messages: [],
});

export function addDialogueMessage(message: DialogueMessage): Promise<void> {
	const [gameState] = useGameManager();
	const currentState = gameState.currentSceneState.state;
	const messageState = { ...message, gameState: currentState };
	setDialogueStore('messages', messages => [...messages, messageState]);

	if (message.requiresUserAction) {
		return waitUserAction(message.requiresUserAction.type);
	} else {
		return Promise.resolve();
	}
}

export function addDialogueLine(line: DialogueLine): void {
	const lastMessage = dialogueStore.messages[dialogueStore.messages.length - 1];
	const newMessage = { ...lastMessage, lines: [...lastMessage.lines, line] };
	setDialogueStore('messages', messages => [...messages.slice(0, -1), newMessage]);
}