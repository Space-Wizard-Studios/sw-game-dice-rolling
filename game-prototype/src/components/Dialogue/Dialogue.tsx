import { onCleanup, onMount } from 'solid-js';
import type { Component } from 'solid-js';

type DialogueProps = {
  lines: string[];
};

export const Dialogue: Component<DialogueProps> = (props) => {
  let containerRef: HTMLDivElement | undefined;

  const scrollToBottom = () => {
    if (containerRef) {
      containerRef.scrollTop = containerRef.scrollHeight;
    }
  };

  onMount(() => {
    scrollToBottom();
  });

  onCleanup(() => {
    if (containerRef) {
      containerRef.removeEventListener('DOMNodeInserted', scrollToBottom);
    }
  });

  return (
    <div class="flex flex-col flex-1 h-full p-2 gap-2 rounded-md bg-gray-500 bg-opacity-50">
      <h2>Dialogue</h2>
      <div ref={containerRef} class="flex flex-col p-2 gap-2 overflow-y-scroll bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50">
        {props.lines.map((line) => (
          <p>{line}</p>
        ))}
      </div>
    </div>
  );
};