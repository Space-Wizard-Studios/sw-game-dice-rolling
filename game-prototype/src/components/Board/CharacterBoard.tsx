import type { Component } from 'solid-js';
import { CharacterSheet } from '@components/Board/Character/CharacterSheet';
import { cn } from '@helpers/cn';
import type { Character } from '@models/Characters';

type CharacterBoardProps = {
  title: string;
  class?: string;
  characters: Character[];
}

export const CharacterBoard: Component<CharacterBoardProps> = (props) => {
  return (
    <div class={cn("flex flex-col h-full w-full p-2 gap-2 rounded-md", props.class)}>
      <h2>{props.title}</h2>
      <div class="flex flex-row md:flex-col h-full p-2 gap-2 overflow-y-auto">
        {props.characters.map(character => (
          <CharacterSheet character={character} />
        ))}
      </div>
    </div>
  );
};