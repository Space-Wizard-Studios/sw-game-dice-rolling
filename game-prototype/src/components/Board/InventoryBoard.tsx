import { DiceButton } from '@components/Dice/DiceButton';
import { cn } from '@helpers/cn';
import { playerDiceStore } from '@stores/DiceStore';
import type { Component } from 'solid-js';

type InventoryBoardProps = {
	class?: string;
}

const InventoryBoard: Component<InventoryBoardProps> = (props) => {
	return (
		<div class={cn('justify-between p-1 gap-1 rounded-md', props.class)}>
			<div class='flex flex-col h-full w-full p-1 space-y-1 rounded-md bg-black bg-opacity-25'>
				<h2>Dice</h2>
				<div class='flex flex-row gap-1'>
					{playerDiceStore.store.diceSet.map(dice => (
						<DiceButton dice={dice} />
					))}
				</div>
			</div>
			<div class='h-full w-full p-1 rounded-md bg-black bg-opacity-25'>
				<h2>Other Stuff</h2>
				<div class='container'></div>
			</div>
		</div>
	);
};

export default InventoryBoard;