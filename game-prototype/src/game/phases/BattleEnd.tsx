import { addDialogueLine } from "@stores/Dialogue";

export async function BattleEnd() {
    await new Promise(resolve => setTimeout(resolve, 3000));
}