import type { Component } from 'solid-js';
import { createMemo } from 'solid-js';
import { cn } from '@helpers/cn';

import { InventoryBoard } from '@components/Board/InventoryBoard';
import { CharacterBoard } from '@components/Board/CharacterBoard';

import { playerCharacterStore, enemyCharacterStore } from '@stores/CharacterStore';
import { inventoryStore } from '@stores/InventoryStore';
import { ActionButton } from '@components/Board/ActionButton';
import { useGameManager } from '@stores/GameContext';

type BoardProps = {
	class?: string;
}

export const Board: Component<BoardProps> = (props) => {
	const playerCharacters = createMemo(() => playerCharacterStore.store.characters);
	const enemyCharacters = createMemo(() => enemyCharacterStore.store.characters);
	const inventoryDiceIDs = createMemo(() => inventoryStore.store.diceIds);

	const [gameState] = useGameManager();

	return (
		<div class={cn('flex flex-col md:flex-row gap-1', props.class)}>

			<div class='flex h-2/5 md:h-full w-full md:w-2/5 bg-blue-500 bg-opacity-25' >
				<CharacterBoard characters={playerCharacters()} />
			</div>

			<div class='flex flex-row md:flex-col h-1/5 md:h-full w-full md:w-1/5 justify-between bg-orange-700 bg-opacity-25'>
				<div class={cn('flex h-full md:h-2/3 w-2/3 md:w-full justify-between p-1 gap-1 rounded-md')}>
					<InventoryBoard diceIds={inventoryDiceIDs()} />
				</div>

				{gameState.requiredAction && (
					<div class='flex h-full md:h-1/3 w-1/3 md:w-full items-center justify-center'>
						<ActionButton actionType={gameState.requiredAction} />
					</div>
				)}
			</div>

			<div class='flex h-2/5 md:h-full w-full md:w-2/5 bg-red-500 bg-opacity-25'>
				<CharacterBoard characters={enemyCharacters()} invertedRow />
			</div>
		</div>
	);
};