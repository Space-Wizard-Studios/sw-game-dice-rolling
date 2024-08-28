import { resolve } from 'path';
import { fileURLToPath } from 'url';
import { defineConfig } from 'astro/config';
import solid from '@astrojs/solid-js';
import tsconfigPaths from 'vite-tsconfig-paths';

const __filename = fileURLToPath(import.meta.url);
const __dirname = resolve(__filename, '..');

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
  },
});