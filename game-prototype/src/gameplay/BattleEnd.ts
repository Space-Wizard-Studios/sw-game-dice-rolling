import { AddDialogue } from "@helpers/dialogueStore";

export async function BattleEnd() {
    AddDialogue("End of battle.");
    AddDialogue("Calculating experience and leveling up characters...");
}
