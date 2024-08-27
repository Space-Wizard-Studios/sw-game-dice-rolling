import { addDialogueLine, addDialogueMessage } from "@stores/DialogueStore";

export async function Presentation() {
    addDialogueMessage({
        lines: [
            {
                text: 'Welcome to the game!',
            },
        ],
    });

    addDialogueMessage({
        lines: [
            {
                text: "Let's test some messages",
            },
            {
                text: 'Failure message',
                type: 'failure',
            },
            {
                text: 'Info message',
                type: 'info',
            },
            {
                text: 'Success message',
                type: 'success',
            },
        ],
    });

    await new Promise(resolve => setTimeout(resolve, 3000));
}