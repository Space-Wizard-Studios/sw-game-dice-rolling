import type { Component } from 'solid-js';
import type { Character } from 'types/characters';
import { CharacterSheet } from '@components/Board/Character/Character';

export type CharacterBoardProps = {
  title: string;
  bg: string;
  flex?: string;
  characters?: Character[];
}

export const CharacterBoard: Component<CharacterBoardProps> = (props) => {
  return (
    <div class={`flex flex-col ${props.flex ?? 'flex-[2]'} overflow-auto p-2 gap-2 ${props.bg}`}>
      <h2>{props.title}</h2>
      <div class="flex flex-col gap-2">
        {props.characters?.map((character) => (
          <CharacterSheet {...character} />
        ))}
      </div>
    </div>
  );
};