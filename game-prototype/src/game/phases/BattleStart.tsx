import { addDialogueLine } from "@stores/DialogueStore";

export async function BattleStart() {
    await new Promise(resolve => setTimeout(resolve, 3000));
}