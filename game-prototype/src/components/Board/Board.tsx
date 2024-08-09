import type { Component } from 'solid-js';
import InventoryBoard from './InventoryBoard';
import { playerCharacters } from '@example/playerCharacters';
import { enemyCharacters } from '@example/enemyCharacters';
import { CharacterBoard } from './CharacterBoard';

export type BoardProps = {
  id: string;
  bg: string;
}

export const Board: Component<BoardProps> = (props) => {
  return (
    <div id="gameBoard" class={`relative flex flex-row max-h-[50%] p-2 text-whitesmoke gap-2 ${props.bg}`}>
      <CharacterBoard title="Player" characters={playerCharacters} bg='bg-blue-500 bg-opacity-50' />
      <InventoryBoard />
      <CharacterBoard title="Enemy" characters={enemyCharacters} bg='bg-red-500 bg-opacity-50' />
    </div>
  );
};
