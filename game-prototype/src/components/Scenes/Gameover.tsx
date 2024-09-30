import { Button } from "@components/ui/button";
import { transitionToIntroduction } from "@controllers/Gameplay/GameplayController";

export const GameoverScene = () => {
	return (
		<section class='flex flex-col h-full p-1 gap-1 bg-slate-900 text-white items-center justify-center'>
			<p>Game Over</p>
			<Button onClick={transitionToIntroduction}>Restart</Button>
		</section>
	);
};