export async function LoadLayout(template: string): Promise<void> {
    try {
        const layout = document.createElement('div');
        layout.innerHTML = template;
        document.body.appendChild(layout);
    } catch (error) {
        console.error('Error loading layout:', error);
    }
}