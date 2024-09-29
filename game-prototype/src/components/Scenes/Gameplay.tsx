import { Board } from "@components/Board/Board";
import { Dialogue } from "@components/Dialogue/Dialogue";

export const GameplayScene = () => {
	return (
		<section class='flex flex-col h-full p-1 gap-1 bg-slate-900 text-white items-center justify-center'>
			<Board class='h-2/3 w-full overflow-hidden' />
			<Dialogue class='h-1/3 w-full overflow-hidden' />
		</section>
	);
};