/* @refresh reload */
import { render } from 'solid-js/web';

import '@styles/main.scss';
import { Board } from '@components/Board/Board';

const body = document.body;

if (import.meta.env.DEV && !(body instanceof HTMLElement)) {
  throw new Error('Body element not found.');
}

render(
  () =>
    <main>
      <Board id="gameBoard" bg="bg-gray-900" />
    </main>,
  body!
);
