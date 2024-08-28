import { defineConfig } from 'astro/config';
import solid from '@astrojs/solid-js';

export default defineConfig({
  integrations: [
    solid(),
  ],
  vite: {
    plugins: [],
    build: {
      rollupOptions: {
        external: [
          /^types\//,
        ]
      }
    }
  },
});