import { AddDialogue } from "@helpers/AddDialogue";

export async function BattleEnd() {
    AddDialogue("End of battle.");
    AddDialogue("Calculating experience and leveling up characters...");
}
