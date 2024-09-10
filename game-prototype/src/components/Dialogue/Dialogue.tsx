import { createEffect, onMount } from 'solid-js';
import { gameState } from '@stores/GameContext';
import { dialogueStore } from '@stores/Dialogue';

import { Message } from './Message';

import type { Component } from 'solid-js';
import type { DialogueMessage } from '@stores/Dialogue';

export const Dialogue: Component<{ message?: DialogueMessage }> = () => {
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

    return (
        <div class='flex flex-col flex-1 h-2/3 md:h-full p-2 gap-2 rounded-md bg-gray-500 bg-opacity-50'>
            <div class='flex flex-row justify-between'>
                {/* <h3>Phase: {gameState.currentState.name}</h3> */}
            </div>
            <div
                ref={messagesContainer}
                class='flex flex-col p-2 gap-2 h-full overflow-y-auto bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50'
            >
                {dialogueStore.messages?.map(message => (
                    <Message message={message} />
                ))}
            </div>
        </div>
    );
};

