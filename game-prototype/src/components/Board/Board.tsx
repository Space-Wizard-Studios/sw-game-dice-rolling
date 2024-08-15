/* @refresh reload */
import type { Component } from 'solid-js';
import InventoryBoard from './InventoryBoard';
import { CharacterBoard } from './CharacterBoard';
import { characterStore } from '@stores/characterStore';
import { cn } from '@components/utils';

type BoardProps = {
  class?: string;
}

export const Board: Component<BoardProps> = (props) => {
  const playerCharacterIds = characterStore.characters.map(character => character.id);

  return (
    <div class={cn('flex flex-row w-full p-2 gap-2', props.class)}>
      <CharacterBoard title="Player" characterIds={playerCharacterIds}/>
      <InventoryBoard />
      {/* <CharacterBoard title="Enemy"  /> */}
    </div>
  );
};