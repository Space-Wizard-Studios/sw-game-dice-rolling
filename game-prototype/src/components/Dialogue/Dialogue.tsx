import type { Component } from 'solid-js';

import { gameState } from '@stores/GameStateStore';
import { dialogueStore } from '@stores/DialogueStore';

type DialogueProps = {
  lines?: string[];
};

export const Dialogue: Component<DialogueProps> = () => {
  // TODO: fix this mess, it's not working
  
  const lines = dialogueStore.message.map((message) => message.line);

  return (
    <div class='flex flex-col flex-1 h-full p-2 gap-2 rounded-md bg-gray-500 bg-opacity-50'>
      <div class='flex flex-row justify-between'>
        <h2>Dialogue</h2>
        <h3>Phase: {gameState.currentPhase}</h3>
      </div>
      <div class='flex flex-col p-2 gap-2 h-full overflow-y-scroll bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50'>
        {lines && lines?.map((line: string) => (
          <p>{line}</p>
        ))}
      </div>
    </div>
  );
};