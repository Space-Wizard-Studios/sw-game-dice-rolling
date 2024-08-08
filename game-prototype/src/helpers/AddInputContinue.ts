export function AddInputContinue(): Promise<void> {
    return new Promise((resolve) => {
        const inputContainer = document.querySelector('#input .container');
        if (!inputContainer) {
            throw new Error('Input container not found');
        }

        const continueButton = document.createElement('button');
        continueButton.textContent = 'Continue';
        continueButton.onclick = () => {
            resolve();
            inputContainer.removeChild(continueButton);
        };

        inputContainer.appendChild(continueButton);
    });
}