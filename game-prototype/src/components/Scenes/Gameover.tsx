import { onMount } from "solid-js";

import { startGameover } from "@controllers/Gameover/GameoverController";

export const GameoverScene = () => {
	onMount(() => {
		console.log('Gameover mounted');
		startGameover();
	});

	return (
		<section>
			<p>Game Over</p>
		</section>
	);
};