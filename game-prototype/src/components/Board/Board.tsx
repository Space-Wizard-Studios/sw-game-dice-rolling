/* @refresh reload */
import type { Component } from 'solid-js';
import InventoryBoard from './InventoryBoard';
import { CharacterBoard } from './CharacterBoard';
import { characterStore } from '@stores/CharacterStore';
import { cn } from '@components/utils';

type BoardProps = {
  class?: string;
}

export const Board: Component<BoardProps> = (props) => {
  const playerCharacterIds = characterStore.characters.map(character => character.id);

  return (
    <div class={cn('flex flex-row w-full p-2 gap-2', props.class)}>
      <CharacterBoard title='Player' characterIds={playerCharacterIds} class='flex-[2] bg-blue-500 bg-opacity-25'/>
      <InventoryBoard class='bg-orange-700 bg-opacity-25' />
      <CharacterBoard title='Enemy' characterIds={playerCharacterIds} class='flex-[2] bg-red-500 bg-opacity-25'/>
    </div>
  );
};