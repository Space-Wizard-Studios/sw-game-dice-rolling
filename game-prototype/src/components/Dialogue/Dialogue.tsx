import { createEffect, onMount } from 'solid-js';
import { cn } from '@helpers/cn';

import { gameState } from '@stores/GameContext';
import { dialogueStore } from '@stores/Dialogue';
import { Message } from './Message';

import type { Component } from 'solid-js';
import type { DialogueMessage } from '@stores/Dialogue';

type DialogueProps = {
    message?: DialogueMessage;
    class?: string;
}

export const Dialogue: Component<DialogueProps> = (props) => {
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
        <div class={cn('gap-2', props.class)}>
            <div class='flex p-2 h-full w-full bg-neutral-700 bg-opacity-25 rounded-md'>
                {/* <h3>Phase: {gameState.currentState.name}</h3> */}
                <div
                    ref={messagesContainer}
                    class='flex flex-col h-full w-full overflow-y-auto p-2 gap-2 bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50'
                >
                    {dialogueStore.messages?.map(message => (
                        <Message message={message} />
                    ))}
                </div>
            </div>
        </div>
    );
};

