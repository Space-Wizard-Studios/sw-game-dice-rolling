import { render } from 'solid-js/web';

import '@styles/main.scss';

import { Board } from '@components/Board/Board';
import { Dialogue } from '@components/Dialogue/Dialogue';
import { Input } from '@components/Input/Input';

import { dialogueLines } from '@stores/dialogueStore';

const body = document.body;

if (import.meta.env.DEV && !(body instanceof HTMLElement)) {
  throw new Error('Body element not found.');
}

render(
  () =>
    <main class="relative h-dvh w-dvh text-white">
      <div class="flex flex-row w-full h-2/3">
        <Board class="bg-gray-900" />
      </div>
      <div class="flex flex-row w-full h-1/3">
        <div class="flex flex-row w-full p-2 gap-2 bg-slate-900">
          <Dialogue lines={dialogueLines()} />
          <Input />
        </div>
      </div>
    </main>,
  body!
);
