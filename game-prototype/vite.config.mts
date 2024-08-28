import { defineConfig } from 'vite';
import solidPlugin from 'vite-plugin-solid';
import tsconfigPaths from 'vite-tsconfig-paths';

export default defineConfig({
  base: 'sw-game-dice-roll',
  plugins: [
    solidPlugin(),
    tsconfigPaths(),
  ],
  css: {
    postcss: './postcss.config.js',
  },
  server: {
    port: 3000,
  },
  build: {
    rollupOptions: {
      external: [
        /^types\//,
      ]
    }
  },
});