import { createStore } from 'solid-js/store';
import { useGameManager } from '@stores/GameContext';
import type { GameStateType } from '@models/states/States';

type LineType = 'info' | 'failure' | 'success' | 'warning' | 'wip';

export type DialogueLine = {
	text: string;
	align?: 'left' | 'center' | 'right';
	type?: LineType;
};

export type DialogueMessage = {
	lines: DialogueLine[];
	gameState?: GameStateType;
	requiresUserAction?: boolean;
	buttonText?: string;
};

export const [dialogueStore, setDialogueStore] = createStore<{ messages: DialogueMessage[] }>({
	messages: [],
});

/**
 * Adds a new dialogue message to the store.
 * Always returns a promise that resolves when the user action is completed, if required.
 * @param message - The dialogue message to add.
 * @returns A promise that resolves when the user action is completed, if required.
 */
export function addDialogueMessage(message: DialogueMessage): Promise<void> {
	const [gameState, setGameState] = useGameManager();
	const currentState = gameState.currentState;
	const messageState = { ...message, gameState: currentState };
	setDialogueStore('messages', messages => [...messages, messageState]);

	if (message.requiresUserAction) {
		setGameState('paused', true);
		return waitForUserAction();
	} else {
		return Promise.resolve();
	}
}

/**
 * Waits for the user to complete the required action.
 * @returns A promise that resolves when the user action is completed.
 */
function waitForUserAction(): Promise<void> {
	const [gameState] = useGameManager();

	return new Promise<void>((resolve) => {
		const interval = setInterval(() => {
			if (!gameState.paused) {
				clearInterval(interval);
				resolve();
			}
		}, 100);
	});
}

/**
 * Adds a new line to the last dialogue message in the store.
 * @param line - The dialogue line to add.
 */
export function addDialogueLine(line: DialogueLine): void {
	const lastMessage = dialogueStore.messages[dialogueStore.messages.length - 1];
	const newMessage = { ...lastMessage, lines: [...lastMessage.lines, line] };
	setDialogueStore('messages', messages => [...messages.slice(0, -1), newMessage]);
}