import type { Component } from 'solid-js';

export const InteractivePanel: Component = () => {
  return (
    <div class="relative flex flex-col flex-1 h-1/3 md:h-full p-2 text-whitesmoke rounded-md bg-gray-700">
      <h2>Inputs</h2>
      <div class="container"></div>
    </div>
  );
};