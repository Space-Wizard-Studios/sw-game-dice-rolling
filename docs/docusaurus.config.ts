import { themes as prismThemes } from 'prism-react-renderer';
import type { Config } from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

// const isGitHubPages = process.env.GITHUB_ACTIONS === 'true';
// const baseUrl = isGitHubPages ? '/sw-game-dice-rolling/' : '/';

const config: Config = {
    title: 'Firebound Framework',
    tagline: 'Documentation',
    staticDirectories: ['public'],
    favicon: 'img/favicon.ico',
    url: 'https://firebound.dev',
    baseUrl: '/',

    organizationName: 'Space-Wizard-Studios',
    projectName: 'firebound',

    onBrokenLinks: 'warn',
    onBrokenMarkdownLinks: 'warn',

    i18n: {
        defaultLocale: 'en',
        locales: ['en'],
    },

    markdown: {
        mermaid: true,
    },

    themes: ['@docusaurus/theme-mermaid'],

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
        require.resolve('docusaurus-lunr-search'),
    ],

    themeConfig: {
        image: 'img/docusaurus-social-card.jpg',
        docs: {
            sidebar: {
                hideable: true,
            }
        },
        navbar: {
            title: 'Dice Rolling Game',
            logo: {
                alt: 'Dice Rolling Game Logo',
                src: 'img/logo.svg',
            },
            items: [
                {
                    type: 'docSidebar',
                    sidebarId: 'apiSidebar',
                    position: 'left',
                    label: 'API',
                },
                {
                    type: 'docSidebar',
                    sidebarId: 'architectureSidebar',
                    position: 'left',
                    label: 'Architecture',
                },
                {
                    type: 'docSidebar',
                    sidebarId: 'tutorialsSidebar',
                    position: 'left',
                    label: 'Tutorials',
                },
                {
                    type: 'docSidebar',
                    sidebarId: 'gameDesignSidebar',
                    position: 'left',
                    label: 'Game Design',
                },
                {
                    href: 'https://github.com/Space-Wizard-Studios/sw-game-dice-rolling',
                    label: 'GitHub',
                    position: 'right',
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
