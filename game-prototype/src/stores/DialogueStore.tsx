import { createStore } from 'solid-js/store';

type DialogueLine = {
  text: string;
};

type MessageType = 'info' | 'failure' | 'success';

export type DialogueMessage = {
  type?: MessageType;
  lines: DialogueLine[];
};

export const [dialogueStore, setDialogueStore] = createStore<{ messages: DialogueMessage[] }>({
  messages: [],
});

export function addDialogueLine(line: string) {
  setDialogueStore('messages', messages => {
    if (messages.length === 0) {
      return [...messages, { lines: [{ text: line }] }];
    } else {
      const lastMessage = messages[messages.length - 1];
      return [
        ...messages.slice(0, -1),
        { ...lastMessage, lines: [...lastMessage.lines, { text: line }] },
      ];
    }
  });
}

export function addDialogueMessage(newMessage: DialogueMessage) {
  setDialogueStore('messages', messages => [...messages, newMessage]);
}

for (let i = 0; i < 300; i++) {
  addDialogueLine(`Test line ${i}`);
}