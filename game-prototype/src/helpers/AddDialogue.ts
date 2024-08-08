export function AddDialogue(text: string) {
    const dialogueContainer = document.querySelector('#dialogue .container');
    if (!dialogueContainer) return;

    const newParagraph = document.createElement('p');
    newParagraph.textContent = text;
    dialogueContainer.appendChild(newParagraph);

    while (dialogueContainer.children.length > 100) {
        if (dialogueContainer.firstChild) {
            dialogueContainer.removeChild(dialogueContainer.firstChild);
        }
    }

    dialogueContainer.scrollTop = dialogueContainer.scrollHeight;
}