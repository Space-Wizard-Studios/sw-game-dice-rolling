import { createEffect, onMount } from 'solid-js';
import { gameState } from '@game/GameContext';
import { dialogueStore } from '@stores/DialogueStore';

import type { Component } from 'solid-js';
import type { DialogueMessage } from '@stores/DialogueStore';

type DialogueProps = {
  message?: DialogueMessage;
};

type MessageProps = {
  message: DialogueMessage;
};

export const Dialogue: Component<DialogueProps> = () => {
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
        <h3>Phase: {gameState.currentPhase.name}</h3>
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

export const Message: Component<MessageProps> = (props) => {
  let bg = '';
  switch (props.message.type) {
    case 'info':
      bg = 'bg-blue-500';
      break;
    case 'failure':
      bg = 'bg-red-500';
      break;
    case 'success':
      bg = 'bg-green-500';
      break;
    default:
      bg = 'bg-gray-500';
      break;
  }

  return (
    <div class={`p-2 rounded-md ${bg} bg-opacity-50`}>
      <div>
        <h3>{props.message.type}</h3>
      </div>
      <div>
        {props.message.lines.map(line => (
          <p>{line.text}</p>
        ))}
      </div>
    </div>
  );
};