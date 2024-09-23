import { DiceButton } from '@components/Dice/DiceButton';
import { cn } from '@helpers/cn';
import type { Component } from 'solid-js';
import { diceStore } from '@stores/DiceStore';


type InventoryBoardProps = {
	diceIDs: string[];
	class?: string;
}

export const InventoryBoard: Component<InventoryBoardProps> = (props) => {
	return (
		<div class={cn('justify-between p-1 gap-1 rounded-md', props.class)}>
			<div class='flex flex-col h-full w-full p-1 space-y-1 rounded-md bg-black bg-opacity-25'>
				<h2>Bolsa de Dados</h2>
				<div class='flex flex-row gap-1'>
					{
						props.diceIDs.map(id => {
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
		</div>
	);
};