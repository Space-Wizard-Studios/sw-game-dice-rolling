import { onMount } from "solid-js";

import { startGameover } from "@controllers/Gameover/GameoverController";

export const GameoverScene = () => {
	onMount(() => {
		startGameover();
	});

	return (
		<section>
			<p>Game Over</p>
		</section>
	);
};