export function AddOptions(
    options: string[],
    actions: { label: string, callback: () => void }[],
    inputType: 'radio' | 'checkbox' = 'radio'
): Promise<string[]> {
    return new Promise((resolve) => {
        const inputContainer = document.getElementById('input');
        if (!inputContainer) return;

        // Clear existing options
        inputContainer.innerHTML = '';

        // Create a new div element for the options
        const formContainer = document.createElement('div');
        formContainer.id = 'form-container';

        // Create a form to group input elements
        const form = document.createElement('form');
        form.id = 'form';

        // Create input elements for each option
        options.forEach((option, index) => {
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

        formContainer.appendChild(form);

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
                action.callback();
                resolve(selectedValues);
            };
            formContainer.appendChild(actionButton);
        });

        // Append the new div to the options container
        inputContainer.appendChild(formContainer);
    });
}