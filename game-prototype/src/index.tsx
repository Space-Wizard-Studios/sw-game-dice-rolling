import '@styles/main.scss';

import { render } from 'solid-js/web';
import { Component, createEffect } from 'solid-js';

import { Board } from '@components/Board/Board';
import { Dialogue } from '@components/Dialogue/Dialogue';
import { InteractivePanel } from '@components/InteractivePanel/Input';

import { gameState } from '@stores/GameStateStore';
import { startGame } from '@game/PhaseTransitions';

const Game: Component = () => {
  createEffect(() => {
    console.log('Current Phase:', gameState.currentPhase);
  });

  startGame();

  return (
    <main class="relative h-dvh w-dvh text-white">
      <div class="flex flex-row w-full h-2/3">
        <Board class="bg-slate-900" />
      </div>
      <div class="flex flex-row w-full h-1/3">
        <div class="flex flex-row w-full p-2 gap-2 bg-slate-900">
          <Dialogue />
          <InteractivePanel />
        </div>
      </div>
    </main>
  );
};

render(() => <Game />, document.body);