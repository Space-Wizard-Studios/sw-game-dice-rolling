import { addDialogueLine } from "@stores/Dialogue";

export async function BattleStart() {
    await new Promise(resolve => setTimeout(resolve, 3000));
}