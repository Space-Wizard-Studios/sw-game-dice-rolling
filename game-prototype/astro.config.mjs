import { resolve } from 'path';
import { defineConfig } from 'astro/config';
import solid from '@astrojs/solid-js';
import tsconfigPaths from 'vite-tsconfig-paths'

export default defineConfig({
  integrations: [
    solid(),
  ],
  vite: {
    plugins: [
      tsconfigPaths(),
    ],
    resolve: {
      alias: {
        '~types': resolve(__dirname, './src/types'),
        '~': resolve(__dirname, './src'),
        '@': resolve(__dirname, './src'),
      },
    },
    types: ["vite/client"],
  },
});