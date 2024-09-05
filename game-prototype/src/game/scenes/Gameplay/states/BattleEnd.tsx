import { addDialogueMessage, addDialogueLine } from "@stores/DialogueStore";

export async function BattleEnd() {
    addDialogueMessage({
        lines: [
            { text: 'Esta é a fase do fim da Batalha.' },
        ]
    });

    await new Promise(resolve => setTimeout(resolve, 3000));
}