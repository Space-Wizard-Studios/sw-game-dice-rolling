export async function LoadTemplate(template: string): Promise<void> {
    try {
        const templateContainer = document.createElement('div');
        templateContainer.innerHTML = template;
        document.body.appendChild(templateContainer);
    } catch (error) {
        console.error('Error loading template:', error);
    }
}