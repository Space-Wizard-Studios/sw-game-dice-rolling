import { addDialogueLine } from "@stores/DialogueStore";

export async function BattleEnd() {
    await new Promise(resolve => setTimeout(resolve, 3000));
}