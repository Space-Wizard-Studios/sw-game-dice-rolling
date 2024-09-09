import type { Component } from 'solid-js';
import { createEffect, createSignal } from 'solid-js';
import { cn } from '@helpers/cn';

import InventoryBoard from './InventoryBoard';
import { CharacterBoard } from './CharacterBoard';

import { playerCharacterStore, enemyCharacterStore } from '@stores/Character';

type BoardProps = {
  class?: string;
}

export const Board: Component<BoardProps> = (props) => {
  const [playerCharacters, setPlayerCharacters] = createSignal(playerCharacterStore.store.characters);
  const [enemyCharacters, setEnemyCharacters] = createSignal(enemyCharacterStore.store.characters);

  createEffect(() => {
    setPlayerCharacters(playerCharacterStore.store.characters);
  });

  createEffect(() => {
    setEnemyCharacters(enemyCharacterStore.store.characters);
  });

  return (
    <div class={cn('flex flex-col md:flex-row w-full p-2 pb-0 gap-2', props.class)}>
      <CharacterBoard title='Player' characters={playerCharacters()} class='flex-[2] bg-blue-500 bg-opacity-25' />
      <InventoryBoard class='bg-orange-700 bg-opacity-25' />
      <CharacterBoard title='Enemy' characters={enemyCharacters()} class='flex-[2] bg-red-500 bg-opacity-25' />
    </div>
  );
};