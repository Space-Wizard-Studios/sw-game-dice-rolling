import { cn } from '@components/utils';
import type { Component } from 'solid-js';

type InventoryBoardProps = {
  class?: string;
}

const InventoryBoard: Component<InventoryBoardProps> = (props) => {
  return (
    <div class={cn('flex flex-col flex-1 justify-between p-2 rounded-md', props.class)}>
      <div>
        <h2>Dice</h2>
        <div class='container'></div>
      </div>
      <div>
        <h2>Other Stuff</h2>
        <div class='container'></div>
      </div>
    </div>
  );
};

export default InventoryBoard;