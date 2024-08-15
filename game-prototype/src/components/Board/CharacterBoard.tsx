import type { Component } from 'solid-js';
import { CharacterSheet } from '@components/Board/Character/CharacterSheet';
import { cn } from '@components/utils';

import { getCharacterById } from '@stores/CharacterStore';

type CharacterBoardProps = {
  title: string;
  class?: string;
  characterIds: string[];
}

export const CharacterBoard: Component<CharacterBoardProps> = (props) => {
  return (
    <div class={cn('flex flex-col p-2 gap-2 rounded-md', props.class)}>
      <h2>{props.title}</h2>
      <div class="flex flex-col gap-2 pr-2 overflow-auto">
        {props.characterIds.map(id => {
          const character = getCharacterById(id);
          return character ? <CharacterSheet character={character} /> : null;
        })}
      </div>
    </div>
  );
};