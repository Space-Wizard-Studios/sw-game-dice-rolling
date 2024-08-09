/* @refresh reload */
import { render } from 'solid-js/web';

import '@styles/main.scss';
import { Board } from '@components/Board/Board';
import { Dialogue } from '@components/Dialogue/Dialogue';
import { Input } from '@components/Input/Input';

const body = document.body;

if (import.meta.env.DEV && !(body instanceof HTMLElement)) {
  throw new Error('Body element not found.');
}

render(
  () =>
    <main class="relative h-screen">
      <Board id="gameBoard" bg="bg-gray-900" />
      <div class="flex flex-row">
        <Dialogue />
        <Input />
      </div>
    </main>,
  body!
);
