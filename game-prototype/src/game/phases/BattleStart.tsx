import { addDialogueLine } from "@stores/DialogueStore";

export async function BattleStart() {
    addDialogueLine("BattleStart.");
    await new Promise(resolve => setTimeout(resolve, 3000));
}