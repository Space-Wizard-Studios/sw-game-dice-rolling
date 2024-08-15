import type { Component } from 'solid-js';

const InventoryBoard: Component = () => {
  return (
    <div class='flex flex-col flex-1 justify-between p-2 rounded-md bg-gray-500 bg-opacity-25'>
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