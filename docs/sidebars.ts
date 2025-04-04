import type { SidebarsConfig } from '@docusaurus/plugin-content-docs';
import fs from 'fs';
import path from 'path';

const processedTocFilePath = path.join(__dirname, 'content', 'api', 'toc_processed.json');

const toc = JSON.parse(fs.readFileSync(processedTocFilePath, 'utf8'));

const sidebars: SidebarsConfig = {
    apiSidebar: toc.apiSidebar,
    architectureSidebar: [{ type: 'autogenerated', dirName: 'architecture' }],
    gameDesignSidebar: [{ type: 'autogenerated', dirName: 'game_design' }],
    tutorialsSidebar: [{ type: 'autogenerated', dirName: 'tutorials' }],
};

export default sidebars;