export function AddOptions(
    options: string[],
    actions: { label: string, callback: () => void }[]
): Promise<string> {
    return new Promise((resolve) => {
        const optionsContainer = document.getElementById('input');
        if (!optionsContainer) return;

        // Clear existing options
        optionsContainer.innerHTML = '';

        // Create a new div element for the options
        const newDiv = document.createElement('div');
        newDiv.id = 'options-container';

        // Create a form to group radio buttons
        const form = document.createElement('form');
        form.id = 'options-form';

        // Create radio buttons for each option
        options.forEach((option, index) => {
            const optionLabel = document.createElement('label');
            const optionInput = document.createElement('input');
            optionInput.type = 'radio';
            optionInput.name = 'options';
            optionInput.value = option;
            optionInput.id = `option-${index}`;

            optionLabel.htmlFor = optionInput.id;
            optionLabel.textContent = option;

            form.appendChild(optionInput);
            form.appendChild(optionLabel);
            form.appendChild(document.createElement('br'));
        });

        newDiv.appendChild(form);

        // Create buttons for each action
        actions.forEach(action => {
            const actionButton = document.createElement('button');
            actionButton.textContent = action.label;
            actionButton.onclick = (event) => {
                event.preventDefault();
                const selectedOption = form.querySelector('input[name="options"]:checked') as HTMLInputElement;
                if (selectedOption) {
                    console.log(`Option selected: ${selectedOption.value}`);
                }
                action.callback();
                resolve(action.label);
            };
            newDiv.appendChild(actionButton);
        });

        // Append the new div to the options container
        optionsContainer.appendChild(newDiv);
    });
}