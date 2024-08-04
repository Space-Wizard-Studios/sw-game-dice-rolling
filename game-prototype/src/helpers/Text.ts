export function addDialogue(text: string) {
    const dialogueContainer = document.getElementById('dialogueContainer');
    if (!dialogueContainer) return;

    // Create a new paragraph element for the text
    const newParagraph = document.createElement('p');
    newParagraph.textContent = text;

    // Append the new paragraph to the dialogue container
    dialogueContainer.appendChild(newParagraph);

    // Check if the number of child elements exceeds 100
    while (dialogueContainer.children.length > 100) {
        dialogueContainer.removeChild(dialogueContainer.firstChild as Node);
    }

    // Scroll to the bottom
    dialogueContainer.scrollTop = dialogueContainer.scrollHeight;
}