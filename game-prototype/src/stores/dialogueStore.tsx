import { createSignal } from 'solid-js';

const [dialogueLines, setDialogueLines] = createSignal([""]);

const addDialogueLine = (line: string) => {
  setDialogueLines((prevLines) => {
    const newLines = [...prevLines, line];
    return newLines.length > 200 ? newLines.slice(-200) : newLines;
  });
};

// TODO remover este loop de testes
for (let i = 1; i <= 300; i++) {
  addDialogueLine(`This is dialogue line number ${i}`);
}

export { dialogueLines, addDialogueLine };