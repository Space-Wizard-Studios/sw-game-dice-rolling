/* @refresh reload */
import type { Component } from 'solid-js';
import InventoryBoard from './InventoryBoard';
import { characterStore as playerCharacters } from '@stores/playerCharacterStore';
import { enemyCharacters } from '@example/enemyCharacters';
import { CharacterBoard } from './CharacterBoard';

export type BoardProps = {
  class?: string;
  bg: string;
}

export const Board: Component<BoardProps> = (props) => {
  return (
    <div class={`flex flex-row w-full p-2 gap-2 ${props.bg}`}>
      {/* <CharacterBoard title="Player" characters={playerCharacters} bg='bg-blue-500 bg-opacity-50' />
      <InventoryBoard />
      <CharacterBoard title="Enemy" characters={enemyCharacters} bg='bg-red-500 bg-opacity-50' /> */}
    </div>
  );
};
