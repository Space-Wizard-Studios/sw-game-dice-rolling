const fs = require('fs');
const path = require('path');

const apiDir = path.join(__dirname, 'api');
const docsApiDir = path.join(__dirname, 'docs', 'api');

// Ensure the destination directory exists
if (!fs.existsSync(docsApiDir)) {
    fs.mkdirSync(docsApiDir, { recursive: true });
}

// Function to process files
const processFiles = (dir, destDir) => {
    fs.readdirSync(dir).forEach(file => {
        const filePath = path.join(dir, file);
        let destFilePath = path.join(destDir, file.replace('DiceRoll.', ''));

        if (fs.lstatSync(filePath).isDirectory()) {
            // Recursively process subdirectories
            processFiles(filePath, destFilePath);
        } else if (path.extname(file) === '.md') {
            // Read the file content
            let content = fs.readFileSync(filePath, 'utf8');

            // Add frontmatter with title based on file name
            const fileName = path.basename(file, path.extname(file)).replace('DiceRoll.', '');
            const frontmatter = `---\ntitle: ${fileName}\n---\n\n`;
            content = frontmatter + content;

            // Remove "DiceRoll." from the content
            content = content.replace(/DiceRoll\./g, '');

            // Add backslash before '<' that aren't part of HTML tags or <xref> tags
            content = content.replace(/<(?!\/?[\w\s="'-]+>|xref)/g, '\\<');

            // Remove all <p> and </p> tags
            content = content.replace(/<\/?p>/g, '');

            // Add double spaces at the end of each line that ends with a comma
            content = content.replace(/,(?=\s*$)/gm, ',  ');

            // Remove <a>...</a> tags from headers
            content = content.replace(/<a[^>]*>(.*?)<\/a>/g, '$1');

            // Replace <pre><code class="lang-csharp"> blocks with Markdown code blocks
            content = content.replace(/<pre><code class="lang-csharp">([\s\S]*?)<\/code><\/pre>/g, '```csharp\n$1\n```');

            // Wrap the content of `#### Inherited Members` in <details> and <summary> tags
            content = content.replace(/(#### Inherited Members\s*\n)([\s\S]*?)(?=\n#|$)/g, (match, p1, p2) => {
                return `${p1}<details>\n<summary>Show/Hide Inherited Members</summary>\n\n${p2}\n</details>`;
            });

            // Write the processed content to the destination file
            fs.writeFileSync(destFilePath, content, 'utf8');
        }
    });
};

// Process the files in the api directory
processFiles(apiDir, docsApiDir);

console.log('Files processed and copied successfully.');