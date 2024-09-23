import type { Component } from 'solid-js';
import { createEffect, createMemo } from 'solid-js';
import { cn } from '@helpers/cn';

import { InventoryBoard } from './InventoryBoard';
import { CharacterBoard } from './CharacterBoard';

import { playerCharacterStore, enemyCharacterStore } from '@stores/CharacterStore';
import { inventoryStore } from '@stores/InventoryStore';

type BoardProps = {
	class?: string;
}

export const Board: Component<BoardProps> = (props) => {
	const playerCharacters = createMemo(() => playerCharacterStore.store.characters);
	const enemyCharacters = createMemo(() => enemyCharacterStore.store.characters);

	const diceIDs = createMemo(() => inventoryStore.store.diceIDs);

	return (
		<div class={cn('flex flex-col md:flex-row gap-1', props.class)}>
			<CharacterBoard title='Player' characters={playerCharacters()} class='flex flex-[2] bg-blue-500 bg-opacity-25' />
			<InventoryBoard diceIDs={diceIDs()} class='flex flex-row md:flex-col flex-1 bg-orange-700 bg-opacity-25' />
			<CharacterBoard title='Enemy' characters={enemyCharacters()} class='flex flex-[2] bg-red-500 bg-opacity-25' />
		</div>
	);
};