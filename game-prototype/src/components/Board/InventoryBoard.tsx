import { cn } from '@helpers/cn';
import type { Component } from 'solid-js';

type InventoryBoardProps = {
  class?: string;
}

const InventoryBoard: Component<InventoryBoardProps> = (props) => {
  return (
    <div class={cn('flex flex-row md:flex-col flex-1 justify-between p-2  gap-2 rounded-md', props.class)}>
      <div class='w-full h-full p-2 rounded-md bg-black bg-opacity-25'>
        <h2>Dice</h2>
        <div class='container'></div>
      </div>
      <div class='w-full h-full p-2 rounded-md bg-black bg-opacity-25'>
        <h2>Other Stuff</h2>
        <div class='container'></div>
      </div>
    </div>
  );
};

export default InventoryBoard;