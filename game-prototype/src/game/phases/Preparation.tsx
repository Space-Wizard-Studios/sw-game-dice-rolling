import { addDialogueMessage } from '@stores/Dialogue';

export async function Preparation() {
    // - Dialogue presenting the build phase to the player
    addDialogueMessage({
        lines: [
            { text: 'This is the build phase.' },
        ]
    });

    await new Promise(resolve => setTimeout(resolve, 3000));

    // - Generate characters and present them to the player in the interactive panel
    // - Prompt the player to choose one character
    // - Generate dices and present them to the player in the interactive panel
    // - Prompt the player to choose one dice to be added to the player's inventory
    // - Prompt the player to choose one dice and assign it to the character's diceSet
}