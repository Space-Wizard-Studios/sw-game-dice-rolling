export function AddInputOptions(
    actions: { label: string, callback: (selectedValues: string[]) => void }[],
    inputType: 'radio' | 'checkbox',
    options?: string[],
    clearAfterAction: boolean = false
): Promise<string[]> {
    return new Promise((resolve, reject) => {
        const inputContainer = document.querySelector('#input .container');
        if (!inputContainer) {
            reject(new Error('Input container not found'));
            return;
        }

        // Clear existing options
        inputContainer.innerHTML = '';

        // Create a form to group input elements
        const form = document.createElement('form');
        form.id = `form-${Date.now()}`; // Unique form ID

        options?.forEach((option, index) => {
            const optionContainer = document.createElement('div');
            optionContainer.classList.add('input-group');

            const optionLabel = document.createElement('label');
            const optionInput = document.createElement('input');

            optionInput.type = inputType;
            optionInput.name = `options`;
            optionInput.value = option;
            optionInput.id = `option-${index}`;

            optionLabel.htmlFor = optionInput.id;
            optionLabel.textContent = option;

            optionContainer.appendChild(optionInput);
            optionContainer.appendChild(optionLabel);

            form.appendChild(optionContainer);
        });

        inputContainer.appendChild(form);

        // Create buttons for each action
        actions.forEach(action => {
            const actionButton = document.createElement('button');
            actionButton.textContent = action.label;
            actionButton.onclick = (event) => {
                event.preventDefault();
                const selectedOptions = Array.from(form.querySelectorAll('input[name="options"]:checked')) as HTMLInputElement[];
                const selectedValues = selectedOptions.map(option => option.value);
                if (selectedValues.length > 0) {
                    console.log(`Options selected: ${selectedValues.join(', ')}`);
                }
                action.callback(selectedValues);
                resolve(selectedValues);

                if (clearAfterAction) {
                    inputContainer.innerHTML = '';
                }
            };
            inputContainer.appendChild(actionButton);
        });

    });
}