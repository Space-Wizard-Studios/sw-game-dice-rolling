import { onMount } from "solid-js";

import { startGameover } from "@controllers/Gameover/GameoverController";

export const GameoverScene = () => {
	onMount(() => {
		startGameover();
	});

	return (
		<section class='flex flex-col h-full p-1 gap-1 bg-slate-900 text-white items-center justify-center'>
			<p>Game Over</p>
		</section>
	);
};