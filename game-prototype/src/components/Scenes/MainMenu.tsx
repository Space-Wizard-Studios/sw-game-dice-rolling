import { startGameplay } from "@controllers/Gameplay/GameplayController";

export const MainMenuScene = () => {
	return (
		<section class='flex h-full w-full items-center justify-center'>
			<button onClick={startGameplay}>Start</button>
		</section>
	);
};