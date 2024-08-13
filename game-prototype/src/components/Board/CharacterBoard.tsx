import type { Component } from 'solid-js';
import type { CharacterStore } from 'types/characters';
import { CharacterSheet } from '@components/Board/Character/Character';
import { cn } from '@components/utils';

export type CharacterBoardProps = {
  title: string;
  bg: string;
  flex?: string;
  characters?: CharacterStore[];
}

export const CharacterBoard: Component<CharacterBoardProps> = (props) => {
  return (
    <div class={cn('flex flex-col p-2 gap-2', props.flex ?? 'flex-[2]', props.bg)}>
      <h2>{props.title}</h2>
      <div class="flex flex-col gap-2 pr-2 overflow-auto">
        {props.characters?.map((character) => (
          <CharacterSheet {...character} />
        ))}
      </div>
    </div>
  );
};