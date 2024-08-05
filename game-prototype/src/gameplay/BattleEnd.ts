import { AddDialogue } from "@helpers/Dialogue";

export async function BattleEnd() {
    AddDialogue("End of battle.");
    AddDialogue("Calculating experience and leveling up characters...");
}
