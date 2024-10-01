import { DiceButton } from '@components/Dice/DiceButton';
import { cn } from '@helpers/cn';
import type { Component } from 'solid-js';
import { diceStore } from '@stores/DiceStore';

type InventoryBoardProps = {
	diceIds: string[];
	class?: string;
}

export const InventoryBoard: Component<InventoryBoardProps> = (props) => {
	return (
		<div class={cn('flex flex-col w-full h-full overflow-auto p-1 space-y-1 rounded-md bg-black bg-opacity-25', props.class)}>
			<div class='flex flex-row flex-wrap gap-1'>
				{
					props.diceIds.map(id => {
						const dice = diceStore.getDiceByID(id);
						if (!dice) {
							console.warn(`Dice with ID ${id} not found`);
							return null;
						}
						return <DiceButton dice={dice} />
					})
				}
			</div>
		</div>
	);
};