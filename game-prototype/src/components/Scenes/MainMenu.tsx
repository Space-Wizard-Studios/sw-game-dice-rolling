import { transitionToIntroduction } from "@controllers/Gameplay/GameplayController";

export const MainMenuScene = () => {
	return (
		<section class='flex flex-col h-full p-1 gap-1 bg-slate-900 text-white items-center justify-center'>
			<button onClick={transitionToIntroduction}>Start</button>
		</section>
	);
};