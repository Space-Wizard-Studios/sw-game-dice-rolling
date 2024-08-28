import { defineConfig } from 'astro/config';
import solid from '@astrojs/solid-js';
import tsconfigPaths from 'vite-tsconfig-paths';

export default defineConfig({
  integrations: [
    solid(),
  ],
  vite: {
    resolve: {
      alias: {
        '~types': './src/types',
        '~': './src',
        '@': './src',
      },
    },
  },
});