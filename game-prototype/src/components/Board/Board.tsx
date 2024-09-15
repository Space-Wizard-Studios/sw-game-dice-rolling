import type { Component } from 'solid-js';
import { createEffect, createSignal } from 'solid-js';
import { cn } from '@helpers/cn';

import { InventoryBoard } from './InventoryBoard';
import { CharacterBoard } from './CharacterBoard';

import { playerCharacterStore, enemyCharacterStore } from '@stores/CharacterStore';
import { playerDiceStore } from '@stores/DiceStore';

type BoardProps = {
	class?: string;
}

export const Board: Component<BoardProps> = (props) => {
	const [playerCharacters, setPlayerCharacters] = createSignal(playerCharacterStore.store.characters);
	const [enemyCharacters, setEnemyCharacters] = createSignal(enemyCharacterStore.store.characters);
	const [playerDiceSet, setPlayerDiceSet] = createSignal(playerDiceStore.store.diceSet);

	createEffect(() => {
		setPlayerCharacters(playerCharacterStore.store.characters);
	});

	createEffect(() => {
		setEnemyCharacters(enemyCharacterStore.store.characters);
	});

	createEffect(() => {
		setPlayerDiceSet(playerDiceStore.store.diceSet);
	});

	return (
		<div class={cn('flex flex-col md:flex-row gap-1', props.class)}>
			<CharacterBoard title='Player' characters={playerCharacters()} class='flex flex-[2] bg-blue-500 bg-opacity-25' />
			<InventoryBoard diceSet={playerDiceSet()} class='flex flex-row md:flex-col flex-1 bg-orange-700 bg-opacity-25' />
			<CharacterBoard title='Enemy' characters={enemyCharacters()} class='flex flex-[2] bg-red-500 bg-opacity-25' />
		</div>
	);
};