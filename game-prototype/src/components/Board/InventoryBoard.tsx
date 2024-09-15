import { createSignal } from 'solid-js';
import { DiceButton } from '@components/Dice/DiceButton';
import { cn } from '@helpers/cn';
import type { Dice } from '@models/Dice';
import { playerDiceStore } from '@stores/DiceStore';
import type { Component } from 'solid-js';

type InventoryBoardProps = {
	diceSet: Dice[];
	class?: string;
}

export const InventoryBoard: Component<InventoryBoardProps> = (props) => {
	return (
		<div class={cn('justify-between p-1 gap-1 rounded-md', props.class)}>
			<div class='flex flex-col h-full w-full p-1 space-y-1 rounded-md bg-black bg-opacity-25'>
				<h2>Bolsa de Dados</h2>
				<div class='flex flex-row gap-1'>
					{playerDiceStore.store.diceSet.map(dice => (
						<DiceButton dice={dice} />
					))}
				</div>
			</div>
		</div>
	);
};