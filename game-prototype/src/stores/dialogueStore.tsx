import { createSignal } from 'solid-js';

const MAX_DIALOGUE_LINES = 200;

const [dialogueLines, setDialogueLines] = createSignal([""]);

const addDialogueLine = (line: string) => {
  setDialogueLines((prevLines) => {
    const newLines = [...prevLines, line];
    return newLines.length > MAX_DIALOGUE_LINES ? newLines.slice(-MAX_DIALOGUE_LINES) : newLines;
  });
};

// TODO remover este loop de testes
for (let i = 1; i <= 300; i++) {
  addDialogueLine(`This is dialogue line number ${i}`);
}

export { dialogueLines, addDialogueLine };