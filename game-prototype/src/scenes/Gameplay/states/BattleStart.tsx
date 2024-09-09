import { addDialogueMessage, addDialogueLine } from "@stores/Dialogue";

export async function BattleStart() {
    addDialogueMessage({
        lines: [
            { text: 'Esta é a fase do início de Batalha.' },
        ]
    });

    await new Promise(resolve => setTimeout(resolve, 3000));
}