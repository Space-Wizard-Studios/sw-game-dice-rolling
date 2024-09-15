import type { Component } from 'solid-js';
import { CharacterSheet } from '@components/Character/CharacterSheet';
import { cn } from '@helpers/cn';
import type { Character } from '@models/Character';

type CharacterBoardProps = {
	title: string;
	class?: string;
	characters: Character[];
}

export const CharacterBoard: Component<CharacterBoardProps> = (props) => {
	return (
		<div class={cn("flex flex-col h-full w-full p-1 gap-1 rounded-md ", props.class)}>
			<h2>{props.title}</h2>
			<div class="flex flex-row md:flex-col h-full p-1 gap-1 overflow-y-auto bg-black bg-opacity-25 border-2 rounded-md border-black border-opacity-50">
				{props.characters.map(character => (
					<CharacterSheet character={character} />
				))}
			</div>
		</div>
	);
};