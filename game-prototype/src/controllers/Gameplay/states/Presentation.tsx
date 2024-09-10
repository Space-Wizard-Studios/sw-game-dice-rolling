import { addDialogueLine, addDialogueMessage } from "@stores/Dialogue";

export async function Presentation() {
    addDialogueMessage({
        lines: [
            {
                text: 'Boas vindas ao maravilhoso jogo do Danilo :)',
            },
        ],
    });

    addDialogueMessage({
        lines: [
            {
                text: "Vamos testar algumas mensagens.",
            },
            {
                text: 'Mensagem de falha.',
                type: 'failure',
            },
            {
                text: 'Mensagem de informação.',
                type: 'info',
            },
            {
                text: 'Mensagem de sucesso.',
                type: 'success',
            },
        ],
    });

    await new Promise(resolve => setTimeout(resolve, 3000));
}