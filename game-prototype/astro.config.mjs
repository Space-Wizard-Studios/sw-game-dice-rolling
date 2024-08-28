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
    vite: {
      types: ["vite/client"]
    }
  },
});