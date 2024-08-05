import { AddDialogue } from '@helpers/Dialogue';
import { AddOptions } from '@helpers/Input';

export async function BuildSetup() {
    AddDialogue("Build phase where player can choose characters.");

    // Example options and actions
    const options = ["Character 1", "Character 2", "Character 3"];
    const actions = [
        { label: "Submit", callback: () => { console.log('Submit action called'); } },
        { label: "Cancel", callback: () => { console.log('Cancel action called'); } }
    ];

    const actionLabel = await AddOptions(options, actions);
    console.log(`Action fired: ${actionLabel}`);
}