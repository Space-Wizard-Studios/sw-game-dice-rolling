import { themes as prismThemes } from 'prism-react-renderer';
import type { Config } from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';
import path from 'path';
import fs from 'fs';

// const isGitHubPages = process.env.GITHUB_ACTIONS === 'true';
// const baseUrl = isGitHubPages ? '/sw-game-dice-rolling/' : '/';

const config: Config = {
    title: 'Firebound Docs',
    staticDirectories: ['public'],
    favicon: 'img/favicon.svg',
    url: 'https://firebound.dev',
    baseUrl: '/',

    organizationName: 'Space-Wizard-Studios',
    projectName: 'firebound',

    onBrokenLinks: 'warn',
    onBrokenMarkdownLinks: 'warn',

    future: { experimental_faster: true },

    i18n: {
        defaultLocale: 'pt',
        locales: ['pt'],
    },

    markdown: {
        mermaid: true,
    },

    themes: [
        '@docusaurus/theme-mermaid',
        '@easyops-cn/docusaurus-search-local'
    ],

    presets: [
        [
            'classic',
            {
                docs: {
                    path: './content',
                    sidebarPath: './sidebars.ts',
                },
                theme: {
                    customCss: './src/css/custom.css',
                },
            } satisfies Preset.Options,
        ],
    ],

    plugins: [
        // require.resolve('docusaurus-lunr-search'),
        ['./src/plugins/tailwind-config.js', {}],
    ],

    themeConfig: {
        image: 'img/docusaurus-social-card.jpg',
        docs: {
            sidebar: {
                hideable: true,
            }
        },
        navbar: {
            logo: {
                alt: 'Dice Rolling Game Logo',
                src: 'img/logo.svg',
            },
            items: [
                ...(fs.existsSync(path.join(__dirname, 'content', 'api', 'toc_processed.json')) ? [
                    {
                        type: 'docSidebar',
                        sidebarId: 'apiSidebar',
                        position: 'left' as const,
                        label: 'API',
                    }
                ] : []),
                {
                    type: 'docSidebar',
                    sidebarId: 'architectureSidebar',
                    position: 'left' as const,
                    label: 'Architecture',
                },
                {
                    type: 'docSidebar',
                    sidebarId: 'tutorialsSidebar',
                    position: 'left' as const,
                    label: 'Tutorials',
                },
                {
                    type: 'docSidebar',
                    sidebarId: 'gameDesignSidebar',
                    position: 'left' as const,
                    label: 'Game Design',
                },
                {
                    href: 'https://github.com/Space-Wizard-Studios/sw-game-dice-rolling',
                    label: 'GitHub',
                    position: 'right' as const,
                },
            ],
        },
        footer: {
            style: 'dark',
            copyright: `Copyright © ${new Date().getFullYear()} Space Wizard Studios`,
        },
        prism: {
            theme: prismThemes.github,
            darkTheme: prismThemes.dracula,
            additionalLanguages: ['powershell', 'csharp'],
        },
        tableOfContents: {
            minHeadingLevel: 2,
            maxHeadingLevel: 4,
        },
    } satisfies Preset.ThemeConfig,

};

export default config;
