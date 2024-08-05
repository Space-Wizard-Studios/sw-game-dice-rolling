export function WaitForSubmit(buttonText: string = "Submit"): Promise<void> {
    return new Promise((resolve) => {
        const submitButton = document.getElementById('gameSubmit') as HTMLButtonElement;
        const gameForm = document.getElementById('gameForm') as HTMLFormElement;

        submitButton.textContent = buttonText;
        submitButton.disabled = false;
        gameForm.addEventListener('submit', (event) => {
            event.preventDefault();
            submitButton.textContent = '';
            submitButton.disabled = true;
            resolve();
        });
    });
}