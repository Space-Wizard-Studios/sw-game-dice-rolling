import { themes as prismThemes } from 'prism-react-renderer';
import type { Config } from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

const config: Config = {
    title: 'Space Wizard - Dice Roll Docs',
    tagline: 'Dinosaurs are cool',
    favicon: 'img/favicon.ico',
    url: 'https://sw-game-dice-roll-docs.web.app/',
    baseUrl: '/', // For GitHub pages deployment, it is often '/<projectName>/'

    // GitHub pages deployment config.
    // organizationName: 'Space-Wizard-Studios',
    // projectName: 'sw-game-dice-roll',

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
            title: 'My Site',
            logo: {
                alt: 'My Site Logo',
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
                    href: 'https://github.com/Space-Wizard-Studios/sw-game-dice-roll',
                    label: 'GitHub',
                    position: 'right',
                },
                {
                    href: 'https://console.firebase.google.com/project/sw-game-dice-roll-docs/overview',
                    label: 'FireBase',
                    position: 'right',
                },
            ],
        },
        footer: {
            style: 'dark',
            links: [
                {
                    title: 'Community',
                    items: [
                        {
                            label: 'Stack Overflow',
                            href: 'https://stackoverflow.com/questions/tagged/docusaurus',
                        },
                        {
                            label: 'Discord',
                            href: 'https://discordapp.com/invite/docusaurus',
                        },
                        {
                            label: 'X',
                            href: 'https://x.com/docusaurus',
                        },
                    ],
                },
            ],
            copyright: `Copyright © ${new Date().getFullYear()} My Project, Inc. Built with Docusaurus.`,
        },
        prism: {
            theme: prismThemes.github,
            darkTheme: prismThemes.dracula,
            additionalLanguages: ['powershell', 'csharp'],
        },
    } satisfies Preset.ThemeConfig,
};

export default config;
