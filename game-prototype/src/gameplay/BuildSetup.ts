import { AddDialogue } from '@helpers/Dialogue';
import { AddOptions } from '@helpers/Input';

export async function BuildSetup() {
    AddDialogue("Build phase where player can choose characters.");

    // Example options and actions
    const options = ["Option 1", "Option 2", "Option 3"];
    const actions = [
        { label: "Submit", callback: () => { console.log('Submit action called'); } },
        { label: "Cancel", callback: () => { console.log('Cancel action called'); } }
    ];

    const selectedOptions = await AddOptions(options, actions, 'radio');
    console.log(`Options selected: ${selectedOptions.join(', ')}`);
}