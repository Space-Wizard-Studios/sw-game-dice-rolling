import { createStore } from 'solid-js/store';
import { useGameManager } from '@stores/GameContext';
import type { GameStateType } from '@models/states/States';

type LineType = 'info' | 'failure' | 'success';

export type DialogueLine = {
    text: string;
    type?: LineType;
};

export type DialogueMessage = {
    lines: DialogueLine[];
    gameState?: GameStateType;
    state?: { currentState: string };
};

export const [dialogueStore, setDialogueStore] = createStore<{ messages: DialogueMessage[] }>({
    messages: [],
});

export function addDialogueMessage(newMessage: DialogueMessage) {
    const [gameState] = useGameManager();
    const currentState = gameState.currentState;
    const messageState = { ...newMessage, gameState: currentState };
    setDialogueStore('messages', messages => [...messages, messageState]);
}

export function addDialogueLine(line: string, type?: LineType) {
    const [gameState] = useGameManager();
    const currentState = gameState.currentState;

    setDialogueStore('messages', messages => {
        if (messages.length === 0) {
            return [...messages, { lines: [{ text: line, type }], gameState: currentState }];
        } else {
            const lastMessage = messages[messages.length - 1];
            return [
                ...messages.slice(0, -1),
                { ...lastMessage, lines: [...lastMessage.lines, { text: line, type }] },
            ];
        }
    });
}