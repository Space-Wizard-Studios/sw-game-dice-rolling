import { addDialogueLine } from "@stores/DialogueStore";

export async function BattleEnd() {
    addDialogueLine("BattleEnd.");
    await new Promise(resolve => setTimeout(resolve, 3000));
}