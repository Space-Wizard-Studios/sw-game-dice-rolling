import { addDialogueLine, addDialogueMessage } from "@stores/DialogueStore";

export async function Presentation() {
    addDialogueMessage({
        type: 'info',
        lines: [
            { text: 'Welcome to the game!' },
            { text: 'blah blah blah' },
        ]
    });

    addDialogueMessage({
        lines: [
            { text: 'blah blah blah' }
        ]
    });

    addDialogueLine('This is a test');

    await new Promise(resolve => setTimeout(resolve, 3000));
}