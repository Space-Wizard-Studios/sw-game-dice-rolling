import { defineConfig } from 'astro/config';
import solid from '@astrojs/solid-js';
import tsconfigPaths from 'vite-tsconfig-paths';

export default defineConfig({
  base: '/sw-game-dice-roll/',
  trailingSlash: "always",
  integrations: [
    solid(),
  ],
  vite: {
    plugins: [tsconfigPaths()],
		types: ["vite/client"]
	},
});