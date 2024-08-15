import { addDialogueLine } from "@stores/DialogueStore";

export async function Presentation() {
    addDialogueLine("Presentation.");
    await new Promise(resolve => setTimeout(resolve, 3000));
}