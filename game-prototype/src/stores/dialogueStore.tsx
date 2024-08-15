import { createStore } from 'solid-js/store';

// TODO: fix this mess, it's not working

type DialogueLine = {
  line: string;
};

type DialogueMessage = {
  message: DialogueLine[];
};

export const [dialogueStore, setDialogueStore] = createStore<DialogueMessage>({
  message: [],
});

export function addDialogueLine(line: string) {
  setDialogueStore('message', messages => [...messages, { line }]);
}

// for (let i = 1; i <= 300; i++) {
//   addDialogueLine(`This is dialogue line number ${i}`);
// }
