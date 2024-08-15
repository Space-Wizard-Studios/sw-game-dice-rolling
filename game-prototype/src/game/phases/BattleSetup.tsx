import { addDialogueLine } from "@stores/DialogueStore";

export async function BattleSetup() {
    addDialogueLine("BattleSetup.");
    await new Promise(resolve => setTimeout(resolve, 3000));
}