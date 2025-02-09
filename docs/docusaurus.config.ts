import { themes as prismThemes } from 'prism-react-renderer';
import type { Config } from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

const isGitHubPages = process.env.GITHUB_ACTIONS === 'true';
const baseUrl = isGitHubPages ? '/sw-game-dice-rolling/' : '/';

const config: Config = {
    title: 'Dice Rolling Game',
    tagline: 'Documentation',
    favicon: 'img/favicon.ico',
    url: 'https://space-wizard-studios.github.io/',
    baseUrl: baseUrl,

    organizationName: 'Space-Wizard-Studios',
    projectName: 'sw-game-dice-rolling',

    onBrokenLinks: 'warn',
    onBrokenMarkdownLinks: 'warn',

    i18n: {
        defaultLocale: 'en',
        locales: ['en'],
    },
    presets: [
        [
            'classic',
            {
                docs: {
                    sidebarPath: './sidebars.ts',
                },
                theme: {
                    customCss: './src/css/custom.css',
                },
            } satisfies Preset.Options,
        ],
    ],

    themeConfig: {
        image: 'img/docusaurus-social-card.jpg',
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
                    label: 'API Reference',
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
                // {
                //     href: 'https://console.firebase.google.com/project/sw-game-dice-rolling-docs/overview',
                //     label: 'FireBase',
                //     position: 'right',
                // },
            ],
        },
        footer: {
            style: 'dark',
            // links: [
            //     {
            //         title: 'Docs',
            //         items: [
            //             {
            //                 label: 'Tutorial',
            //                 to: '/docs/intro',
            //             },
            //         ],
            //     },
            //     {
            //         title: 'Community',
            //         items: [
            //             {
            //                 label: 'Stack Overflow',
            //                 href: 'https://stackoverflow.com/questions/tagged/docusaurus',
            //             },
            //             {
            //                 label: 'Discord',
            //                 href: 'https://discordapp.com/invite/docusaurus',
            //             },
            //             {
            //                 label: 'X',
            //                 href: 'https://x.com/docusaurus',
            //             },
            //         ],
            //     },
            //     {
            //         title: 'More',
            //         items: [
            //             {
            //                 label: 'Blog',
            //                 to: '/blog',
            //             },
            //             {
            //                 label: 'GitHub',
            //                 href: 'https://github.com/facebook/docusaurus',
            //             },
            //         ],
            //     },
            // ],
            copyright: `Copyright © ${new Date().getFullYear()} Space Wizard Studios - All Rights Reserved.`,
        },
        prism: {
            theme: prismThemes.github,
            darkTheme: prismThemes.dracula,
            additionalLanguages: ['powershell', 'csharp'],
        },
    } satisfies Preset.ThemeConfig,
    
    plugins: [require.resolve('docusaurus-lunr-search')],
};

export default config;
